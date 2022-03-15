using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace XI2DS
{
    class HighResTimer : IDisposable
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/windows/win32/api/timeapi/ns-timeapi-timecaps
        /// </summary>
        private struct TimeCaps
        {
            public uint wPeriodMin;
            public uint wPeriodMax;
        }

        /// <summary>
        /// https://docs.microsoft.com/en-us/previous-versions/ff728861(v=vs.85)
        /// </summary>
        /// <param name="uTimerID">The identifier of the timer</param>
        /// <param name="uMsg">Reserved</param>
        /// <param name="dwUser">The value that was specified for the dwUser parameter of the timeSetEvent function</param>
        /// <param name="dw1">Reserved</param>
        /// <param name="dw2">Reserved</param>
        private delegate void TimerEventHandler(uint uTimerID, uint uMsg, IntPtr dwUser, IntPtr dw1, IntPtr dw2);

        public delegate void TimerEventCallback();

        private readonly static uint TARGET_RESOLUTION = 1;

        private enum TimerMode
        {
            OneShot,
            Peoriodic
        }

        private bool disposed = false;
        private int timerId = 0;
        private uint interval = 100;

        private readonly TimerEventHandler eventHandler;

        public int TimerID
        {
            get { return timerId; }
        }

        public bool IsRunning
        {
            get { return timerId != 0; }
        }

        public HighResTimer(TimerEventCallback callback, uint interval)
        {
            this.interval = interval;
            this.eventHandler = new TimerEventHandler((uTimerID, uMsg, dwUser, dw1, dw2) => callback());
        }

        ~HighResTimer()
        {
            Dispose(false);
        }

        public void Start()
        {
            if (IsRunning)
            {
                throw new InvalidOperationException("Timer is alreay running");
            }

            uint dwUser = 0;
            TimeCaps caps = new TimeCaps();

            timeGetDevCaps(ref caps, Marshal.SizeOf(caps));
            uint resolution = Math.Max(Math.Min(caps.wPeriodMin, TARGET_RESOLUTION), caps.wPeriodMax);

            timerId = timeSetEvent(interval, resolution, eventHandler, new IntPtr(dwUser), TimerMode.Peoriodic);

            if (timerId == 0)
            {
                throw new Win32Exception(Marshal.GetLastWin32Error());
            }
        }

        public void Stop()
        {
            if (!IsRunning)
            {
                throw new InvalidOperationException("Timer is not running");
            }

            timeKillEvent(timerId);
            timerId = 0;
        }

        private protected virtual void Dispose(bool disposing = true)
        {
            if (disposed)
            {
                return;
            }

            if (IsRunning)
            {
                Stop();
            }

            if (disposing)
            {
                GC.SuppressFinalize(this);
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
        }


        /// <summary>
        /// https://docs.microsoft.com/ko-kr/windows/win32/api/timeapi/nf-timeapi-timegetdevcaps
        /// </summary>
        /// <param name="caps">A pointer to a TIMECAPS structure</param>
        /// <param name="sizeOfTimerCaps">The size, in bytes, of the TIMECAPS structure</param>
        /// <returns></returns>
        [DllImport("winmm.dll")]
        private static extern int timeGetDevCaps(ref TimeCaps caps, int sizeOfTimerCaps);

        /// <summary>
        /// https://docs.microsoft.com/en-us/previous-versions/dd757634(v=vs.85) 
        /// </summary>
        /// <param name="uDelay">Event delay, in milliseconds</param>
        /// <param name="uResolution">Resolution of the timer event, in milliseconds</param>
        /// <param name="lpTimeProc">Pointer to a callback function</param>
        /// <param name="dwUser">User-supplied callback data</param>
        /// <param name="fuEvent">Timer event type</param>
        /// <returns></returns>
        [DllImport("winmm.dll")]
        private static extern int timeSetEvent(uint uDelay, uint uResolution, TimerEventHandler lpTimeProc, IntPtr dwUser, TimerMode fuEvent);

        /// <summary>
        /// https://docs.microsoft.com/en-us/previous-versions/dd757630(v=vs.85)
        /// </summary>
        /// <param name="uTimerID">Identifier of the timer event to cancel</param>
        /// <returns></returns>
        [DllImport("winmm.dll")]
        private static extern int timeKillEvent(int uTimerID);

    }

}
