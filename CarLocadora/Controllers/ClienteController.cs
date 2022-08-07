using CarLocadora.Modelo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace CarLocadora.Controllers
{
    public class ClienteController : Controller
    {
        // GET: ClienteController
        private string mensagem = "";

        private readonly IOptions<DadosBase> _dadosBase;
        public ClienteController(IOptions<DadosBase> dadosBase)
        {
            _dadosBase = dadosBase;
        }


        public ActionResult Index()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync($"{_dadosBase.Value.API_URL_BASE}Cliente").Result;

            if (response.IsSuccessStatusCode)
            {
                string conteudo = response.Content.ReadAsStringAsync().Result;
                return View(JsonConvert.DeserializeObject<List<Cliente>>(conteudo));
            }
            else
            {
                throw new Exception("Falha sistêmica");
            }
        }

        // GET: ClienteController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ClienteController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ClienteController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([FromForm] Cliente cliente)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    HttpClient client = new HttpClient();
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage response = client.PostAsJsonAsync($"{_dadosBase.Value.API_URL_BASE}Cliente", cliente).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction(nameof(Index), new { mensagem = "resgisto incluido!", sucesso = true } );
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

        // GET: ClienteController/Edit/5
        public ActionResult Edit(string valor)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync($"{_dadosBase.Value.API_URL_BASE}Cliente/ObterUmCliente?cpf={valor}").Result;

            if (response.IsSuccessStatusCode)
            {
                string conteudo = response.Content.ReadAsStringAsync().Result;
                return View(JsonConvert.DeserializeObject<Cliente>(conteudo));
            }
            else
            {
                throw new Exception("Falha Sistêmica!");
            }
        }

        // POST: ClienteController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([FromForm] Cliente cliente)
        {
            try
            {

                if (ModelState.IsValid) 
                {
                    HttpClient client = new HttpClient();
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage response = client.PutAsJsonAsync($"{_dadosBase.Value.API_URL_BASE}Cliente", cliente).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction(nameof(Index), new { mensagem = "Registro Alterado!", sucesso = true });
                    }
                    else
                    {
                        throw new Exception("Deu Zica!");
                    }

                    //return RedirectToAction(nameof(Index), new { mensagem = "Resgisto editado!", sucesso = true });

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

        // GET: ClienteController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ClienteController/Delete/5
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
