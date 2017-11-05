using System;
using System.Collections.Generic;
using Caliburn.Micro;

namespace Chroomsoft.Caliburn.Universal
{
    public class NavigationProvider : INavigationProvider
    {
        private INavigationService navigationService;
        private readonly List<System.Action> beforeNavigationActiveActions = new List<System.Action>();

        public INavigationService NavigationService
        {
            private get { return navigationService; }
            set
            {
                navigationService = value;
                ExecuteNavigationServiceCommands();
            }
        }

        public Type FirstViewModel { get; set; }

        public void NavigateTo<TViewModel>(object parameter = null) where TViewModel : ViewModelBase
        {
            ExecuteNavigationWhenServiceIsActive(() =>
            {
                if (IsActiveScreenTypeOf<TViewModel>())
                    return;

                NavigateToScreen<TViewModel>(parameter);

                if (NavigatedToFirstViewModel<TViewModel>())
                    navigationService.BackStack.Clear();
            });
        }

        public bool IsActiveScreenTypeOf<TViewModel>() where TViewModel : Screen
        {
            if (navigationService.CurrentSourcePageType == null)
                return false;

            var newView = typeof(TViewModel).FullName.Replace("Model", "");
            var currentView = navigationService.CurrentSourcePageType.FullName;

            return newView == currentView;
        }

        public void SuspendNavigationServiceState()
        {
            ExecuteNavigationWhenServiceIsActive(() => { NavigationService.SuspendState(); });
        }

        public void ResumeNavigationServiceState()
        {
            ExecuteNavigationWhenServiceIsActive(() => { NavigationService.ResumeState(); });
        }

        public void GoBack()
        {
            NavigationService.GoBack();
        }

        private void ExecuteNavigationServiceCommands()
        {
            foreach (var command in beforeNavigationActiveActions)
                command();

            beforeNavigationActiveActions.Clear();
        }

        public void SetNavigationService(INavigationService service)
        {
            navigationService = service;
            ExecuteNavigationServiceCommands();
        }

        private bool NavigatedToFirstViewModel<TViewModel>() where TViewModel : ViewModelBase
        {
            return FirstViewModel != null && FirstViewModel is TViewModel;
        }

        private void NavigateToScreen<TViewModel>(object parameter = null)
        {
            var newScreenType = typeof(TViewModel);
            var backState = NavigationService.CurrentSourcePageType;

            NavigationService.NavigateToViewModel<TViewModel>(parameter);
        }

        private void ExecuteNavigationWhenServiceIsActive(System.Action action)
        {
            if (NavigationService == null)
                beforeNavigationActiveActions.Add(action);
            else
                action();
        }
    }
}
