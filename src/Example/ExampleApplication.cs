using System;
using Chroomsoft.Caliburn.Universal;
using Example.ViewModels;

namespace Example
{
    public class ExampleApplication : BaseApplication
    {
        protected override BaseContainer CreateContainer() => new AppContainer();
        protected override Type ShellViewModelType() => typeof(ShellViewModel);
    }
}