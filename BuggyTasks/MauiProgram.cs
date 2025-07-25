using Microsoft.Extensions.Logging;
using BuggyTasks.Services;
using BuggyTasks.ViewModels;
using BuggyTasks.Views;

namespace BuggyTasks;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

     
        builder.Services.AddSingleton<ITaskService, TaskService>();
        
    
        builder.Services.AddTransient<NewTaskViewModel>();
        builder.Services.AddTransient<TaskListViewModel>();
      
        builder.Services.AddTransient<MainPage>();
        builder.Services.AddTransient<NewTaskPage>();
        builder.Services.AddTransient<TaskListPage>();
        builder.Services.AddTransient<DeviceInfoPage>();
        builder.Services.AddTransient<LocationPage>();

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}