using GingerTree.UI.ViewModels;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace GingerTree.UI.Pages.TreeBuilder.Component.UnitEdit
{
    /// <summary>
    /// Логика взаимодействия для UnitEditComponent.xaml
    /// </summary>
    public partial class UnitEditComponent : UserControl
    {
        UnitEditComponentViewModel vm = new UnitEditComponentViewModel();

        public UnitEditComponent()
        {
            InitializeComponent();

            DataContext = vm;
        }

        private void txtTarget_Drop(object sender, DragEventArgs e)
        {
            //((TextBlock)sender).Text = (string)e.Data.GetData(DataFormats.Text);

            var itm = e.Data.GetData(typeof(UnitViewModel)) as UnitViewModel;

            var nd = ((TextBlock)sender).DataContext as UnitViewModel;

            nd.AddChildren(itm);

            //MessageBox.Show(itm.Title.Value);
        }

        private void Label_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ListBox lbl = (ListBox)sender;

            var nod = Elements_Listbox.SelectedItem as UnitViewModel;

            DragDrop.DoDragDrop(lbl, nod, DragDropEffects.Copy);
        }

        private void Label_MouseDown(object sender, MouseEventArgs e)
        {
            ListBox lbl = (ListBox)sender;

            if (e.LeftButton == MouseButtonState.Pressed)
            {
                var nod = Elements_Listbox.SelectedItem as UnitViewModel;

                DragDrop.DoDragDrop(lbl, nod, DragDropEffects.Copy);
            }



        }
    }
}
