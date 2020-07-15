//using Core.Domain;
//using Core.Domain.Interfaces;
//using Database.Domain.Interfaces;
//using System.Collections.Generic;
//using System.Linq;

//namespace Database.Domain
//{
//    public class ModelTreeBuilder : ITreeBuilder<IComponent>
//    {
//        IEnumerable<Map> maps;

//        ICollection<Element> elements = new List<Element>();

//        public ModelTreeBuilder(IEnumerable<Map> maps)
//        {
//            this.maps = maps;
//        }

//        public IEnumerable<IComponent> Build()
//        {
//            return maps.Select(x => Recursion(null,x)).ToList();
//        }

//        private Structure Recursion(Structure parent, Map map)
//        {
//            var element = GetElement(map.Node);

//            var prms = map.Payloads.Where(x => x.MapId == map.Id && x.NodeId == map.Node.Id)?.Select(x => CreateParam(x)).ToList();

//            var strucure = new Structure(element)
//            {
//                Id = map.Id,
//                Order = map.Order,
//                IsActive = map.IsActive,
//                IsDraft = map.IsDraft,
//                IsArchived = map.IsArchived,
//                Created = map.Created,
//                Modified = map.Modified,
//                Params = map.Payloads.Where(x => x.MapId == map.Id && x.NodeId == map.Node.Id)?.Select(x => CreateParam(x)).ToList(),
//                Parent = parent
//            };

//            if (map.Children.Count > 0) strucure.Children = map.Children.Select(x => Recursion(strucure, x)).ToList();

//            return strucure;
//        }

//        Element GetElement(Node node)
//        {
//            var element = elements.FirstOrDefault(x => x.Id == node.Id);

//            var prms = node.Payloads.Where(x => x.MapId == null)?.Select(x => CreateParam(x)).ToList();

//            if (element == null)
//                element = new Element(node.Title)
//                {
//                    Id = node.Id,
//                    IsActive = node.IsActive,
//                    IsDraft = node.IsDraft,
//                    IsArchived = node.IsArchived,
//                    Key = node.Key,
//                    Created = node.Created,
//                    Modified = node.Modified,
//                    Params = node.Payloads.Where(x => x.MapId == null)?.Select(x => CreateParam(x)).ToList()
//                };

//            return element;
//        }

//        Param CreateParam(Payload payload)
//        {
//            return new Param
//            {
//                Id = payload.Id,
//                IsActive = payload.IsActive,
//                IsDraft = payload.IsDraft,
//                Key = payload.Key,
//                Name = payload.Name,
//                Value = payload.Value,
//                Created = payload.Created,
//                Modified = payload.Modified
//            };
//        }
//    }
//}
