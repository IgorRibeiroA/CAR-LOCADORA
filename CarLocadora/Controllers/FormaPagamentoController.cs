using CarLocadora.Modelo;
using CarLocadora.Modelo.ModelsToken;
using CarLocadora.Servico;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace CarLocadora.Controllers
{
    public class FormaPagamentoController : Controller
    {

        private string mensagem = "";

        private readonly IOptions<DadosBase> _dadosBase;
        private readonly IOptions<LoginRespostaModel> _loginRespostaModel;
        public FormaPagamentoController(IOptions<DadosBase> dadosBase, IOptions<LoginRespostaModel> loginRespostaModel)
        {
            _dadosBase = dadosBase;
            _loginRespostaModel = loginRespostaModel;
        }
        // GET: FormaPagamentoController
        public ActionResult Index()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",
            new ApiToken(_dadosBase, _loginRespostaModel).Obter());

            HttpResponseMessage response = client.GetAsync($"{_dadosBase.Value.API_URL_BASE}FormaPagamento").Result;

            if (response.IsSuccessStatusCode)
            {
                string conteudo = response.Content.ReadAsStringAsync().Result;
                return View(JsonConvert.DeserializeObject<List<FormaPagamento>>(conteudo));
            }
            else
            {
                throw new Exception("Falha sistêmica");
            }
        }

        // GET: FormaPagamentoController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: FormaPagamentoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FormaPagamentoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([FromForm] FormaPagamento forma)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    HttpClient client = new HttpClient();
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",
                    new ApiToken(_dadosBase, _loginRespostaModel).Obter());

                    HttpResponseMessage response = client.PostAsJsonAsync($"{_dadosBase.Value.API_URL_BASE}FormaPagamento", forma).Result;

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

        // GET: FormaPagamentoController/Edit/5
        public ActionResult Edit(int id)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",
            new ApiToken(_dadosBase, _loginRespostaModel).Obter());

            HttpResponseMessage response = client.GetAsync($"{_dadosBase.Value.API_URL_BASE}FormaPagamento/ObterUmaFormaPagamento?id={id}").Result;

            if (response.IsSuccessStatusCode)
            {
                string conteudo = response.Content.ReadAsStringAsync().Result;
                return View(JsonConvert.DeserializeObject<FormaPagamento>(conteudo));
            }
            else
            {
                throw new Exception("Falha Sistêmica!");
            }
        }

        // POST: FormaPagamentoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([FromForm] FormaPagamento formaPagamento)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    HttpClient client = new HttpClient();
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",
                    new ApiToken(_dadosBase, _loginRespostaModel).Obter());

                    HttpResponseMessage response = client.PutAsJsonAsync($"{_dadosBase.Value.API_URL_BASE}FormaPagamento", formaPagamento).Result;

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

        // GET: FormaPagamentoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: FormaPagamentoController/Delete/5
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
    }
}
