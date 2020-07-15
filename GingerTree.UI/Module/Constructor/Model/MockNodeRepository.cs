using GingerTree.UI.Infrastructure;
using GingerTree.UI.Module.Constructor.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace GingerTree.UI.Module.Constructor.Model
{
    public class MockNodeRepository
    {
        public ObservableCollection<NodeMockViewModel> GetNodeViewModels()
        {
            return new ObservableCollection<NodeMockViewModel> { 
                new NodeMockViewModel{ 
                    Title = new TunelProperty<string>("One"),
                    Children = new ObservableCollection<NodeMockViewModel>{ 
                        new NodeMockViewModel{ Title = new TunelProperty<string>("Two") },
                        new NodeMockViewModel{ Title = new TunelProperty<string>("Three") },
                        new NodeMockViewModel{ 
                            Title = new TunelProperty<string>("Four"),
                             Children = new ObservableCollection<NodeMockViewModel>{ 
                                new NodeMockViewModel{ Title = new TunelProperty<string>("Nine") },
                                new NodeMockViewModel{ Title = new TunelProperty<string>("Ten") },
                             }
                        },
                    },
                    Params = new ObservableCollection<ViewModels.ParamViewModel>{ 
                        new ViewModels.ParamViewModel(new Core.Domain.Param("Цена", "55 000")),
                        new ViewModels.ParamViewModel(new Core.Domain.Param("Длительность", "8 ч."))
                    }
                },
                new NodeMockViewModel{
                    Title = new TunelProperty<string>("Five"),
                    Children = new ObservableCollection<NodeMockViewModel>{
                        new NodeMockViewModel{ Title = new TunelProperty<string>("Six") },
                        new NodeMockViewModel{ Title = new TunelProperty<string>("Seven") },
                        new NodeMockViewModel{ 
                            Title = new TunelProperty<string>("Eight"),
                            Children = new ObservableCollection<NodeMockViewModel>{ 
                                new NodeMockViewModel{ Title = new TunelProperty<string>("Eleven") },
                                new NodeMockViewModel{ Title = new TunelProperty<string>("Twelve") },
                            }
                        },
                    }
                }
            };
        }
    }
}
