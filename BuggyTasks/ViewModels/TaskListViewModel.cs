using System.Collections.ObjectModel;
using System.ComponentModel;
using BuggyTasks.Models;

namespace BuggyTasks.ViewModels;

public class TaskListViewModel : INotifyPropertyChanged
{
    public ObservableCollection<TaskItem> Tasks { get; set; }

    public TaskListViewModel()
    {
        Tasks = new ObservableCollection<TaskItem>
        {
            new TaskItem { Title = "Test Task 1" },
            new TaskItem { Title = "Test Task 2" },
            new TaskItem { Title = "Buy groceries" },
            new TaskItem { Title = "Complete project" },
            new TaskItem { Title = "Call dentist" }
        };
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}