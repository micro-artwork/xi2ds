using System;
using System.Text;
using System.Collections.Generic;
using SharpDX.XInput;
using Nefarius.ViGEm.Client.Targets.DualShock4;

namespace XI2DS
{
    static class Utils
    {
        private static Dictionary<GamepadButtonFlags, string> XInputButtonDict =
            new Dictionary<GamepadButtonFlags, string>()
            {
                { GamepadButtonFlags.DPadUp, "Up" },
                { GamepadButtonFlags.DPadDown, "Down" },
                { GamepadButtonFlags.DPadLeft, "Left" },
                { GamepadButtonFlags.DPadRight, "Right" },
                { GamepadButtonFlags.Start, "Start" },
                { GamepadButtonFlags.Back, "Back" },
                { GamepadButtonFlags.LeftThumb, "LS" },
                { GamepadButtonFlags.RightThumb, "RS" },
                { GamepadButtonFlags.LeftShoulder, "LB" },
                { GamepadButtonFlags.RightShoulder, "RB" },
                { GamepadButtonFlags.A, "A" },
                { GamepadButtonFlags.B, "B" },
                { GamepadButtonFlags.X, "X" },
                { GamepadButtonFlags.Y, "Y" }
        };


        private static Dictionary<GamepadButtonFlags, DualShock4Buttons> ButtonFlags =
            new Dictionary<GamepadButtonFlags, DualShock4Buttons>()
            {
                { GamepadButtonFlags.Start, DualShock4Buttons.Options },

                // back button is not used independently
                //{ GamepadButtonFlags.Back, DualShock4Buttons.Share },

                { GamepadButtonFlags.LeftThumb, DualShock4Buttons.ThumbLeft },
                { GamepadButtonFlags.RightThumb, DualShock4Buttons.ThumbRight},

                { GamepadButtonFlags.LeftShoulder, DualShock4Buttons.ShoulderLeft },
                { GamepadButtonFlags.RightShoulder, DualShock4Buttons.ShoulderRight },

                { GamepadButtonFlags.A, DualShock4Buttons.Cross },
                { GamepadButtonFlags.B, DualShock4Buttons.Circle },
                { GamepadButtonFlags.X, DualShock4Buttons.Square },
                { GamepadButtonFlags.Y, DualShock4Buttons.Triangle }
            };

        private static Dictionary<GamepadButtonFlags, DualShock4DPadValues> DPadFlags =
            new Dictionary<GamepadButtonFlags, DualShock4DPadValues>()
            {
               { GamepadButtonFlags.DPadUp, DualShock4DPadValues.North },
               { GamepadButtonFlags.DPadDown, DualShock4DPadValues.South },
               { GamepadButtonFlags.DPadLeft, DualShock4DPadValues.West },
               { GamepadButtonFlags.DPadRight, DualShock4DPadValues.East }
            };


