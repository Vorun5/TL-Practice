using System.Linq;
using todo_list.DbInfrastructure;
using todo_list.Entities;

namespace todo_list
{
    public class ToDoRepository : IToDoRepository
    {
        private ToDoDbContext _context;

        public ToDoRepository(ToDoDbContext context)
        {
            _context = context;
        }

        public ToDoEntity[] GetAll()
        {
            return _context.Set<ToDoEntity>().ToArray();
        }

        public ToDoEntity GetById(int id)
        {
            return _context.Set<ToDoEntity>().FirstOrDefault(item => item.Id == id);
        }

        public void Add(ToDoEntity newEntity)
        {
            _context.Set<ToDoEntity>().Add(newEntity);
        }
    }
}
