using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace stoapantaS5
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page1 : ContentPage

    {
        private const string Url = "http://192.168.1.11/ws_uisrael/post.php";
        private readonly HttpClient client = new HttpClient();
        private ObservableCollection<stoapantaS5.Datos> _post;

        public Page1()
        {
            InitializeComponent();
            obtener();
        }

        public async void obtener()
        {
            var contenido = await client.GetStringAsync(Url);
            List<stoapantaS5.Datos> listaPost = JsonConvert.DeserializeObject<List<stoapantaS5.Datos>>(contenido);
            _post = new ObservableCollection<stoapantaS5.Datos>(listaPost);

            ListaEstudiantes.ItemsSource = _post;
        }

        private void btnMostrar_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Insertar());
        }

        private void ListaEstudiantes_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var objEstudiante = (Datos)e.SelectedItem;

            /*int codigo = Convert.ToInt32(objEstudiante.id.ToString());
            string nombre = objEstudiante.nombre.ToString();
            string categoria = objEstudiante.categoria.ToString();*/

            Navigation.PushAsync(new ActEliminar(objEstudiante));
        }
    }
}