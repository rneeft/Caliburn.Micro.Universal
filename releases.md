# Releases
## Release 1.5
- New method in the `ViewModelBase<T>` for updates to the parameter. When navigating with `NavigationProvider.NavigateTo<TViewModel>(parameter)` but TViewModel is already the active ViewModel then the abstract method `OnParameterUpdate(string newValue)` is called. 
- Example is greatly improved