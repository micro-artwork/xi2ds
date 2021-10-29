using Vortice.XInput;

namespace XI2DS.Xinput
{
    public interface IXInputStautsReceiver
    {
        void OnStatusUpdated(int userIndex, bool isConnected, BatteryInformation information);
    }
}
