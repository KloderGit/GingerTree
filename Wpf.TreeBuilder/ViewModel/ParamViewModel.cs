using Core.Domain;

namespace Wpf.TreeBuilder.ViewModel
{
    public class ParamViewModel
    {
        Param param;
        public ParamViewModel(Param param)
        {
            this.param = param;

            Id = param.Id;
            Key = param.Key;
            Value = param.Value;
        }
        public int Id { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
    }
}
