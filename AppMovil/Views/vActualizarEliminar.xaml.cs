using cGuambaS6.Models;
using System.Net;
using System.Text;

namespace cGuambaS6.Views;

public partial class vActualizarEliminar : ContentPage
{
    private const string urlWS = "http://127.0.0.1/wsestudiantes/estudiantews.php";
    public vActualizarEliminar(Estudiante estudiante)
	{
		InitializeComponent();
        txtId.Text = estudiante.id.ToString();
        txtNombre.Text = estudiante.nombre;
        txtApellido.Text = estudiante.apellido;
        txtEdad.Text = estudiante.edad.ToString();
	}

    private void btnActualizar_Clicked(object sender, EventArgs e)
    {
        WebClient cliente = new WebClient();
        var parametros = new System.Collections.Specialized.NameValueCollection();
        parametros.Add("id", txtId.Text);
        parametros.Add("nombre", txtNombre.Text);
        parametros.Add("apellido", txtApellido.Text);
        parametros.Add("edad", txtEdad.Text);
        byte[] bytes = cliente.UploadValues(urlWS, "PUT", parametros);
        string texto = Encoding.UTF8.GetString(bytes);
        DisplayAlert("respuesta", texto, "continuar");
        Navigation.PushAsync(new vEstudiante());
    }

    private void btnEliminar_Clicked(object sender, EventArgs e)
    {
        WebClient cliente = new WebClient();
        var parametros = new System.Collections.Specialized.NameValueCollection();
        parametros.Add("id", txtId.Text);
        byte[] bytes = cliente.UploadValues(urlWS, "DELETE", parametros);
        string texto = Encoding.UTF8.GetString(bytes);
        DisplayAlert("respuesta", texto, "continuar");
        Navigation.PushAsync(new vEstudiante());
    }
}