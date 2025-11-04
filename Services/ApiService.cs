using LigaApp.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace LigaApp.Services
{

    /// <summary>
    /// Servicio responsable de comunicarse con la API remota de un club de futbol.
    /// Expone metodos asincronos (async) que devuelven los modelos ya deserializados.
    /// </summary>
    public class ApiService
    {
        // HttpClient es thread-safe  y se recomienda
        // usar la misma instancia durante 
        // toda la vida de la aplicacion
        private readonly HttpClient _http;

        private readonly JsonSerializerOptions _jsonOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        public ApiService()
        {
            _http = new HttpClient
            {
                BaseAddress = new Uri("https://chetosfs.com/server/"),
                // Opcional: ajustar Timeout si se quiere un control distinto
                // Al por defecto
                Timeout = TimeSpan.FromSeconds(15)
            };
        }

        public async Task<List<EquipoModel>> ObtenerClasificacionActual(CancellationToken cancellationToken = default)
        {
            // Llama al endpoint de la API y almacena el resultado en un string
            string json = await _http.GetStringAsync("liga-tabla.php",cancellationToken)
                .ConfigureAwait(false);

            // Deserializamos el JSON en objetos C# usando System.Text.Json
            var lista = JsonSerializer.Deserialize<List<EquipoModel>>(json, _jsonOptions);

            return lista ?? new List<EquipoModel>();
        }

    }
}
