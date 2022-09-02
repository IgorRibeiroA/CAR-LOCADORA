using CarLocadora.Modelo;
using CarLocadora.Servico;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace CarLocadora.Controllers
{
    public class VistoriaController : Controller
    {
        private string mensagem = "";

        private readonly IOptions<DadosBase> _dadosBase;
        private readonly IApiToken _apiToken;
        public VistoriaController(IOptions<DadosBase> dadosBase, IApiToken apiToken)
        {

            _dadosBase = dadosBase;
            _apiToken = apiToken;
        }
        public IActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            ViewBag.Locacoes = CarregarLocacoes().Result;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([FromForm] Vistoria vistoria)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    HttpClient client = new HttpClient();
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",
                    _apiToken.Obter());
                    HttpResponseMessage response = client.PostAsJsonAsync($"{_dadosBase.Value.API_URL_BASE}Vistoria", vistoria).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction(nameof(Index), new { mensagem = "resgisto incluido!", sucesso = true });
                    }
                    else
                    {
                        throw new Exception("Falha Sistêmica");
                    }
                }
                else
                {
                    TempData["erro"] = "Algum campo pode está incorreto";
                    return View();
                }
            }
            catch (Exception ex)
            {
                TempData["erro"] = "algum erro aconteceu - " + ex.Message;
                return View();
            }
        }
        private async Task<List<SelectListItem>> CarregarLocacoes()
        {
            List<SelectListItem> lista = new List<SelectListItem>();

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _apiToken.Obter());

            HttpResponseMessage response = await client.GetAsync($"{_dadosBase.Value.API_URL_BASE}Locacao");

            if (response.IsSuccessStatusCode)
            {
                List<Locacao> locacoes = JsonConvert.DeserializeObject<List<Locacao>>(await response.Content.ReadAsStringAsync());

                foreach (var linha in locacoes)
                {
                    lista.Add(new SelectListItem()
                    {
                        Value = linha.Id.ToString(),
                        Text = linha.VeiculoPlaca + " - " + linha.ClienteCPF,
                        Selected = false,
                    });
                }

                return lista;
            }
            else
            {
                throw new Exception(response.ReasonPhrase);
            }
        }
        
    }
}
