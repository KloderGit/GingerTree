using Core.Domain.Interfaces;
using Database.Domain;
using Database.EntityFramework;
using Database.EntityFramework.Extensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SandBox
{
    class CreateAndReadDB
    {
        public IEnumerable<IComponent> Read()
        {
            var db = new ApplicationContext();

            var res = db.Structure.GetHierachy<Map>()
                .Include(x => x.Node)
                 .ThenInclude(x => x.Payloads)
                .ToList()
                .Where(x => x.ParentId == null);


            //var md = new ModelTreeBuilder(res).Build();

            return null;
        }

        public void crete()
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
            var param1 = new Payload
            {
                Name = "Type",
                Value = "Program",
                Node = node1,
                NodeId = node1.Id
            };
            var param2 = new Payload
            {
                Name = "Category",
                Value = "Education",
                Node = node1,
                NodeId = node1.Id
            };
            var param3 = new Payload
            {
                Name = "Department",
                Value = "Education Center",
                Node = node1,
                NodeId = node1.Id
            };
            var param4 = new Payload
            {
                Name = "Price",
                Value = "58000",
                Node = node1,
                NodeId = node1.Id
            };
            node1.Payloads = new List<Payload>() { param1, param2, param3, param4 };

            var map1 = new Map()
            {
                Node = node1,
                NodeId = node1.Id,
            };

            var param5 = new Payload
            {
                Name = "Place",
                Value = "Added param",
                Map = map1,
                MapId = map1.Id,
                Node = node1,
                NodeId = node1.Id
            };

            var param6 = new Payload
            {
                Name = "Type",
                Value = "Program Block",
                Map = map1,
                MapId = map1.Id,
                Node = node1,
                NodeId = node1.Id
            };

            map1.Payloads = new List<Payload> { param5, param6, param2, param4 };



            var node2 = new Node
            {
                IsActive = true,
                IsDraft = false,
                Key = Guid.NewGuid(),
                Title = "Instructor",
                Created = DateTimeOffset.Now,
                Modified = DateTimeOffset.Now
            };
            var param21 = new Payload
            {
                Name = "Type",
                Value = "Program",
                Node = node2,
                NodeId = node2.Id
            };
            var param22 = new Payload
            {
                Name = "Category",
                Value = "Practic",
                Node = node2,
                NodeId = node2.Id
            };
            var param23 = new Payload
            {
                Name = "Format",
                Value = "Short",
                Node = node2,
                NodeId = node2.Id
            };
            var param24 = new Payload
            {
                Name = "Price",
                Value = "6300",
                Node = node2,
                NodeId = node2.Id
            };
            node2.Payloads = new List<Payload>() { param21, param22, param23, param24 };

            var map21 = new Map()
            {
                Node = node2,
                NodeId = node2.Id,
            };

            var param25 = new Payload
            {
                Name = "Attestation",
                Value = "Test",
                Map = map21,
                MapId = map21.Id,
                Node = node2,
                NodeId = node2.Id
            };

            var param26 = new Payload
            {
                Name = "Price",
                Value = "14000",
                Map = map21,
                MapId = map21.Id,
                Node = node2,
                NodeId = node2.Id
            };

            map21.Payloads = new List<Payload> { param25, param26, param23, param22, param21 };

            map1.Children.Add(map21);


            var db = new ApplicationContext();

            db.Structure.Add(map1);

            db.SaveChanges();



        }
    }
}
