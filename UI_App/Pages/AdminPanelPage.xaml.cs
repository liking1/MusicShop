using BLL;
using BLL.Services;
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
    /// Interaction logic for AdminPanelPage.xaml
    /// </summary>
    public partial class AdminPanelPage : Page
    {
        public AdminPanelPage()
        {
            InitializeComponent();
            LoadAllService();
        }

        #region init_property
        IAlbumService albumService = new AlbumService();
        IArtishService artishService = new ArtishService();
        ICategoryService categoryService = new CategoryService();
        IGanreService ganreService = new GanreService();
        ITrackService trackService = new TrackService();
        #endregion
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(countryNameTB.Text))
            {
                albumService.AddCountry(countryNameTB.Text);
            }
        }

        #region combobox_load_methods
        void LoadCountries()
        {
            countryList.ItemsSource = albumService.GetCountries();
        }
        void LoadAlbums()
        {
            cbAlbums.ItemsSource = albumService.GetAll();
        }
        void LoadArtishes()
        {
            cbArtishs.ItemsSource = artishService.GetAll();
        }
        void LoadCategory()
        {
            cbCategor.ItemsSource = categoryService.GetAll();
        }
        void LoadGanre()
        {
            cbGANRE.ItemsSource = ganreService.GetAll();
        }
        void LoadTrack()
        {
            cbTrack.ItemsSource = trackService.GetAll();
        }
        void LoadAllService()
        {
            LoadCountries();
            LoadAlbums();
            LoadCategory();
            LoadGanre();
            LoadTrack();
            LoadArtishes();
            LoadComboBox();
        }
        #endregion

        // REFRESH all combobox
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            LoadAllService();
        }

        // Add new album
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            try
            {
                albumService.Add(new Album
                {
                    Name = tbName.Text,
                    ArtishId = (int)cbArtishId.SelectedItem,
                    GanreId = (int)cbGanres.SelectedItem,
                    CategoryId = (int)cbCategory.SelectedItem,
                    Year = (DateTime)dpYear.SelectedDate
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        // load AlbumComboBox
        private void LoadComboBox()
        {
            cbArtishId.ItemsSource = artishService.GetAllArtishId();
            cbGanres.ItemsSource = ganreService.GetAllGanreId();
            cbCountryId.ItemsSource = albumService.GetAllCountryId();
            cbCategory.ItemsSource = categoryService.GetAllId();
        }

        // Add new Artish
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            try
            {
                artishService.Add(new Artish { Name = tbNameArtish.Text, Surname = tbSurnameArtish.Text, CountryId = (int)cbCountryId.SelectedItem });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        // Add new Category
        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            try
            {
                categoryService.Add(new Category { Name = tbNameCategory.Text });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        // Add new ganre
        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            try
            {
                ganreService.Add(new Ganre { Name = tbGanreName.Text });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex}");
            }
        }

        // Add new track
        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            try
            {
                trackService.Add(new Track { Name = tbTracksName.Text });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void btnReturn(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(null);
        }
    }
}
