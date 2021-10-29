using Vortice.XInput;

namespace XI2DS.Xinput
{
    public interface IXInputStateReceiver
    {
        void OnStateUpdated(int userIndex, State state);
    }
}
