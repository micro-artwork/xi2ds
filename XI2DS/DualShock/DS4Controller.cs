using System;
using Nefarius.ViGEm.Client;
using Nefarius.ViGEm.Client.Targets;
using Nefarius.ViGEm.Client.Targets.DualShock4;

namespace XI2DS.DualShock4
{
    public class DS4Controller
    {       

        public DualShock4Controller Controller { get; }

        public int UserIndex { get; }
                
        public bool IsConnected = false;

        FeedBackReceiver feedBackReceiver;


        public DS4Controller(ViGEmClient client, int userIndex, FeedBackReceiver feedBackReceiver)
        {
            if (userIndex >= 4 && userIndex < 0)
            {
                throw new Exception("Not allowed user index type");
            }

            this.UserIndex = UserIndex;
            this.Controller = new DualShock4Controller(client);
            SetFeedBackReceiver(feedBackReceiver);       
        }

        private void SetFeedBackReceiver(FeedBackReceiver feedBackReceiver)
        {
            this.feedBackReceiver = feedBackReceiver;
            this.Controller.FeedbackReceived += (sender, e)
                => this.feedBackReceiver.OnFeedBackReceived(this.UserIndex, e.SmallMotor, e.LargeMotor);
        }

        public bool Connect()
        {
            if (!this.IsConnected)
            {
                this.Controller.Connect();
                this.IsConnected = true;

                return true;
            }

            return false;
        }

        public bool Disconnect()
        {
            if (this.IsConnected)
            {
                this.Controller.Disconnect();
                this.IsConnected = false;

                return true;
            }

            return false;
        }

        public void SendReport(DualShock4Report report)
        {
            if (this.IsConnected)
            {
                this.Controller.SendReport(report);
            }
        }
    }
}
