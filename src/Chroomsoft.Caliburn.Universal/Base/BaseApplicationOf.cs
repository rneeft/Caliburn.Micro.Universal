using System;

namespace Chroomsoft.Caliburn.Universal
{
    public abstract class BaseApplication<TContainer, TShellView> : BaseApplication where TShellView : ShellViewModelBase
        where TContainer : BaseContainer, new()
    {
        protected override BaseContainer CreateContainer() => new TContainer();

        protected override Type ShellViewModelType() => typeof(TShellView);
    }
}