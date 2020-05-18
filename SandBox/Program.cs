using Database.Domain;
using Database.EntityFramework;
using System;

namespace SandBox
{
    class Program
    {
        static void Main(string[] args)
        {
            var node1 = new Node
            {
                IsActive = true,
                IsDraft = false,
                Key = Guid.NewGuid(),
                Title = "Personal trener",
                Created = DateTimeOffset.Now,
                Modified = DateTimeOffset.Now
            };

            var node2 = new Node
            {
                IsActive = true,
                IsDraft = false,
                Key = Guid.NewGuid(),
                Title = "Instructor",
                Created = DateTimeOffset.Now,
                Modified = DateTimeOffset.Now
            };

            var node3 = new Node
            {
                IsActive = true,
                IsDraft = false,
                Key = Guid.NewGuid(),
                Title = "Anatomy",
                Created = DateTimeOffset.Now,
                Modified = DateTimeOffset.Now
            };

            var node4 = new Node
            {
                IsActive = true,
                IsDraft = false,
                Key = Guid.NewGuid(),
                Title = "Fiziology",
                Created = DateTimeOffset.Now,
                Modified = DateTimeOffset.Now
            };

            var node5 = new Node
            {
                IsActive = true,
                IsDraft = false,
                Key = Guid.NewGuid(),
                Title = "Attestation",
                Created = DateTimeOffset.Now,
                Modified = DateTimeOffset.Now
            };


            var map1 = new Map()
            {
                Order = 1,
                Node = node1,
                NodeId = node1.Id,
                Created = DateTimeOffset.Now,
                Modified = DateTimeOffset.Now
            };



            var map2 = new Map()
            {
                Order = 1,
                Node = node2,
                NodeId = node2.Id,
                Created = DateTimeOffset.Now,
                Modified = DateTimeOffset.Now
            };
            map1.Children.Add(map2);

            var map3 = new Map()
            {
                Order = 1,
                Node = node3,
                NodeId = node3.Id,
                Created = DateTimeOffset.Now,
                Modified = DateTimeOffset.Now
            };
            map2.Children.Add(map3);

            var map4 = new Map()
            {
                Order = 1,
                Node = node4,
                NodeId = node4.Id,
                Parent = map2,
                Created = DateTimeOffset.Now,
                Modified = DateTimeOffset.Now
            };
            map2.Children.Add(map4);

            var map5 = new Map()
            {
                Order = 1,
                Node = node5,
                NodeId = node5.Id,
                Parent = map1,
                Created = DateTimeOffset.Now,
                Modified = DateTimeOffset.Now
            };
            map1.Children.Add(map5);


            var db = new ApplicationContext();

            db.Structure.Add(map1);

            //db.SaveChanges();


            Console.WriteLine("Hello World!");
        }
    }
}
