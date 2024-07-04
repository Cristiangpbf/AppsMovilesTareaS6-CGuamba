
using cGuambaS6.Models;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace cGuambaS6.Views;

public partial class vEstudiante : ContentPage
{
	private const string urlWS = "http://192.168.0.12/wsestudiantes/estudiantews.php";
	private readonly HttpClient cliente = new HttpClient();
	private ObservableCollection<Estudiante> estudiantes;

    public vEstudiante()
	{
		InitializeComponent();
		Obtener();
	}

    private async void Obtener()
    {
		var content = await cliente.GetStringAsync(urlWS);
		List<Estudiante> listaEstudiantes = JsonConvert.DeserializeObject<List<Estudiante>>(content);
		estudiantes = new ObservableCollection<Estudiante>(listaEstudiantes);
        lvEstudiantes.ItemsSource = estudiantes;

    }
}