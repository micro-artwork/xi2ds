using System;
using System.Threading.Tasks;
using System.Threading;
using SharpDX.XInput;


namespace XI2DS.Xinput
{
    public class XInputController
    {
        readonly static int CONT_STATUS_POLLING_RATE = 2;
        readonly static int INPUT_STATE_POLLING_RATE = 100;

        readonly int CONT_STATUS_SLEEP_TIME = 1000 / CONT_STATUS_POLLING_RATE;
        readonly int INPUT_STATE_SLEEP_TIME = 1000 / INPUT_STATE_POLLING_RATE;

        ControllerStautsReceiver statusReceiver;
        Task statusTask;
        bool statusTaskFlag = false;

        XInputStateReceiver stateReceiver;
        Task stateTask;
        bool stateTaskFlag = false;

        public Controller Controller { get; }

        public int UserIndex { get; }
                

        public XInputController(UserIndex userIndex, ControllerStautsReceiver statusReceiver, XInputStateReceiver stateReceiver)
        {
            if (userIndex == SharpDX.XInput.UserIndex.Any) throw new Exception("Not allowed user index type");
            this.UserIndex = (int)userIndex;
            this.Controller = new Controller(userIndex);
            SetControllerStatusReceiver(statusReceiver);
            SetStateReceiver(stateReceiver);
        }        

        private void SetControllerStatusReceiver(ControllerStautsReceiver receiver)
        {
            this.statusReceiver = receiver;
            this.statusTaskFlag = true;
            this.statusTask = new Task(() => ScanControllerStatus());
            this.statusTask.Start();
        }

        private void SetStateReceiver(XInputStateReceiver receiver)
        {
            this.stateReceiver = receiver;
        }


        public void Vibrate(byte smallMotor, byte largeMotor)
        {
            if (this.Controller.IsConnected)
            {
                Vibration vibration = new Vibration();
                vibration.LeftMotorSpeed = Convert.ToUInt16(largeMotor * 256);
                vibration.RightMotorSpeed = Convert.ToUInt16(smallMotor * 256);
                this.Controller.SetVibration(vibration);
            }
        }

        public bool StartScan()
        {
            if (!stateTaskFlag && this.Controller.IsConnected)
            {
                this.stateTaskFlag = true;
                this.stateTask = new Task(() => ScanState());
                this.stateTask.Start();

                return true;
            }

            return false;

        }

        public bool StopScan()
        {
            if (stateTaskFlag)
            {
                this.stateTaskFlag = false;
                this.stateTask.Wait();

                return true;
            }

            return false;
        }

        private void ScanState()
        {            
            var oldState = this.Controller.GetState();
            while (this.stateTaskFlag)
            {
                if (this.Controller.IsConnected)                
                {
                    
                    State newState;

                    try
                    {
                        newState = this.Controller.GetState();
                    }
                    catch (Exception e)
                    {
                        this.stateTaskFlag = false;
                        break;
                    }

                    if (oldState.PacketNumber != newState.PacketNumber)
                    {
                        stateReceiver.OnStateUpdated(UserIndex, newState);
                    }
                    oldState = newState;
                } else {
                    this.stateTaskFlag = false;
                    break;
                }

                Thread.Sleep(INPUT_STATE_SLEEP_TIME);

            }
            
        }

        private void ScanControllerStatus()
        {
            var information = new BatteryInformation();
            information.BatteryType = BatteryType.Disconnected;
            information.BatteryLevel = BatteryLevel.Empty;
            var oldStatus = new Status(false, information);

            while (this.statusTaskFlag)
            {   
                bool isConnected;
                BatteryInformation batteryInformation;

                if (this.Controller.IsConnected)
                {
                    isConnected = true;
                    batteryInformation = Controller.GetBatteryInformation(BatteryDeviceType.Gamepad);
                }
                else
                {
                    isConnected = false;
                    batteryInformation = new BatteryInformation();
                    batteryInformation.BatteryType = BatteryType.Disconnected;
                    batteryInformation.BatteryLevel = BatteryLevel.Empty;
                }

                Status newStatus = new Status(isConnected, batteryInformation);


                if (oldStatus.IsConnected != newStatus.IsConnected || 
                    oldStatus.BatteryInformation.BatteryType != newStatus.BatteryInformation.BatteryType ||
                    oldStatus.BatteryInformation.BatteryLevel != newStatus.BatteryInformation.BatteryLevel)
                {
                    statusReceiver.OnStatusUpdated(this.UserIndex, newStatus.IsConnected, newStatus.BatteryInformation);                    
                }

                oldStatus = newStatus;
                Thread.Sleep(CONT_STATUS_SLEEP_TIME);
            }
        }

        public struct Status
        {
            public Status(bool isConnected, BatteryInformation information)
            {
                IsConnected = isConnected;
                BatteryInformation = information;
            }

            public bool IsConnected { get; }
            public BatteryInformation BatteryInformation { get; }
        }


    }
}
