using System.Collections.ObjectModel;
using System.ComponentModel;
using BuggyTasks.Models;
using BuggyTasks.Services;

namespace BuggyTasks.ViewModels;

public class TaskListViewModel : INotifyPropertyChanged
{
    private readonly ITaskService _taskService;
    
    public ObservableCollection<TaskItem> Tasks => _taskService.Tasks;

    public TaskListViewModel(ITaskService taskService)
    {
        _taskService = taskService;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}