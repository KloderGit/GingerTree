using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using Wpf.TreeBuilder.ViewModel;

namespace Wpf.TreeBuilder.Component
{
    /// <summary>
    /// Логика взаимодействия для ElementCoponent.xaml
    /// </summary>
    public partial class ElementCoponent : UserControl
    {
        public ElementCoponent()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        public string Title { get; set; }

        public IEnumerable<string> Params { get; set; }
    }
}
