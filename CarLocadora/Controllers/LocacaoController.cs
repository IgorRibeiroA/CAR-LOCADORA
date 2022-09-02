using CarLocadora.Modelo;
using CarLocadora.Servico;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace CarLocadora.Controllers
{
    public class LocacaoController : Controller
    {
        private string mensagem = "";

        private readonly IOptions<DadosBase> _dadosBase;
        private readonly IApiToken _apiToken;
        public LocacaoController(IOptions<DadosBase> dadosBase, IApiToken apiToken) { 
        
            _dadosBase = dadosBase;
            _apiToken = apiToken;
        }
        public IActionResult Index()
        {

            return View();
        }

        public ActionResult Create()
        {
            ViewBag.Veiculos = CarregarVeiculos().Result;
            ViewBag.Clientes = CarregarClientes().Result;
            ViewBag.FormasDePagamentos = CarregarFormasDePagamento().Result;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([FromForm] Locacao locacao)
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
                    HttpResponseMessage response = client.PostAsJsonAsync($"{_dadosBase.Value.API_URL_BASE}Locacao", locacao).Result;

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







        private async Task<List<SelectListItem>> CarregarVeiculos()
        {
            List<SelectListItem> lista = new List<SelectListItem>();

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",  _apiToken.Obter());

            HttpResponseMessage response = await client.GetAsync($"{_dadosBase.Value.API_URL_BASE}Veiculo");

            if (response.IsSuccessStatusCode)
            {
                List<Veiculo> veiculos = JsonConvert.DeserializeObject<List<Veiculo>>(await response.Content.ReadAsStringAsync());

                foreach (var linha in veiculos)
                {
                    lista.Add(new SelectListItem()
                    {
                        Value = linha.Placa,
                        Text = linha.Modelo + " - " + linha.Marca,
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

        private async Task<List<SelectListItem>> CarregarClientes()
        {
            List<SelectListItem> lista = new List<SelectListItem>();

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _apiToken.Obter());

            HttpResponseMessage response = await client.GetAsync($"{_dadosBase.Value.API_URL_BASE}Cliente");

            if (response.IsSuccessStatusCode)
            {
                List<Cliente> Clientes = JsonConvert.DeserializeObject<List<Cliente>>(await response.Content.ReadAsStringAsync());

                foreach (var linha in Clientes)
                {
                    lista.Add(new SelectListItem()
                    {
                        Value = linha.CPF,
                        Text = linha.Nome + " - " + linha.CPF,
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

        private async Task<List<SelectListItem>> CarregarFormasDePagamento()
        {
            List<SelectListItem> lista = new List<SelectListItem>();

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",  _apiToken.Obter());

            HttpResponseMessage response = await client.GetAsync($"{_dadosBase.Value.API_URL_BASE}FormaPagamento");

            if (response.IsSuccessStatusCode)
            {
                List<FormaPagamento> formasPagamento = JsonConvert.DeserializeObject<List<FormaPagamento>>(await response.Content.ReadAsStringAsync());

                foreach (var linha in formasPagamento)
                {
                    lista.Add(new SelectListItem()
                    {
                        Value = linha.Id.ToString(),
                        Text = linha.Descricao,
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
