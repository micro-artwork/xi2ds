using System;


using SharpDX.XInput;

namespace XI2DS.Xinput
{
    public interface XInputStateReceiver
    {
        void OnStateUpdated(int userIndex, State state);
    }
}
