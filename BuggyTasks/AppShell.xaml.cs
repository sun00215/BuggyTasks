using Microsoft.Maui.Controls;

namespace BuggyTasks;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        // Only one routes registered, you may have more to add
        Routing.RegisterRoute("NewTaskPage", typeof(Views.NewTaskPage));
        Routing.RegisterRoute("tasklist", typeof(Views.TaskListPage));
        Routing.RegisterRoute("DeviceInfoPage", typeof(Views.DeviceInfoPage));
        Routing.RegisterRoute("LocationPage", typeof(Views.LocationPage));
    }
}