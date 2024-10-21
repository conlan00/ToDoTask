
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDo.Data;

namespace ToDo.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly DataDbContext _dbContext;
        //dependency injection
        public TaskRepository(DataDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        // add Task to do 
        public async Task<bool> AddTask(Models.Task newTask)
        {
            var isExistingTask = await _dbContext.Task.AnyAsync(i => i.Id == newTask.Id);
            //add task if not exist
            if (!isExistingTask)
            {
                // id is set as autoincrement so i dont have process id 

                //add task to MariaDB using database instance
                _dbContext.Task.Add(newTask);
                //save changes
                await _dbContext.SaveChangesAsync();
                //return true if operation done
                return true;
            }
            else
            {
                //task exist
                return false;
            }
        }
        // get all tasks to do 
        public async Task<IEnumerable<Models.Task>> GetAllTasks()
        {
            return await _dbContext.Task.ToListAsync();
        }
        //get task by Id
        public async Task<Models.Task?> GetTaskById(int id)
        {
            
            return await _dbContext.Task.FindAsync(id);
        }
        //delete task by id 
        public async Task<bool> DeleteTask(int id)
        {
            //find element in db 
            var isExistingTask = await _dbContext.Task.FindAsync(id);
            //if exist 
            if(isExistingTask!=null)
            {
                _dbContext.Task.Remove(isExistingTask);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }
        //update task
        public async Task<bool> UpdateTask(Models.Task model)
        {
            _dbContext.Task.Update(model);
            await _dbContext.SaveChangesAsync();
            return true;
        }
        //get incoming to do for today 
        public async Task<List<Models.Task>> GetTaskForToday()
        {
            var today = DateTime.Today;
            //using Orm to get task using Date
            return await _dbContext.Task
                .Where(i => i.ExpiryDateTime.Date == today)
                .ToListAsync();
        }
        

    }
}
