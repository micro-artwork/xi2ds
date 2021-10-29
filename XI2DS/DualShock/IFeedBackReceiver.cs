namespace XI2DS.DualShock4
{
    public interface IFeedBackReceiver
    {
        void OnFeedBackReceived(int userIndex, byte smallMotor, byte largeMotor);
    }
}
