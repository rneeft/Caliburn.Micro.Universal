namespace Chroomsoft.Caliburn.Universal
{
    public class ViewModelParameterChangedMessage
    {
        public ViewModelParameterChangedMessage(object newValue)
        {
            NewValue = newValue;
        }

        public object NewValue { get; }
    }
}