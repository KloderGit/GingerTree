using Core.Domain;
using Database.Domain;
using Database.EntityFramework;
using Database.EntityFramework.Extensions;
using Microsoft.EntityFrameworkCore;
using Schedule.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SandBox
{
    class Program
    {
        static void Main(string[] args)
        {

            //var sdfsdf = new CreateAndReadDB();

            //var rrr = sdfsdf.Read();

            //var fsdf = Schedule.Domain.Schedule.Create(rrr.First() as Structure);



            var elelment1 = new Element("Personal trener") { Params = new List<Param> { new Param("Price", "1111") } };

            var elelment2 = new Element("Instructor") { Params = new List<Param> { new Param("Discount", "10") } };

            var elelment3 = new Element("Lesson") { Params = new List<Param> { new Param("During", "6") } };


            var structure1 = new Structure(elelment1);
            structure1.Params.Add(new Param("Added", "Added Value"));

            var structure2 = new Structure(elelment2);
            structure2.Children.Add(new Structure(elelment3));
            var structureDecorator = new StructureParamsDecorator(structure2);
            structureDecorator.Params.Add(new Param("Decor", "It's"));

            structure1.Children.Add(structureDecorator);
            structure1.Children.Add(structure2);



            Console.WriteLine("Hello World!");
        }
    }
}
