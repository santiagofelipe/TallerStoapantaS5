using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace stoapantaS5
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Insertar : ContentPage
	{
		public Insertar ()
		{
			InitializeComponent ();
		}

        private void btnInsertar_Clicked(object sender, EventArgs e)
        {
			try
			{
				WebClient cliente = new WebClient ();
				string URL = "http://192.168.1.11/ws_uisrael/post.php";

				var parametros = new System.Collections.Specialized.NameValueCollection();
				parametros.Add("codigo", txtCodigo.Text);
                parametros.Add("nombre", txtNombre.Text);
                parametros.Add("apellido", txtApellido.Text);
                parametros.Add("edad", txtEdad.Text);
				cliente.UploadValues(URL, "POST", parametros);
				DisplayAlert("Alerta", "Ingreso Correcto", "Cerrar");
				Navigation.PushAsync(new Page1());
            }
			catch (Exception ex)
			{
                DisplayAlert("Alerta", ex.Message, "Cerrar");
            }
        }
    }
}