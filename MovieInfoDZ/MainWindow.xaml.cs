using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
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

namespace MovieInfoDZ
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public SearchRes? Data { get; set; }

        private async void search_btn_Click(object sender, RoutedEventArgs e)
        {
            var json = await DownloadService.FindMovie(search_box.Text);

            Data = await DeserializeService.Deserialize(json);


            foreach (var item in Data.result.Movies)
            {
                result_listbox.Items.Add(item);
            }
        }

        public static async Task<ImageSource> ByteToImage(byte[] imageData)
        {
            BitmapImage biImg = new BitmapImage();
            using MemoryStream ms = new MemoryStream(imageData);
            biImg.BeginInit();
            biImg.StreamSource = ms;
            biImg.EndInit();

            ImageSource imgSrc = biImg as ImageSource;

            return imgSrc;
        }

        private async void result_listbox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var index = result_listbox.SelectedIndex;

            var selecteditem = Data.result.Movies[index];

            title_lbl.Content = selecteditem.Title;
            year_lbl.Content = selecteditem.Year;
            imdb_lbl.Content = selecteditem.imdbID;
            type_lbl.Content = selecteditem.Type;

            var client = new WebClient();

            var res = await client.DownloadDataTaskAsync(new Uri(Data.result.Movies[index].thumbnail));

            image_box.Source = await ByteToImage(res);

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}