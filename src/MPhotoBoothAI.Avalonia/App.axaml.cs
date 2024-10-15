using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Microsoft.Extensions.DependencyInjection;
using MPhotoBoothAI.Application.Interfaces;
using MPhotoBoothAI.Application.ViewModels;
using MPhotoBoothAI.Avalonia.Views;
using System;
using System.Globalization;
using System.Threading;
using AvaloniaApplication = Avalonia.Application;
namespace MPhotoBoothAI.Avalonia;

public partial class App : AvaloniaApplication
{
    public static IServiceProvider? ServiceProvider { get; private set; }

    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    protected virtual IServiceProvider ConfigureServiceProvider()
    {
        var serviceCollection = new ServiceCollection();
        serviceCollection.Configure();
        return serviceCollection.BuildServiceProvider();
    }

    public override void OnFrameworkInitializationCompleted()
    {
        ServiceProvider = ConfigureServiceProvider();
        SetApplicationLanguage(ServiceProvider.GetRequiredService<IUserSettings>());
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = new MainWindow
            {
                DataContext = ServiceProvider.GetRequiredService<MainViewModel>()
            };
        }

        base.OnFrameworkInitializationCompleted();
    }

    private static void SetApplicationLanguage(IUserSettings userSettings)
    {
        if (string.IsNullOrEmpty(userSettings.CultureInfoName))
        {
            userSettings.CultureInfoName = Thread.CurrentThread.CurrentUICulture.Name;
        }
        Thread.CurrentThread.CurrentUICulture = new CultureInfo(userSettings.CultureInfoName);
    }
}