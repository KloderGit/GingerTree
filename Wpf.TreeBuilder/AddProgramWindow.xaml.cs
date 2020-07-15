using Core.Domain;
using System.Collections.ObjectModel;
using System.Windows;

namespace Wpf.TreeBuilder
{
    /// <summary>
    /// Логика взаимодействия для AddProgramWindow.xaml
    /// </summary>
    public partial class AddProgramWindow : Window
    {
        public string EventTitle { get; set; }
        public ObservableCollection<Param> @params = new ObservableCollection<Param>();

        public AddProgramWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            EventTitle = AddEvent.EvTitle;
            @params = AddEvent.@params;

            this.DialogResult = true;
        }
    }
}
