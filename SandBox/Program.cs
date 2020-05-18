using Core.Domain;
using Core.Domain.Interfaces;
using System;
using System.Collections.Generic;

namespace SandBox
{
    class Program
    {
        static void Main(string[] args)
        {
            var module = new Module
            {
                Id = 123,
                IsActive = true,
                IsDraft = false,
                Key = Guid.NewGuid(),
                Order = 1,
                Parent = null,
                Title = "Personal Trener",
                Children = new List<IComponent>()
            };


            var item = new Element
            {
                Id = 34534534,
                IsActive = true,
                IsDraft = false,
                Key = Guid.NewGuid(),
                Order = 1,
                Parent = module,
                Title = "for Person trener"
            };

            module.Children.Add(item);


            var module2 = new Module
            {
                Id = 333,
                IsActive = true,
                IsDraft = false,
                Key = Guid.NewGuid(),
                Order = 1,
                Parent = module,
                Title = "Instructor",
                Children = new List<IComponent>()
            };

            module.Children.Add(module2);

            var item2 = new Element
            {
                Id = 75673,
                IsActive = true,
                IsDraft = false,
                Key = Guid.NewGuid(),
                Order = 1,
                Parent = module2,
                Title = "for Instructor"
            };

            module2.Children.Add(item2);

            Console.WriteLine("Hello World!");
        }
    }
}
