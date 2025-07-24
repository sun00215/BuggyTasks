using Microsoft.Maui.Controls;

namespace BuggyTasks.Views;

public partial class TaskListPage : ContentPage
{
    public TaskListPage()
    {
        InitializeComponent();
    }

    async void OnBackClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }
}