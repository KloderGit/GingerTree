using Core.Domain;
using GingerTree.UI.Infrastructure;
using GingerTree.UI.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace GingerTree.UI.ViewModels
{
    public class ParamViewModel : IDomain<Param>
    {
        Param param;

        public ParamViewModel()
        {}

        public ParamViewModel(Param param)
        {
            this.param = param;

            Key = new TunelProperty<string>(param.Key);
            Value = new TunelProperty<string>(param.Value);
        }

        public TunelProperty<string> Key { get; set; }

        public TunelProperty<string> Value { get; set; }

        public Param GetDomain()
        {
            return param;
        }
    }
}
