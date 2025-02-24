using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Mir4Bot
{
    public class NoticiasService
    {
        private static readonly HttpClient httpClient = new HttpClient();

        public async Task<List<Noticia>> BuscarNoticiasAsync(string url)
        {
            try
            {
                HttpResponseMessage response = await httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode(); // Lança uma exceção se o status não for 200 OK

                string json = await response.Content.ReadAsStringAsync();
                Console.WriteLine("JSON recebido: " + json); // Log para depuração

                List<Noticia> noticias = JsonSerializer.Deserialize<List<Noticia>>(json);
                return noticias;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine("Erro na requisição HTTP: " + ex.Message); // Log para depuração
                throw new Exception($"Erro ao buscar notícias: {ex.Message}");
            }
            catch (JsonException ex)
            {
                Console.WriteLine("Erro ao desserializar JSON: " + ex.Message); // Log para depuração
                throw new Exception($"Erro ao processar o JSON: {ex.Message}");
            }
        }
    }
}