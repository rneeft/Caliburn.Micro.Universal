# Releases

## Release 1.6
- In the container the default `null`, used for the key in the SimpleContainer, is replace by a virtual property `DefaultContainerKey`. Out of the box it still returns `null` but now it can be retrieved and override in your Application.

## Release 1.5
- New method in the `ViewModelBase<T>` for updates to the parameter. When navigating with `NavigationProvider.NavigateTo<TViewModel>(parameter)` but TViewModel is already the active ViewModel then the abstract method `OnParameterUpdate(string newValue)` is called. 
- Example is greatly improved