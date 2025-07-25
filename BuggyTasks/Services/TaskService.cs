using System.Collections.ObjectModel;
using BuggyTasks.Models;

namespace BuggyTasks.Services;

public interface ITaskService
{
    ObservableCollection<TaskItem> Tasks { get; }
    void AddTask(string title);
    event EventHandler<TaskItem> TaskAdded;
}

public class TaskService: ITaskService
{
    public ObservableCollection<TaskItem> Tasks { get; private set; }
    
    public event EventHandler<TaskItem>? TaskAdded;

    public TaskService()
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

    public void AddTask(string title)
    {
        if (string.IsNullOrWhiteSpace(title))
            return;

        var newTask = new TaskItem { Title = title };
        Tasks.Add(newTask);
        TaskAdded?.Invoke(this, newTask);
    }
}