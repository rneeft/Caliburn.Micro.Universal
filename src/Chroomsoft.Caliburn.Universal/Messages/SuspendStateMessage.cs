using Windows.ApplicationModel;

namespace Chroomsoft.Caliburn.Universal.Messages
{
    public class SuspendStateMessage
    {
        public SuspendStateMessage(SuspendingOperation operation)
        {
            Operation = operation;
        }

        public SuspendingOperation Operation { get; }
    }
}
