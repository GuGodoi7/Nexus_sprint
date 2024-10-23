using _NEXUS.Models;
using _NEXUS.Repository.Interfaces;
using MongoDB.Bson;

namespace Nexus.UseCase
{
    public class UsuarioUseCase
    {
        private readonly IUsuarioRepository<UsuarioModel> _taskRepository;

        public UsuarioUseCase(IUsuarioRepository<UsuarioModel> taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public IEnumerable<Task> GetAllTasks()
        {
            return _taskRepository.GetAll();
        }

        public Task GetTaskById(string id)
        {
            return _taskRepository.GetById(id);
        }

        public void AddTask(Task task)
        {
            if (string.IsNullOrEmpty(task.Id))
            {
                task.Id = ObjectId.GenerateNewId().ToString();
            }

            _taskRepository.Add(task);
        }

        public void UpdateTask(Task task)
        {
            _taskRepository.Update(task);
        }

        public void DeleteTask(string id)
        {
            _taskRepository.Delete(id);
        }
    }
}
