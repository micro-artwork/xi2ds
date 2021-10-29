using Vortice.XInput;

namespace XI2DS.Xinput
{
    public interface IXInputEventReceiver
    {
        void OnStateUpdated(int userIndex, State state);
        void OnStatusUpdated(int userIndex, bool isConnected, BatteryInformation information);
    }
}
