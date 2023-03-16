using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Entities.Models;

namespace ToDoList.DataAccess
{
    public class ToDoListContext : DbContext
    {
        public ToDoListContext(DbContextOptions<ToDoListContext> options) : base(options)
        { }

        public DbSet<User> Users { get; set; }
        public DbSet<ToDo> ToDos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasIndex(u => u.Email).IsUnique();
            var newUsers = new List<User>
            {
                new User { 
                    Id = 1,
                    FirstName = "Hamdi",
                    LastName = "Bali",
                    Email = "hamdi@gmail.com",
                    BirthdayDate = DateTime.Now,
                },
                new User {
                    Id = 2,
                    FirstName = "Mahdi",
                    LastName = "Bougriba",
                    Email = "mahdi@gmail.com",
                    BirthdayDate = DateTime.Now,
                },
                new User {
                    Id = 3,
                    FirstName = "Ilyes",
                    LastName = "Helal",
                    Email = "ilyes@gmail.com",
                    BirthdayDate = DateTime.Now,
                },
                new User {
                    Id = 4,
                    FirstName = "Rayen",
                    LastName = "Zebi",
                    Email = "rayen@gmail.com",
                    BirthdayDate = DateTime.Now,
                },
            };
            modelBuilder.Entity<User>().HasData(newUsers);

            var toDos = new List<ToDo> { 
                new ToDo { 
                    Id = 1,
                    Content = "lezimni ntayah el sabouna",
                    IsDone = true,
                    UserId = 1
                },
                new ToDo {
                    Id = 2,
                    Content = "bech nrakah el live chat",
                    IsDone = false,
                    UserId = 1
                },
                new ToDo {
                    Id = 3,
                    Content = "nwali rajel",
                    IsDone = false,
                    UserId = 2
                },
                new ToDo {
                    Id = 4,
                    Content = "niklek omk",
                    IsDone = true,
                    UserId = 3
                }
            };
            modelBuilder.Entity<ToDo>().HasData(toDos);
        }
    }
}
