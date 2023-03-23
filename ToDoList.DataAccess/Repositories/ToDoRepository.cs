using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ToDoList.Common.CustomExceptions;
using ToDoList.Entities.Inputs;
using ToDoList.Entities.Models;

namespace ToDoList.DataAccess.Repositories
{
    public class ToDoRepository
    {
        private readonly ToDoListContext _context;

        public ToDoRepository(ToDoListContext context)
        {
            _context = context;
        }

        public IQueryable<ToDo> GetToDos()
        {
            return _context.ToDos.Include(todo => todo.User);
        }

        public async Task<ToDo?> GetToDo(int id)
        {
            try
            {
                var todo = await _context.ToDos.Include(todo => todo.User).FirstAsync(todo => todo.Id == id);
                return todo;
            }
            catch (Exception)
            {
                throw new AppException("ToDo Not Found");
            }
        }

        public async Task<ToDo> AddToDo(ToDoAddInput toDo)
        {
            try
            {
                var newToDo = new ToDo
                {
                    Content= toDo.Content,
                    UserId = toDo.UserId,
                };
                await _context.ToDos.AddAsync(newToDo);
                await _context.SaveChangesAsync();
                return newToDo;
            }
            catch (Exception)
            {
                throw new AppException("Error While Adding the ToDo");
            }
        }

        public async Task<string> UpdateToDo(ToDoUpdateInput toDo)
        {
            try
            {
                var toDoToUpdate = await _context.ToDos.FirstOrDefaultAsync(u => u.Id == toDo.Id);

                if (toDoToUpdate == null)
                {
                    throw new AppException("ToDo doesn't exist");
                }

                if (!string.IsNullOrEmpty(toDo.Content))
                {
                    toDoToUpdate.Content = toDo.Content;
                }

                toDoToUpdate.IsDone = toDo.IsDone;

                if (toDo.UserId > 0)
                {
                    toDoToUpdate.UserId = toDo.UserId;
                }

                _context.Entry(toDoToUpdate).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return "ToDo Edited";
            }
            catch (Exception e)
            {
                throw new AppException(e.Message != null ? e.Message : "Error updating ToDo");
            }
        }

        public async Task<string> DeleteToDo(int id)
        {
            try
            {
                var toDo = await _context.ToDos.FindAsync(id);
                if (toDo == null)
                {
                    throw new AppException("ToDo Not found");
                }

                _context.ToDos.Remove(toDo);
                await _context.SaveChangesAsync();

                return "ToDo Deleted";
            }
            catch (Exception e)
            {
                throw new AppException(e.Message != null ? e.Message : "Error deleting ToDo");
            }
        }
    }
}
