using Newtonsoft.Json; // Biblioteca para trabalhar com JSON (serialização e desserialização)
using System; // Namespace principal do .NET para funcionalidades básicas
using System.Collections.Generic; // Suporte a coleções genéricas
using System.Linq; // Permite consultas e manipulação de dados com LINQ
using System.Linq.Expressions; // Trabalha com expressões lambda e árvores de expressões
using System.Net.Http; // Fornece classes para enviar requisições HTTP
using System.Text; // Manipula strings e codificação
using System.Threading.Tasks; // Suporte à programação assíncrona com async/await

namespace API
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            // Cria uma instância do HttpClient para enviar requisições HTTP
            HttpClient client = new HttpClient();

            // Define a URL da API que será acessada
            string apiUrl = "https://api.invertexto.com/v1/currency/:symbols";

            try
            {
                // Faz uma requisição GET para a URL especificada, aguardando de forma assíncrona
                HttpResponseMessage response = await client.GetAsync(apiUrl);

                // Verifica se a resposta da API foi bem-sucedida (status code 200-299)
                if (response.IsSuccessStatusCode)
                {
                    // Lê o conteúdo da resposta HTTP como uma string JSON
                    string jsonResult = await response.Content.ReadAsStringAsync();

                    // Converte a string JSON em um objeto dinâmico usando Newtonsoft.Json
                    var jsonObject = JsonConvert.DeserializeObject<dynamic>(jsonResult);

                    // Exibe no console a resposta da API
                    Console.WriteLine("Resposta da API: ");
                    Console.WriteLine(jsonResult);
                }
                else
                {
                    // Exibe no console o código de erro caso a requisição não seja bem-sucedida
                    Console.WriteLine($"Erro na requisição: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                // Captura e exibe no console qualquer exceção que ocorra durante a execução
                Console.WriteLine($"Erro: {ex.Message}");
            }
            finally
            {
                // Libera os recursos do HttpClient para evitar problemas de memória
                client.Dispose();
            }
        }
    }
}
