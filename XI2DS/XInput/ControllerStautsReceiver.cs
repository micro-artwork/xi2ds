using System;


using SharpDX.XInput;

namespace XI2DS.Xinput
{
    public interface ControllerStautsReceiver
    {
        void OnStatusUpdated(int userIndex, bool isConnected, BatteryInformation information);
    }
}
