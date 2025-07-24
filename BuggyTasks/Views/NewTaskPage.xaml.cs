using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Maui.Controls;

namespace BuggyTasks.Views;

public partial class NewTaskPage : ContentPage
{
    public NewTaskPage()
    {
        InitializeComponent();
    }

    async void OnBackClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }
}