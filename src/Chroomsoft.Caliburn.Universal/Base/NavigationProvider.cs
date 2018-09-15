using System;
using System.Collections.Generic;
using Caliburn.Micro;

namespace Chroomsoft.Caliburn.Universal
{
    public class NavigationProvider : INavigationProvider
    {
        private readonly List<System.Action> beforeNavigationActiveActions = new List<System.Action>();
        private readonly IEventAggregator eventAggregator;

        public NavigationProvider(IEventAggregator eventAggregator)
        {
            this.eventAggregator = eventAggregator;
        }

        public INavigationService NavigationService { get; private set; }

        public Type FirstViewModel { get; set; }

        public void NavigateTo<TViewModel>(object parameter = null) where TViewModel : ViewModelBase
        {
            ExecuteNavigationWhenServiceIsActive(() =>
            {
                if (IsActiveScreenTypeOf<TViewModel>())
                {
                    if (parameter != null)
                        eventAggregator.PublishOnUIThread(new ViewModelParameterChangedMessage(parameter));
                }
                else
                {
                    NavigateToScreen<TViewModel>(parameter);

                    if (NavigatedToFirstViewModel<TViewModel>())
                        NavigationService.BackStack.Clear();
                }
            });
        }

        public bool IsActiveScreenTypeOf<TViewModel>() where TViewModel : Screen
        {
            if (NavigationService.CurrentSourcePageType == null)
                return false;

            var newView = typeof(TViewModel).FullName.Replace("Model", string.Empty);
            var currentView = NavigationService.CurrentSourcePageType.FullName;

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

        public void SetNavigationService(INavigationService service)
        {
            NavigationService = service;
            ExecuteNavigationServiceCommands();
        }

        private void ExecuteNavigationServiceCommands()
        {
            foreach (var command in beforeNavigationActiveActions)
                command();

            beforeNavigationActiveActions.Clear();
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