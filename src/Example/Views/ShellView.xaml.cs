using Chroomsoft.Caliburn.Universal;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Example.Views
{
    public sealed partial class ShellView : Page
    {
        public ShellView()
        {
            this.InitializeComponent();
        }

        private void OnFrameLoaded(object sender, RoutedEventArgs e)
        {
            ((ShellViewModelBase)this.DataContext).SetupNavigationService((Frame)sender);
        }
    }
}
