using CarLocadora.Modelo;
using CarLocadora.Modelo.ModelsToken;
using CarLocadora.Servico;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace CarLocadora.Controllers
{
    public class VeiculoController : Controller
    {
        private string mensagem = "";

        private readonly IOptions<DadosBase> _dadosBase;
        private readonly IApiToken _apiToken;
        public VeiculoController(IOptions<DadosBase> dadosBase, IApiToken apiToken)
        {
            _dadosBase = dadosBase;
            _apiToken = apiToken;
        }
        // GET: VeiculoController
        public ActionResult Index()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _apiToken.Obter());

            HttpResponseMessage response = client.GetAsync($"{_dadosBase.Value.API_URL_BASE}Veiculo").Result;

            if (response.IsSuccessStatusCode)
            {
                string conteudo = response.Content.ReadAsStringAsync().Result;
                return View(JsonConvert.DeserializeObject<List<Veiculo>>(conteudo));
            }
            else
            {
                throw new Exception("Falha sistêmica");
            }
        }

        // GET: VeiculoController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: VeiculoController/Create
        public ActionResult Create()
        {
            ViewBag.CategoriasDeVeiculos = CarregarCategoriasDeVeiculos();
            return View();
        }

        // POST: VeiculoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([FromForm] Veiculo veiculo)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    HttpClient client = new HttpClient();
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _apiToken.Obter());

                    HttpResponseMessage response = client.PostAsJsonAsync($"{_dadosBase.Value.API_URL_BASE}Veiculo", veiculo).Result;

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

        // GET: VeiculoController/Edit/5
        public ActionResult Edit(string valor)
        {


            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _apiToken.Obter());

            HttpResponseMessage response = client.GetAsync($"{_dadosBase.Value.API_URL_BASE}Veiculo/ObterUmVeiculo?placa={valor}").Result;

            if (response.IsSuccessStatusCode)
            {
                ViewBag.CategoriasDeVeiculos = CarregarCategoriasDeVeiculos();

                string conteudo = response.Content.ReadAsStringAsync().Result;
                return View(JsonConvert.DeserializeObject<Veiculo>(conteudo));
            }
            else
            {
                throw new Exception("Falha Sistêmica!");
            }
        }

        // POST: VeiculoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([FromForm] Veiculo veiculo)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    HttpClient client = new HttpClient();
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _apiToken.Obter());

                    HttpResponseMessage response = client.PutAsJsonAsync($"{_dadosBase.Value.API_URL_BASE}Veiculo", veiculo).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction(nameof(Index), new { mensagem = "Registro Alterado!", sucesso = true });
                    }
                    else
                    {
                        throw new Exception("Aconteceu Algo errado!");
                    }
                }
                else
                {
                    TempData["erro"] = "Algum campo não foi preenchimento!";
                    return View();
                }
            }
            catch (Exception ex)
            {
                TempData["erro"] = "Algum erro aconteceu - " + ex.Message;
                return View();
            }
        }

        // GET: VeiculoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: VeiculoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        private List<SelectListItem> CarregarCategoriasDeVeiculos()
        {
            List<SelectListItem> lista = new List<SelectListItem>();

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",  _apiToken.Obter());

            HttpResponseMessage response = client.GetAsync($"{_dadosBase.Value.API_URL_BASE}Categoria").Result;

            if (response.IsSuccessStatusCode)
            {
                string conteudo = response.Content.ReadAsStringAsync().Result;
                List<Categoria> categorias = JsonConvert.DeserializeObject<List<Categoria>>(conteudo);

                foreach (var linha in categorias)
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