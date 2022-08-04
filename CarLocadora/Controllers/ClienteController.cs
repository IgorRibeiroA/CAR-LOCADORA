using CarLocadora.Modelo;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace CarLocadora.Controllers
{
    public class ClienteController : Controller
    {
        public ActionResult Index(string mensagem = null, bool sucesso = true)
        {

            if (sucesso)
                TempData["sucesso"] = mensagem;
            else
                TempData["erro"] = mensagem;

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",
            //    new ApiToken(_dadosBase, _loginRespostaModel).Obter());


            HttpResponseMessage response = client.GetAsync($"https://localhost:7297/api/Cliente").Result;

            if (response.IsSuccessStatusCode)
            {
                string conteudo = response.Content.ReadAsStringAsync().Result;
                return View(JsonConvert.DeserializeObject<List<Cliente>>(conteudo));
            }
            else
            {
                throw new Exception("Deu Zica!");
            }
        }
    }
}
