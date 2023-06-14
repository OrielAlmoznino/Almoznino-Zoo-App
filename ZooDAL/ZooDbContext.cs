using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooDAL.Entities;

namespace ZooDAL
{
    public class ZooDbContext : DbContext
    {
        public ZooDbContext(DbContextOptions options) : base(options) { }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Animal> Animals { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var Birds = new Category { Id = Guid.NewGuid(), Name = "Birds" };
            var Monkeys = new Category { Id = Guid.NewGuid(), Name = "Monkeys" };
            var Cats = new Category { Id = Guid.NewGuid(), Name = "Cats" };

            modelBuilder.Entity<Category>().HasData(Birds, Monkeys, Cats);

            var Penguin = new Animal { Id = Guid.NewGuid(), Name = "Penguin", Age = 2, Description = "Penguin description", CategoryID = Birds.Id, ImagePath = "10b02f99-82cb-45a2-9f6f-9ff5b93aecfa.jpg" };
            var Parrot = new Animal { Id = Guid.NewGuid(), Name = "Parrot", Age = 5, Description = "Parrot description", CategoryID = Birds.Id, ImagePath = "a0b05188-fb1b-4409-8308-2a3e24d4ca9e.jpg" };
            var Eagle = new Animal { Id = Guid.NewGuid(), Name = "Eagle", Age = 3, Description = "Eagle description", CategoryID = Birds.Id, ImagePath = "4eb9ea13-b0c3-4144-be0c-0d1eff68aa7b.jpg" };

            var Chimpanzee = new Animal { Id = Guid.NewGuid(), Name = "Chimpanzee", Age = 8, Description = "Chimpanzee description", CategoryID = Monkeys.Id, ImagePath = "475027aa-44ba-4ce3-8a75-b3c261599b0d.jpg" };
            var Gorilla = new Animal { Id = Guid.NewGuid(), Name = "Gorilla", Age = 12, Description = "Gorilla description", CategoryID = Monkeys.Id, ImagePath = "7741d954-515d-4222-a66b-d8f23273ea2c.jpg" };
            var Orangutan = new Animal { Id = Guid.NewGuid(), Name = "Orangutan", Age = 10, Description = "Orangutan description", CategoryID = Monkeys.Id, ImagePath = "0ed86487-a07f-4c21-8fb8-3751215bef68.jpg" };

            var Lion = new Animal { Id = Guid.NewGuid(), Name = "Lion", Age = 4, Description = "Lion description", CategoryID = Cats.Id, ImagePath = "2021be47-0f90-4053-bb1a-d939bde5bc7f.jpg" };
            var Cheetah = new Animal { Id = Guid.NewGuid(), Name = "Cheetah", Age = 6, Description = "Cheetah description", CategoryID = Cats.Id, ImagePath = "433a2c09-520b-48c1-a7bc-1e6b9c62ba12.jpg" };
            var Tiger = new Animal { Id = Guid.NewGuid(), Name = "Tiger", Age = 7, Description = "Tiger description", CategoryID = Cats.Id, ImagePath = "d15b6b92-391b-43ea-a55f-31e8f4cd163f.jpg" };

            modelBuilder.Entity<Animal>().HasData(Parrot, Eagle, Chimpanzee, Gorilla, Orangutan, Lion, Cheetah, Tiger);

            var comment1 = new Comment { Id = Guid.NewGuid(), AnimalID = Lion.Id, Content = "This lion is amazing!" };
            var comment2 = new Comment { Id = Guid.NewGuid(), AnimalID = Lion.Id, Content = "The lion's majestic beauty is breathtaking!" };
            var comment3 = new Comment { Id = Guid.NewGuid(), AnimalID = Lion.Id, Content = "I'm in awe of this incredible lion!" };
            var comment4 = new Comment { Id = Guid.NewGuid(), AnimalID = Eagle.Id, Content = "The eagle is soaring through the sky with grace!" };
            var comment5 = new Comment { Id = Guid.NewGuid(), AnimalID = Penguin.Id, Content = "The penguin waddles with cuteness!" };
            var comment6 = new Comment { Id = Guid.NewGuid(), AnimalID = Penguin.Id, Content = "The penguin's sleek feathers are mesmerizing!" };
            var comment7 = new Comment { Id = Guid.NewGuid(), AnimalID = Gorilla.Id, Content = "The gorilla's strength is awe-inspiring!" };
            var comment8 = new Comment { Id = Guid.NewGuid(), AnimalID = Gorilla.Id, Content = "The gorilla's intelligence shines through!" };
            var comment9 = new Comment { Id = Guid.NewGuid(), AnimalID = Gorilla.Id, Content = "The gorilla's gentle nature is heartwarming!" };
            var comment10 = new Comment { Id = Guid.NewGuid(), AnimalID = Gorilla.Id, Content = "The gorilla's interactions with its family are fascinating!" };
            var comment11 = new Comment { Id = Guid.NewGuid(), AnimalID = Gorilla.Id, Content = "The gorilla's expressive eyes captivate everyone!" };

            modelBuilder.Entity<Comment>().HasData(
                comment1, comment2, comment3, comment4, comment5, comment6, comment7, comment8, comment9, comment10, comment11);

        }


    }
}
