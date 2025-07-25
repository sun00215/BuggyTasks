using Microsoft.Maui.Controls;
using BuggyTasks.ViewModels;

namespace BuggyTasks.Views;

public partial class NewTaskPage : ContentPage
{
    public NewTaskPage(NewTaskViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }

    async void OnBackClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }
}