        public static DualShock4Report XInputStateToDS4Report(State state)
        {

            Gamepad gamepad = state.Gamepad;
            GamepadButtonFlags buttons = gamepad.Buttons;
            
            var report = new DualShock4Report();
            DualShock4Buttons ds4Buttons = new DualShock4Buttons();

            foreach (KeyValuePair<GamepadButtonFlags, DualShock4Buttons> item in ButtonFlags)
            {
                if (buttons.HasFlag(item.Key)) ds4Buttons |= item.Value;
            }

            // combination for special button implementation                       
            if (buttons.HasFlag(GamepadButtonFlags.Back) && buttons.HasFlag(GamepadButtonFlags.Start))
            {
                ds4Buttons &= ~DualShock4Buttons.Options;
                report.SetSpecialButtons(DualShock4SpecialButtons.Ps);
            }
            else if (buttons.HasFlag(GamepadButtonFlags.Back) && buttons.HasFlag(GamepadButtonFlags.LeftShoulder))
            {
                ds4Buttons &= ~DualShock4Buttons.ShoulderLeft;
                ds4Buttons |= DualShock4Buttons.Share;
            } 
            else if (buttons.HasFlag(GamepadButtonFlags.Back) && buttons.HasFlag(GamepadButtonFlags.RightShoulder))
            {
                ds4Buttons &= ~DualShock4Buttons.ShoulderRight;
                report.SetSpecialButtons(DualShock4SpecialButtons.Touchpad);
            }

            report.SetButtons(ds4Buttons);


            foreach (KeyValuePair<GamepadButtonFlags, DualShock4DPadValues> item in DPadFlags)
            {
                if (buttons.HasFlag(item.Key)) report.SetDPad(item.Value);
            }

            if (buttons.HasFlag(GamepadButtonFlags.DPadUp) && buttons.HasFlag(GamepadButtonFlags.DPadLeft))
            {
                report.SetDPad(DualShock4DPadValues.Northwest);
            } 
            else if (buttons.HasFlag(GamepadButtonFlags.DPadUp) && buttons.HasFlag(GamepadButtonFlags.DPadRight))
            {
                report.SetDPad(DualShock4DPadValues.Northeast);
            }
            else if (buttons.HasFlag(GamepadButtonFlags.DPadDown) && buttons.HasFlag(GamepadButtonFlags.DPadLeft))
            {
                report.SetDPad(DualShock4DPadValues.Southwest);
            }
            else if (buttons.HasFlag(GamepadButtonFlags.DPadDown) && buttons.HasFlag(GamepadButtonFlags.DPadRight))
            {
                report.SetDPad(DualShock4DPadValues.Southeast);
            }


            Int16 ltx = (Int16)((Math.Abs((float)gamepad.LeftThumbX) < Gamepad.LeftThumbDeadZone) ? 0 : (float)gamepad.LeftThumbX / short.MaxValue * 127);
            Int16 lty = (Int16)((Math.Abs((float)gamepad.LeftThumbY) < Gamepad.LeftThumbDeadZone) ? 0 : (float)gamepad.LeftThumbY / short.MaxValue * -127);
            Int16 rtx = (Int16)((Math.Abs((float)gamepad.RightThumbX) < Gamepad.RightThumbDeadZone) ? 0 : (float)gamepad.RightThumbX / short.MaxValue * 127);
            Int16 rty = (Int16)((Math.Abs((float)gamepad.RightThumbY) < Gamepad.RightThumbDeadZone) ? 0 : (float)gamepad.RightThumbY / short.MaxValue * -127);

            report.SetAxis(DualShock4Axes.LeftThumbX, (byte)(ltx + 0x7f));
            report.SetAxis(DualShock4Axes.LeftThumbY, (byte)(lty + 0x7f));
            report.SetAxis(DualShock4Axes.RightThumbX, (byte)(rtx + 0x7f));
            report.SetAxis(DualShock4Axes.RightThumbY, (byte)(rty + 0x7f));

            if (gamepad.LeftTrigger > Gamepad.TriggerThreshold)
            {
                report.SetButtons(DualShock4Buttons.TriggerLeft);
                report.SetAxis(DualShock4Axes.LeftTrigger, gamepad.LeftTrigger);
            }

            if (gamepad.RightTrigger > Gamepad.TriggerThreshold)
            {
                report.SetButtons(DualShock4Buttons.TriggerRight);
                report.SetAxis(DualShock4Axes.RightTrigger, gamepad.RightTrigger);
            }


            return report;

        }

