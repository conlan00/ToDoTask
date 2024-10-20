using Microsoft.AspNetCore.Mvc;

namespace ToDo.Repositories
{
    public interface ITaskRepository
    {
        Task<IEnumerable<Models.Task>> GetAllTasks();
        Task<bool> AddTask(Models.Task newTask);
        Task<Models.Task?> GetTaskById(int id);
    }
}
