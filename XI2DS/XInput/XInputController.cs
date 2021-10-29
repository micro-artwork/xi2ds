using System;
using System.Threading.Tasks;
using System.Threading;
using Vortice.XInput;

namespace XI2DS.Xinput
{
    public class XInputController
    {        
        readonly static int INPUT_STATE_POLLING_RATE = 100;
        readonly int INPUT_STATE_SLEEP_TIME = 1000 / INPUT_STATE_POLLING_RATE;

        IXInputStautsReceiver statusReceiver;
        IXInputStateReceiver stateReceiver;

        Task stateTask;
        bool stateTaskFlag = false;
        bool reportEnabled = false;

        public int UserIndex { get; }
                

        public XInputController(int userIndex, IXInputStautsReceiver statusReceiver, IXInputStateReceiver stateReceiver)
        {
            //if (userIndex == SharpDX.XInput.UserIndex.Any) throw new Exception("Not allowed user index type");
            this.UserIndex = userIndex;
            this.statusReceiver = statusReceiver;
            this.stateReceiver = stateReceiver;
                        
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
            this.stateTaskFlag = true;
            this.stateTask = new Task(() => ScanState());
            this.stateTask.Start();
        }

        public void StopScan()
        {
            this.stateTaskFlag = false;
            this.stateTask.Wait();
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
                    stateReceiver.OnStateUpdated(UserIndex, newState);
                }

                if (count++ > INPUT_STATE_POLLING_RATE / 2) 
                {
                    count = 0;
                    BatteryInformation info = XInput.GetBatteryInformation(UserIndex, BatteryDeviceType.Gamepad);
                    statusReceiver.OnStatusUpdated(this.UserIndex, isSuccess, info);
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
