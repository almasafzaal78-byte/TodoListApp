using SQLite;
using TodoListApp.Models;

namespace TodoListApp.Services;

public class TaskService
{
    private SQLiteAsyncConnection? _database;

    private async Task Init()
    {
        if (_database is not null)
            return;

        var dbPath = Path.Combine(FileSystem.AppDataDirectory, "tasks.db3");
        _database = new SQLiteAsyncConnection(dbPath);
        await _database.CreateTableAsync<TaskItem>();
    }

    public async Task<List<TaskItem>> GetTasksAsync()
    {
        await Init();
        return await _database!.Table<TaskItem>().ToListAsync();
    }

    public async Task<int> AddTaskAsync(TaskItem task)
    {
        await Init();
        return await _database!.InsertAsync(task);
    }

    public async Task<int> UpdateTaskAsync(TaskItem task)
    {
        await Init();
        return await _database!.UpdateAsync(task);
    }

    public async Task<int> DeleteTaskAsync(TaskItem task)
    {
        await Init();
        return await _database!.DeleteAsync(task);
    }
}