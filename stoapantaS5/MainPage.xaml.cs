using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using static System.Net.WebRequestMethods;

namespace stoapantaS5
{
    public partial class MainPage : ContentPage
    {

        private const string Url = "http://192.168.1.11/ws_uisrael/post.php";
        private readonly HttpClient client = new HttpClient();
        private ObservableCollection<stoapantaS5.Datos> _post;

        public MainPage()
        {
            InitializeComponent();
        }

        private async void btnMostrar_Clicked(object sender, EventArgs e)
        {
            var contenido = await client.GetStringAsync(Url);
            List<stoapantaS5.Datos> listaPost = JsonConvert.DeserializeObject<List<stoapantaS5.Datos>>(contenido);
            _post = new ObservableCollection<stoapantaS5.Datos>(listaPost);
            
            ListaEstudiantes.ItemsSource = _post;
        }
    }
}
