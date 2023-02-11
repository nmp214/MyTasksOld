using myTasks.Models;
using System.Collections;
using System.Linq;

namespace myTasks.Controllers
{
    public static class TaskService
    {
        private static List<MyTask> tasks = new List<MyTask>
        {
            new MyTask { Id = 1, name = "wash dishes", isDone = true },
            new MyTask { Id = 2, name = "go to the bank", isDone = false }
        };

        public static List<MyTask> GetAll() => tasks;
        public static MyTask Get(int id)
        {
            return tasks.FirstOrDefault(t => t.Id == id);
        }

        public static void Add(MyTask task)
        {
            task.Id = tasks.Max(t => t.Id) + 1;
            tasks.Add(task);
        }

        public static bool Update(int id, MyTask newTask)
        {
            if (newTask.Id != id)
                return false;
            
            var task = tasks.FirstOrDefault(t => t.Id == id);
            task.name = newTask.name;
            task.isDone = newTask.isDone;
            return true;
        }

        public static bool Delete(int id)
        {
            var task = tasks.FirstOrDefault(t => t.Id == id);
            if (task == null)
                return false;
            tasks.Remove(task);
            return true;
        }


    }
}