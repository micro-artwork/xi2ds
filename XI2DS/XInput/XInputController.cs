using System;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Threading;
using Vortice.XInput;

namespace XI2DS.Xinput
{
    public class XInputController
    {
        readonly static int INPUT_STATE_POLLING_RATE = 120;     // 60Hz * 2
        readonly int INPUT_STATE_SLEEP_TIME = 1000 / INPUT_STATE_POLLING_RATE;
        readonly bool ENABLE_TIMER_BOOST = true;

        IXInputEventReceiver xInputEventReceiver;

        Thread stateThread;
        bool stateThreadFlag = false;
        bool reportEnabled = false;

        public int UserIndex { get; }

        [StructLayout(LayoutKind.Sequential)]
        public struct TimeCaps
        {
            public TimeCaps(UInt32 min, UInt32 max)
            {
                wPeriodMin = min;
                wPeriodMax = max;
            }

            public UInt32 wPeriodMin;
            public UInt32 wPeriodMax;
        };

        [DllImport("winmm.dll", SetLastError = true)]
        static extern UInt32 timeGetDevCaps(ref TimeCaps timeCaps, UInt32 sizeTimeCaps);
        [DllImport("winmm.dll")]
        static extern uint timeBeginPeriod(uint uMilliseconds);
        [DllImport("winmm.dll")]
        static extern uint timeEndPeriod(uint uMilliseconds);
        [DllImport("winmm.dll")]
        static extern uint timeGetTime();

        public XInputController(int userIndex, IXInputEventReceiver xInputEventReceiver)
        {
            //if (userIndex == SharpDX.XInput.UserIndex.Any) throw new Exception("Not allowed user index type");
            this.UserIndex = userIndex;
            this.xInputEventReceiver = xInputEventReceiver;
            Utils.FPS[UserIndex] = 0;
            Utils.Connected[UserIndex] = false;
            Utils.State[UserIndex] = new State();

            StartScan();
        }

        public void Vibrate(byte smallMotor, byte largeMotor)
        {
            Vibration vibration = new Vibration();
            vibration.LeftMotorSpeed = Convert.ToUInt16(largeMotor * 256);
            vibration.RightMotorSpeed = Convert.ToUInt16(smallMotor * 256);
            XInput.SetVibration(UserIndex, vibration);
        }

        public void StartScan()
        {
            if (!this.stateThreadFlag)
            {
                this.stateThreadFlag = true;
                this.stateThread = new Thread(ScanState);
                this.stateThread.Start();
            }
        }

        public void StopScan()
        {
            if (this.stateThreadFlag)
            {
                this.stateThreadFlag = false;
                this.stateThread.Join();
            }
        }

        public void StartReport()
        {
            this.reportEnabled = true;
        }

        public void StopReport()
        {
            this.reportEnabled = false;
        }

        private void ScanState()
        {
            State oldState, newState;
            bool isSuccess = XInput.GetState(UserIndex, out oldState);

            TimeCaps timeCaps = new TimeCaps(0, 0);
            if (ENABLE_TIMER_BOOST)
            {
                timeGetDevCaps(ref timeCaps, (uint)Marshal.SizeOf(timeCaps));
                timeBeginPeriod(timeCaps.wPeriodMin);
            }

            int frameCount = 0;
            uint frameStart = timeGetTime();

            while (this.stateThreadFlag)
            {
                uint pollingStart = timeGetTime();
                isSuccess = XInput.GetState(UserIndex, out newState);

                if (oldState.PacketNumber != newState.PacketNumber && this.reportEnabled && isSuccess)
                {
                    xInputEventReceiver.OnStateUpdated(UserIndex, newState);
                }

                oldState = newState;
                Utils.Connected[UserIndex] = isSuccess;
                Utils.State[UserIndex] = newState;

                uint pollingEnd = timeGetTime();
                int sleepTime = 0;
                unchecked
                {
                    sleepTime = INPUT_STATE_SLEEP_TIME - (int)(pollingEnd - pollingStart);
                    if (sleepTime < 0) { sleepTime = 0; }
                }

                if (0 < sleepTime)
                {
                    Thread.Sleep(sleepTime);
                }

                ++frameCount;

                uint frameNow = timeGetTime();
                int frameDiff = 0;
                unchecked { frameDiff = (int)(frameNow - frameStart); }

                if (1000 <= frameDiff)
                {
                    frameStart = frameNow;
                    Utils.FPS[UserIndex] = frameCount;
                    frameCount = 0;
                }
            }

            if (ENABLE_TIMER_BOOST)
            {
                timeEndPeriod(timeCaps.wPeriodMin);
            }
        }

        public struct XInputStatus
        {
            public XInputStatus(BatteryInformation information)
            {
                IsConnected = information.BatteryLevel != BatteryLevel.Empty;
                BatteryInformation = information;
            }

            public bool IsConnected { get; }
            public BatteryInformation BatteryInformation { get; }
        }


    }
}
