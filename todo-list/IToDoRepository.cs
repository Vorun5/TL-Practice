using todo_list.Entities;

namespace todo_list
{
    public interface IToDoRepository
    {
        ToDoEntity[] GetAll();
        ToDoEntity GetById(int id);
        void Add(ToDoEntity newEntity);

    }
}
