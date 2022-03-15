using System;
using System.Collections.Generic;
using Vortice.XInput;
using static XI2DS.HighResTimer;
using System.Diagnostics;

namespace XI2DS.Xinput
{
    public class XInputController
    {
        private readonly static uint INPUT_STATE_POLLING_RATE = 125;             // Hz
        private readonly uint INTERVAL_TIME = 1000 / INPUT_STATE_POLLING_RATE;   // ms        
        private readonly HighResTimer scanTimer;

#if DEBUG
        Stopwatch stopwatch = new Stopwatch();
        long prevMills = 0;
        int tickCount = 0;
        int ticksPerSec = 0;
#endif

        public event EventHandler<XInputStateEventArgs> StateUpdated;
        public event EventHandler<XInputStatusEventArgs> StatusUpdated;
        public readonly int UserCount = 4;

        private List<State> stateList = new List<State>();
        private List<XInputStatus> statusList = new List<XInputStatus>();

        public XInputController()
        {
            for (int i = 0; i < UserCount; i++)
            {
                stateList.Add(new State());
                statusList.Add(new XInputStatus(false));
            }

            scanTimer = new HighResTimer(new TimerEventCallback(ScanState), INTERVAL_TIME);
        }

        public void Vibrate(int userIndex, byte smallMotor, byte largeMotor)
        {
            Vibration vibration = new Vibration();
            vibration.LeftMotorSpeed = Convert.ToUInt16(largeMotor * 256);
            vibration.RightMotorSpeed = Convert.ToUInt16(smallMotor * 256);
            XInput.SetVibration(userIndex, vibration);
        }

        public void StartScan()
        {
            scanTimer.Start();
#if DEBUG
            stopwatch.Start();
            prevMills = stopwatch.ElapsedMilliseconds;
#endif
        }

        public void StopScan()
        {
            scanTimer.Stop();
#if DEBUG
            stopwatch.Stop();
#endif
        }

        protected virtual void OnStateUpdated(XInputStateEventArgs e)
        {
            EventHandler<XInputStateEventArgs> handler = StateUpdated;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        protected virtual void OnStatusUpdated(XInputStatusEventArgs e)
        {
            EventHandler<XInputStatusEventArgs> handler = StatusUpdated;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        private void ScanState()
        {
#if DEBUG
            tickCount++;
            if (stopwatch.ElapsedMilliseconds - prevMills >= 1000)
            {
                if (ticksPerSec != tickCount)
                {
                    Debug.WriteLine("{0} tps", tickCount);
                }
                ticksPerSec = tickCount;
                tickCount = 0;
                prevMills = stopwatch.ElapsedMilliseconds;
            }
#endif
            for (int index = 0; index < UserCount; index++)
            {
                State state;
                int oldPackeNumber = stateList[index].PacketNumber;
                bool isSuccess = XInput.GetState(index, out state);

                if (oldPackeNumber != state.PacketNumber && isSuccess)
                {
                    XInputStateEventArgs args = new XInputStateEventArgs(index, state);
                    OnStateUpdated(args);
                }

                BatteryInformation info = XInput.GetBatteryInformation(index, BatteryDeviceType.Gamepad);
                XInputStatus status = new XInputStatus(isSuccess, info);

                if (statusList[index].IsDiff(status))
                {
                    XInputStatusEventArgs args = new XInputStatusEventArgs(index, status);
                    OnStatusUpdated(args);
                }

                stateList[index] = state;
                statusList[index] = status;
            }
        }
    }

    public readonly struct XInputStatus
    {
        private readonly bool isConnected;
        private readonly BatteryInformation batteryInfo;

        public bool IsConnected
        {
            get
            {
                return isConnected;
            }
        }
        public BatteryInformation BatteryInfo
        {
            get
            {
                return batteryInfo;
            }
        }

        public XInputStatus(bool isConnected, BatteryInformation? batteryInfo = null)
        {
            this.isConnected = isConnected;
            if (batteryInfo != null)
            {
                this.batteryInfo = (BatteryInformation)batteryInfo;
            }
            else
            {
                this.batteryInfo = new BatteryInformation();
            }
        }

        public bool IsDiff(XInputStatus status)
        {
            return status.IsConnected != IsConnected || status.BatteryInfo.BatteryType != BatteryInfo.BatteryType
                || status.BatteryInfo.BatteryLevel != BatteryInfo.BatteryLevel;
        }
    }

    public class XInputStateEventArgs : EventArgs
    {
        public int UserIndex { get; }
        public State State { get; }

        public XInputStateEventArgs(int userIndex, State state)
        {
            UserIndex = userIndex;
            State = state;
        }
    }

    public class XInputStatusEventArgs : EventArgs
    {
        public int UserIndex { get; }
        public XInputStatus Status { get; }

        public XInputStatusEventArgs(int userIndex, XInputStatus status)
        {
            UserIndex = userIndex;
            Status = status;
        }
    }
}
