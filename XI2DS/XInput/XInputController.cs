using System;
using System.Threading.Tasks;
using System.Threading;
using Vortice.XInput;

namespace XI2DS.Xinput
{
    public class XInputController
    {
        readonly static int INPUT_STATE_POLLING_RATE = 120;     // 60Hz * 2
        readonly int INPUT_STATE_SLEEP_TIME = 1000 / INPUT_STATE_POLLING_RATE;

        IXInputEventReceiver xInputEventReceiver;

        Task stateTask;
        bool stateTaskFlag = false;
        bool reportEnabled = false;

        public int UserIndex { get; }


        public XInputController(int userIndex, IXInputEventReceiver xInputEventReceiver)
        {
            //if (userIndex == SharpDX.XInput.UserIndex.Any) throw new Exception("Not allowed user index type");
            this.UserIndex = userIndex;
            this.xInputEventReceiver = xInputEventReceiver;

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
            if (!this.stateTaskFlag)
            {
                this.stateTaskFlag = true;
                this.stateTask = new Task(() => ScanState());
                this.stateTask.Start();
            }
        }

        public void StopScan()
        {
            if (this.stateTaskFlag)
            {
                this.stateTaskFlag = false;
                this.stateTask.Wait();
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
            int count = 0;
            bool isSuccess = XInput.GetState(UserIndex, out oldState);

            while (this.stateTaskFlag)
            {
                isSuccess = XInput.GetState(UserIndex, out newState);

                if (oldState.PacketNumber != newState.PacketNumber && this.reportEnabled && isSuccess)
                {
                    xInputEventReceiver.OnStateUpdated(UserIndex, newState);
                }

                if (count++ > INPUT_STATE_POLLING_RATE / 2)
                {
                    count = 0;
                    BatteryInformation info = XInput.GetBatteryInformation(UserIndex, BatteryDeviceType.Gamepad);
                    xInputEventReceiver.OnStatusUpdated(this.UserIndex, isSuccess, info);
                }

                oldState = newState;

                Thread.Sleep(INPUT_STATE_SLEEP_TIME);
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
