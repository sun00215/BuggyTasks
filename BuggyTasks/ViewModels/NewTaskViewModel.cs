using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using BuggyTasks.Services;

namespace BuggyTasks.ViewModels;

public class NewTaskViewModel: INotifyPropertyChanged
{
    private readonly ITaskService _taskService;
    private string _newTaskTitle = string.Empty;

    public string NewTaskTitle
    {
        get => _newTaskTitle;
        set
        {
            _newTaskTitle = value;
            OnPropertyChanged();
        }
    }

    public ICommand AddNewTaskCommand { get; }

    public NewTaskViewModel(ITaskService taskService)
    {
        _taskService = taskService;
        AddNewTaskCommand = new Command(async () => await OnAddTaskAsync());
    }

    async Task OnAddTaskAsync()
    {
        if (string.IsNullOrWhiteSpace(NewTaskTitle))
        {
            await Application.Current.MainPage.DisplayAlert("Error", "Please enter a task title", "OK");
            return;
        }

       
        _taskService.AddTask(NewTaskTitle);
        
       
        await Application.Current.MainPage.DisplayAlert("Success", $"Task '{NewTaskTitle}' added successfully!", "OK");
        
       
        NewTaskTitle = string.Empty;
        
    
        await Shell.Current.GoToAsync("..");
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}