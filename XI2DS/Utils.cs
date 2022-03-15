using System;
using System.Text;
using System.Collections.Generic;
using Nefarius.ViGEm.Client.Targets.DualShock4;
using Vortice.XInput;
using System.Diagnostics;

namespace XI2DS
{
    static class Utils
    {
        private static Dictionary<GamepadButtons, string> XInputButtonDict =
            new Dictionary<GamepadButtons, string>()
            {
                { GamepadButtons.DPadUp, "Up" },
                { GamepadButtons.DPadDown, "Down" },
                { GamepadButtons.DPadLeft, "Left" },
                { GamepadButtons.DPadRight, "Right" },
                { GamepadButtons.Start, "Start" },
                { GamepadButtons.Back, "Back" },
                { GamepadButtons.LeftThumb, "LS" },
                { GamepadButtons.RightThumb, "RS" },
                { GamepadButtons.LeftShoulder, "LB" },
                { GamepadButtons.RightShoulder, "RB" },
                { GamepadButtons.A, "A" },
                { GamepadButtons.B, "B" },
                { GamepadButtons.X, "X" },
                { GamepadButtons.Y, "Y" }
        };


        public static Dictionary<GamepadButtons, DualShock4Button> ButtonFlags =
            new Dictionary<GamepadButtons, DualShock4Button>()
            {
                { GamepadButtons.Start, DualShock4Button.Options },

                // back button is not used independently
                //{ GamepadButtons.Back, DualShock4Buttons.Share },

                { GamepadButtons.LeftThumb, DualShock4Button.ThumbLeft },
                { GamepadButtons.RightThumb, DualShock4Button.ThumbRight},

                { GamepadButtons.LeftShoulder, DualShock4Button.ShoulderLeft },
                { GamepadButtons.RightShoulder, DualShock4Button.ShoulderRight },

                { GamepadButtons.A, DualShock4Button.Cross },
                { GamepadButtons.B, DualShock4Button.Circle },
                { GamepadButtons.X, DualShock4Button.Square },
                { GamepadButtons.Y, DualShock4Button.Triangle }
            };

        public static Dictionary<GamepadButtons, DualShock4DPadDirection> DPadFlags =
            new Dictionary<GamepadButtons, DualShock4DPadDirection>()
            {
               { GamepadButtons.DPadUp, DualShock4DPadDirection.North },
               { GamepadButtons.DPadDown, DualShock4DPadDirection.South },
               { GamepadButtons.DPadLeft, DualShock4DPadDirection.West },
               { GamepadButtons.DPadRight, DualShock4DPadDirection.East }
            };


        public static string XInputStateToText(State state)
        {

            StringBuilder sb = new StringBuilder();
            string format = "{0} ";
            //string analogFormat = "{0}:{1:F4} ";

            Gamepad gamepad = state.Gamepad;
            GamepadButtons buttons = gamepad.Buttons;

            foreach (KeyValuePair<GamepadButtons, string> item in XInputButtonDict)
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
            GamepadButtons buttons = gamepad.Buttons;

            int index = 0;

            foreach (KeyValuePair<GamepadButtons, string> item in XInputButtonDict)
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

        public static bool XInputStatesDiff(State state1, State state2)
        {
            return state1.Gamepad.Buttons != state2.Gamepad.Buttons ||
            state1.Gamepad.LeftThumbX != state2.Gamepad.LeftThumbX ||
            state1.Gamepad.RightThumbX != state2.Gamepad.RightThumbX ||
            state1.Gamepad.LeftThumbY != state2.Gamepad.LeftThumbY ||
            state1.Gamepad.RightThumbY != state2.Gamepad.RightThumbY ||
            state1.Gamepad.LeftTrigger != state2.Gamepad.LeftTrigger ||
            state1.Gamepad.RightTrigger != state2.Gamepad.RightTrigger;
        }

    }
}
