using System;
using System.Collections.Generic;
using Nefarius.ViGEm.Client;
using Nefarius.ViGEm.Client.Targets;
using Nefarius.ViGEm.Client.Targets.DualShock4;
using Vortice.XInput;

namespace XI2DS.DualShock4
{
    public class DS4Controller
    {

        readonly Dictionary<GamepadButtons, DualShock4Button> ButtonFlags =
            new Dictionary<GamepadButtons, DualShock4Button>()
            {
                { GamepadButtons.Start, DualShock4Button.Options },

                // back button is not used independently
                //{ GamepadButtonFlags.Back, DualShock4Buttons.Share },
                { GamepadButtons.LeftThumb, DualShock4Button.ThumbLeft },
                { GamepadButtons.RightThumb, DualShock4Button.ThumbRight},

                { GamepadButtons.LeftShoulder, DualShock4Button.ShoulderLeft },
                { GamepadButtons.RightShoulder, DualShock4Button.ShoulderRight },

                { GamepadButtons.A, DualShock4Button.Cross },
                { GamepadButtons.B, DualShock4Button.Circle },
                { GamepadButtons.X, DualShock4Button.Square },
                { GamepadButtons.Y, DualShock4Button.Triangle }
            };

        readonly Dictionary<GamepadButtons, DualShock4DPadDirection> DPadFlags =
            new Dictionary<GamepadButtons, DualShock4DPadDirection>()
            {
               { GamepadButtons.DPadUp, DualShock4DPadDirection.North },
               { GamepadButtons.DPadDown, DualShock4DPadDirection.South },
               { GamepadButtons.DPadLeft, DualShock4DPadDirection.West },
               { GamepadButtons.DPadRight, DualShock4DPadDirection.East }
            };


        public IDualShock4Controller Controller { get; }
              

        public int UserIndex { get; }

        public bool IsConnected = false;

        IFeedBackReceiver feedBackReceiver;
        
        public DS4Controller(ViGEmClient client, int userIndex, IFeedBackReceiver feedBackReceiver)
        {
            if (userIndex >= 4 && userIndex < 0)
            {
                throw new Exception("Not allowed user index type");
            }

            this.UserIndex = UserIndex;
            this.Controller = client.CreateDualShock4Controller();
            SetFeedBackReceiver(feedBackReceiver);
        }

        private void SetFeedBackReceiver(IFeedBackReceiver feedBackReceiver)
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

        public void SubmitReport(State state)
        {
            if (this.IsConnected)
            {
                Gamepad gamepad = state.Gamepad;
                GamepadButtons buttons = gamepad.Buttons;
                
                foreach (KeyValuePair<GamepadButtons, DualShock4Button> item in ButtonFlags)
                {
                    Controller.SetButtonState(item.Value, buttons.HasFlag(item.Key));
                }

                // combination for special button implementation                       
                if (buttons.HasFlag(GamepadButtons.Back)) {
                                        
                    if (buttons.HasFlag(GamepadButtons.Start))
                    {
                        Controller.SetButtonState(DualShock4SpecialButton.Ps, true);
                        Controller.SetButtonState(DualShock4SpecialButton.Options, false);
                    } 
                    else if (buttons.HasFlag(GamepadButtons.LeftShoulder))
                    {
                        Controller.SetButtonState(DualShock4SpecialButton.Share, true);
                        Controller.SetButtonState(DualShock4Button.ShoulderLeft, false);
                    }
                    else if (buttons.HasFlag(GamepadButtons.RightShoulder))
                    {
                        Controller.SetButtonState(DualShock4SpecialButton.Touchpad, true);
                        Controller.SetButtonState(DualShock4Button.ShoulderRight, false);
                    } else
                    {
                        Controller.SetButtonState(DualShock4SpecialButton.Ps, false);
                        Controller.SetButtonState(DualShock4SpecialButton.Share, false);
                        Controller.SetButtonState(DualShock4SpecialButton.Touchpad, false);
                    }

                } else
                {
                    Controller.SetButtonState(DualShock4SpecialButton.Ps, false);
                    Controller.SetButtonState(DualShock4SpecialButton.Share, false);
                    Controller.SetButtonState(DualShock4SpecialButton.Touchpad, false);
                }

                Controller.SetDPadDirection(DualShock4DPadDirection.None);

                foreach (KeyValuePair<GamepadButtons, DualShock4DPadDirection> item in DPadFlags)
                {
                    if (buttons.HasFlag(item.Key))
                    {
                        Controller.SetDPadDirection(item.Value);
                    }
                }
                
                if (buttons.HasFlag(GamepadButtons.DPadUp) && buttons.HasFlag(GamepadButtons.DPadLeft))
                {
                    Controller.SetDPadDirection(DualShock4DPadDirection.Northwest);
                }
                else if (buttons.HasFlag(GamepadButtons.DPadUp) && buttons.HasFlag(GamepadButtons.DPadRight))
                {
                    Controller.SetDPadDirection(DualShock4DPadDirection.Northeast);
                }
                else if (buttons.HasFlag(GamepadButtons.DPadDown) && buttons.HasFlag(GamepadButtons.DPadLeft))
                {
                    Controller.SetDPadDirection(DualShock4DPadDirection.Southwest);
                }
                else if (buttons.HasFlag(GamepadButtons.DPadDown) && buttons.HasFlag(GamepadButtons.DPadRight))
                {
                    Controller.SetDPadDirection(DualShock4DPadDirection.Southeast);
                }

                Int16 ltx = (Int16)((Math.Abs((float)gamepad.LeftThumbX) < Gamepad.LeftThumbDeadZone) ? 0 : (float)gamepad.LeftThumbX / short.MaxValue * 127);
                Int16 lty = (Int16)((Math.Abs((float)gamepad.LeftThumbY) < Gamepad.LeftThumbDeadZone) ? 0 : (float)gamepad.LeftThumbY / short.MaxValue * -127);
                Int16 rtx = (Int16)((Math.Abs((float)gamepad.RightThumbX) < Gamepad.RightThumbDeadZone) ? 0 : (float)gamepad.RightThumbX / short.MaxValue * 127);
                Int16 rty = (Int16)((Math.Abs((float)gamepad.RightThumbY) < Gamepad.RightThumbDeadZone) ? 0 : (float)gamepad.RightThumbY / short.MaxValue * -127);

                Controller.SetAxisValue(DualShock4Axis.LeftThumbX, (byte)(ltx + 0x7f));
                Controller.SetAxisValue(DualShock4Axis.LeftThumbY, (byte)(lty + 0x7f));
                Controller.SetAxisValue(DualShock4Axis.RightThumbX, (byte)(rtx + 0x7f));
                Controller.SetAxisValue(DualShock4Axis.RightThumbY, (byte)(rty + 0x7f));

                Controller.SetButtonState(DualShock4Button.TriggerLeft, gamepad.LeftTrigger > Gamepad.TriggerThreshold);
                Controller.SetSliderValue(DualShock4Slider.LeftTrigger, gamepad.LeftTrigger);                
                Controller.SetButtonState(DualShock4Button.TriggerRight, gamepad.RightTrigger > Gamepad.TriggerThreshold);
                Controller.SetSliderValue(DualShock4Slider.RightTrigger, gamepad.RightTrigger);                
     
                this.Controller.SubmitReport();

            }
        }
    }
}
