using Microsoft.EntityFrameworkCore;
using ToDoList.Common.CustomExceptions;
using ToDoList.Entities.Inputs;
using ToDoList.Entities.Models;

namespace ToDoList.DataAccess.Repositories
{
    public class UserRepository
    {
        private readonly ToDoListContext _context;

        public UserRepository(ToDoListContext context)
        {
            _context = context;
        }

        public async Task<User> UserExistLogin(LoginInput loginInput)
        {
            var userExist = await _context.Users.FirstOrDefaultAsync(user => user.Email == loginInput.Email && user.Password == loginInput.Password);
            if (userExist == null)
            {
                throw new AppException("Email/Password is incorrect");
            }
            return userExist;
        }

        public async Task UserRegister(RegisterInput registerInput)
        {
            var userExist = await _context.Users.FirstOrDefaultAsync(user => user.Email == registerInput.Email);
            if (userExist != null)
            {
                throw new AppException("Account Already Exists");
            }

            User newUser = new User
            {
                FirstName = registerInput.FirstName,
                LastName = registerInput.LastName,
                Email = registerInput.Email,
                BirthdayDate = registerInput.BirthdayDate,
                Password = registerInput.Password,
            };

            await _context.Users.AddAsync(newUser);
            await _context.SaveChangesAsync();
        }

        public IQueryable<User> GetUsers()
        {
            var users = _context.Users.Include(u => u.ToDos);
            return users;
        }

        public async Task<IEnumerable<User>> GetUsersByIds(IReadOnlyList<int> ids)
        {
            var users = await _context.Users.Where(u => ids.Contains(u.Id)).ToListAsync();         
            return users;
        }

        public async Task<User?> GetUser(int id)
        {
            try
            {
                var user = await _context.Users.Include(u => u.ToDos).FirstAsync(u => u.Id == id);
                return user;
            }
            catch (Exception)
            {
                throw new AppException("User Not Found");
            }
        }

        public async Task<User> AddUser(UserAddInput user)
        {
            try
            {
                var newUser = new User
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    BirthdayDate = user.BirthdayDate,
                    Password = user.Password,
                };
                await _context.AddAsync(newUser);
                await _context.SaveChangesAsync();
                return newUser;
            }
            catch(Exception)
            {
                throw new AppException("Error While Adding the User");
            }
        }

        public async Task<User> UpdateUser(UserUpdateInput user)
        {
            try
            {
                var userToUpdate = await _context.Users.FirstOrDefaultAsync(u => u.Id == user.Id);

                if(userToUpdate == null)
                {
                    throw new AppException("User doesn't exist");
                }

                if (!string.IsNullOrEmpty(user.FirstName))
                {
                    userToUpdate.FirstName = user.FirstName;
                }

                if (!string.IsNullOrEmpty(user.LastName))
                {
                    userToUpdate.LastName = user.LastName;
                }

                if (!string.IsNullOrEmpty(user.Email))
                {
                    userToUpdate.Email = user.Email;
                }

                if (user.BirthdayDate != null)
                {
                    userToUpdate.BirthdayDate = user.BirthdayDate;
                }

                if(!string.IsNullOrEmpty(user.Password)) 
                {
                    userToUpdate.Password = user.Password;
                }

                _context.Entry(userToUpdate).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return userToUpdate;
            }
            catch (Exception e)
            {
                throw new AppException(e.Message != null ? e.Message : "Error updating user");
            }
        }

        public async Task<User> DeleteUser(int id)
        {
            try
            {
                var user = await _context.Users.FindAsync(id);
                if(user == null)
                {
                    throw new AppException("User Not found");
                }

                _context.Users.Remove(user);
                await _context.SaveChangesAsync();

                return user;
            }
            catch (Exception e)
            {
                throw new AppException(e.Message != null ? e.Message : "Error deleting user");
            }
        }
    }
}
