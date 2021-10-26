using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XI2DS.DualShock4
{
    public interface FeedBackReceiver
    {
        void OnFeedBackReceived(int userIndex, byte smallMotor, byte largeMotor);
    }
}