        public static string XInputStateToText(State state)
        {

            StringBuilder sb = new StringBuilder();
            string format = "{0} ";
            //string analogFormat = "{0}:{1:F4} ";

            Gamepad gamepad = state.Gamepad;
            GamepadButtonFlags buttons = gamepad.Buttons;

            foreach (KeyValuePair<GamepadButtonFlags, string> item in XInputButtonDict)
            {
                if (buttons.HasFlag(item.Key)) sb.AppendFormat(format, item.Value);
            }

            if (gamepad.LeftTrigger > Gamepad.TriggerThreshold)
            {
                //sb.AppendFormat(analogFormat, "LT", (float)gamepad.LeftTrigger / byte.MaxValue);
                sb.AppendFormat(format, "LT");
            }

            if (gamepad.RightTrigger > Gamepad.TriggerThreshold)
            {
                //sb.AppendFormat(analogFormat, "RT", (float)gamepad.RightTrigger / byte.MaxValue);
                sb.AppendFormat(format, "RT");
            }


            if (Math.Abs((float)gamepad.LeftThumbX) > Gamepad.LeftThumbDeadZone)
            {
                //var leftThumbX = (float)gamepad.LeftThumbX / short.MaxValue;
                //sb.AppendFormat(analogFormat, "LTX", leftThumbX);
                sb.AppendFormat(format, "LTX");
            }

            if (Math.Abs((float)gamepad.LeftThumbY) > Gamepad.LeftThumbDeadZone)
            {
                //var leftThumbY = (float)gamepad.LeftThumbY / short.MaxValue;
                //sb.AppendFormat(analogFormat, "LTY", leftThumbY);
                sb.AppendFormat(format, "LTY");
            }

            if (Math.Abs((float)gamepad.RightThumbX) > Gamepad.RightThumbDeadZone)
            {
                //var rightThumbX = (float)gamepad.RightThumbX / short.MaxValue;
                //sb.AppendFormat(analogFormat, "RTX", rightThumbX);
                sb.AppendFormat(format, "RTX");
            }

            if (Math.Abs((float)gamepad.RightThumbY) > Gamepad.RightThumbDeadZone)
            {
                //var rightThumbY = (float)gamepad.RightThumbY / short.MaxValue;
                //sb.AppendFormat(analogFormat, "RY", rightThumbY);
                sb.AppendFormat(format, "RTY");
            }
            
            return sb.ToString();

        }

        public static float[] XInputStateToGridViewData(State state)
        {
            float[] data = new float[20];

            Gamepad gamepad = state.Gamepad;
            GamepadButtonFlags buttons = gamepad.Buttons;

            int index = 0;

            foreach (KeyValuePair<GamepadButtonFlags, string> item in XInputButtonDict)
            {
                if (buttons.HasFlag(item.Key)) data[index++] = 1.0f;
                else data[index++] = 0f;
            }

            data[index++] = Math.Abs((float)gamepad.LeftTrigger) > Gamepad.TriggerThreshold ?
                            (float)decimal.Round((decimal)gamepad.LeftTrigger / byte.MaxValue, 4) : 0f;
            data[index++] = Math.Abs((float)gamepad.RightTrigger) > Gamepad.TriggerThreshold ?
                            (float)decimal.Round((decimal)gamepad.RightTrigger / byte.MaxValue, 4) : 0f;
            data[index++] = Math.Abs((float)gamepad.LeftThumbX) > Gamepad.LeftThumbDeadZone ?
                            (float)decimal.Round((decimal)gamepad.LeftThumbX / short.MaxValue, 4) : 0f;
            data[index++] = Math.Abs((float)gamepad.LeftThumbY) > Gamepad.LeftThumbDeadZone ?
                            (float)decimal.Round((decimal)gamepad.LeftThumbY / short.MaxValue, 4) : 0f;
            data[index++] = Math.Abs((float)gamepad.RightThumbX) > Gamepad.LeftThumbDeadZone ?
                            (float)decimal.Round((decimal)gamepad.RightThumbX / short.MaxValue, 4) : 0f;
            data[index++] = Math.Abs((float)gamepad.RightThumbY) > Gamepad.LeftThumbDeadZone ?
                            (float)decimal.Round((decimal)gamepad.RightThumbY / short.MaxValue, 4) : 0f;

            return data;

        }

    }
}
