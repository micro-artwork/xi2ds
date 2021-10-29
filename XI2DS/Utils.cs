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


        public static Dictionary<GamepadButtonFlags, DualShock4Button> ButtonFlags =
            new Dictionary<GamepadButtonFlags, DualShock4Button>()
            {
                { GamepadButtonFlags.Start, DualShock4Button.Options },

                // back button is not used independently
                //{ GamepadButtonFlags.Back, DualShock4Buttons.Share },

                { GamepadButtonFlags.LeftThumb, DualShock4Button.ThumbLeft },
                { GamepadButtonFlags.RightThumb, DualShock4Button.ThumbRight},

                { GamepadButtonFlags.LeftShoulder, DualShock4Button.ShoulderLeft },
                { GamepadButtonFlags.RightShoulder, DualShock4Button.ShoulderRight },

                { GamepadButtonFlags.A, DualShock4Button.Cross },
                { GamepadButtonFlags.B, DualShock4Button.Circle },
                { GamepadButtonFlags.X, DualShock4Button.Square },
                { GamepadButtonFlags.Y, DualShock4Button.Triangle }
            };

        public static Dictionary<GamepadButtonFlags, DualShock4DPadDirection> DPadFlags =
            new Dictionary<GamepadButtonFlags, DualShock4DPadDirection>()
            {
               { GamepadButtonFlags.DPadUp, DualShock4DPadDirection.North },
               { GamepadButtonFlags.DPadDown, DualShock4DPadDirection.South },
               { GamepadButtonFlags.DPadLeft, DualShock4DPadDirection.West },
               { GamepadButtonFlags.DPadRight, DualShock4DPadDirection.East }
            };


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
