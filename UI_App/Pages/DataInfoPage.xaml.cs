using BLL;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace UI_App.Pages
{
    /// <summary>
    /// Interaction logic for DataInfoPage.xaml
    /// </summary>
    public partial class DataInfoPage : Page
    {
        IAlbumService albumService = new AlbumService();
        MusicCollectionDb ctx = new MusicCollectionDb();
        public DataInfoPage()
        {
            InitializeComponent();
            LoadGrid();
        }
        public void LoadGrid() => datagrid.ItemsSource = albumService.GetAllTest().ToList();
        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            foreach (var item in datagrid.SelectedItems)
            {
                Album album = item as Album;
                albumService.RemoveSelectedItem((Album)item);
            }
        }
        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            foreach (var item in datagrid.SelectedItems)
            {
                Album album = item as Album;
                if (album != null)
                {
                    albumService.Update(album);
                }
            }
        }
        private void btnReturn(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(null);
        }
    }
}
