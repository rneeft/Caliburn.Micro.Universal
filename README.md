# Caliburn Universal Base
A base library for creating universal application with Caliburn Micro. 
![Build Status](https://chr.visualstudio.com/_apis/public/build/definitions/2d33193a-77fd-4ddc-be87-12c73bc5ff99/21/badge)
## How to install
`Install-Package Chroomsoft.Caliburn.Micro.Universal`

[NuGet.org](https://www.nuget.org/packages/Chroomsoft.Caliburn.Micro.Universal/)

## How to use

To use this library follow the following steps:
- Create a Universal Application
- Add Nuget package: Chroomsoft.Caliburn.Micro.Universal
- Add Two folder: Views, ViewModels
- Add a class and name it <Product>Container. Replace it with the following code:
```csharp
using Chroomsoft.Caliburn.Universal.Base;
using Example.ViewModels;

namespace Example
{
    public class AppContainer : BaseContainer
    {
        public override void RegisterApplicationComponents()
        {
        }

        public override void RegisterOtherViewModels()
        {
            this.RegisterViewModel<MainViewModel>();
        }
    }
}
```
- Add a class and name it <Product>Application. Replace it with the following code:
```csharp
using System;
using Chroomsoft.Caliburn.Universal.Base;
using Example.ViewModels;

namespace Example
{
    public class <Product>Application : BaseApplication
    {
        protected override BaseContainer CreateContainer() => new AppContainer();
        protected override Type ShellViewModelType() => typeof(ShellViewModel);
    }
}
```
- Create a ShellViewModel class in the ViewModels folder and replace the code with the following:
```csharp
using Chroomsoft.Caliburn.Universal.Base;
using Chroomsoft.Caliburn.Universal.ViewModels;

namespace Example.ViewModels
{
    public class ShellViewModel : ShellViewModelBase
    {
        public ShellViewModel(IRegisterNavigationFrame registerNavigation) : base(registerNavigation) { }
    }
}
```
- Create a MainViewModel class in the ViewModels folder and replace the code with the following:
```csharp
using Chroomsoft.Caliburn.Universal.ViewModels;

namespace Example.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
    }
}
```
- Create a Blank Page item (name it ShellView) in the views folder and replace the xaml with the following
```xaml
<Page
    x:Class="Example.Views.ShellView"
    xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
    xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
    xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
    xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
    mc:Ignorable="d">

    <Grid Background="{ThemeResource ApplicationPageBackgroundThemeBrush}">
        <Grid.RowDefinitions>
            <RowDefinition Height="Auto" />
            <RowDefinition Height="*" />
        </Grid.RowDefinitions>
        <Button x:Name="ShowMain" Content="Show MainView" HorizontalAlignment="Center" />
        <Frame x:Name="frame" Loaded="OnFrameLoaded" DataContext="{x:Null}" Grid.Row="1" />
    </Grid>
</Page>
```
- And the code behind with: 
```csharp
using Chroomsoft.Caliburn.Universal.Base;
using Chroomsoft.Caliburn.Universal.ViewModels;

namespace Example.ViewModels
{
    public class ShellViewModel : ShellViewModelBase
    {
        public ShellViewModel(IRegisterNavigationFrame registerNavigation) : base(registerNavigation) { }

        public void ShowMain()
        {
            NavigationProvider.NavigateTo<MainViewModel>();
        }
    }
}
```
- Create a Blank Page item (name it MainView) in the views folde.
- Change the background colour of the Grid into Red
- Build the project
- Replace the code from the App.Xaml file with
```xaml
<local:<Product>Application
    x:Class="Example.App"
    xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
    xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
    xmlns:cm="using:Caliburn.Micro"
    xmlns:c="using:Chroomsoft.Caliburn.Universal.Converters"
    xmlns:local="using:Example">
    <local:<Product>Application.Resources>
        <ResourceDictionary>
            <cm:BooleanToVisibilityConverter x:Key="BooleanToVisibilityConverter" />
            <c:InvertedBooleanToVisibilityConverter x:Key="InvertedBooleanToVisibilityConverter" />
        </ResourceDictionary>
    </local:<Product>Application.Resources>
</local:<Product>Application>
```
- Replace the code from the App.xaml.cs file with
```csharp
namespace Example
{
    public sealed partial class App : <Product>Application
    {
        public App()
        {
            Initialize();
        }
    }
}
```
- Delete MainPage.xaml in de Root folder
- Start the application