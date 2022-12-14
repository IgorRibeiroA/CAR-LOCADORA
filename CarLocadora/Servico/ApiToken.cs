using CarLocadora.Modelo;
using CarLocadora.Modelo.ModelsToken;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace CarLocadora.Servico
{
    public class ApiToken : IApiToken
    {
  
            private readonly IOptions<DadosBase> _dadosBase;
            private readonly IOptions<LoginRespostaModel> _loginRespostaModel;
            public ApiToken(IOptions<DadosBase> dadosBase, IOptions<LoginRespostaModel> loginRespostaModel)
            {
                _dadosBase = dadosBase;
                _loginRespostaModel = loginRespostaModel;
            }
            private void ObterToken()
            {
                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));



                LoginRequisicaoModel loginRequisicaoModel = new LoginRequisicaoModel();
                loginRequisicaoModel.Usuario = "UsuarioDevPratica";
                loginRequisicaoModel.Senha = "SenhaDevPratica";


                HttpResponseMessage response = client.PostAsJsonAsync($"{_dadosBase.Value.API_URL_BASE}Login", loginRequisicaoModel).Result;

                if (response.IsSuccessStatusCode)
                {
                    string conteudo = response.Content.ReadAsStringAsync().Result;
                    LoginRespostaModel loginRespostaModel = JsonConvert.DeserializeObject<LoginRespostaModel>(conteudo);

                    if (loginRespostaModel.Autenticado == true)
                    {
                        _loginRespostaModel.Value.Autenticado = loginRespostaModel.Autenticado;
                        _loginRespostaModel.Value.Usuario = loginRespostaModel.Usuario;
                        _loginRespostaModel.Value.DataExpiracao = loginRespostaModel.DataExpiracao;
                        _loginRespostaModel.Value.Token = loginRespostaModel.Token;
                    }
                }
                else
                {
                    throw new Exception("Falha sistêmica!");
                }
            }

            public string Obter()
            {
                if (_loginRespostaModel.Value.Autenticado == false)
                {
                    ObterToken();
                }
                else
                {
                    if (DateTime.Now >= _loginRespostaModel.Value.DataExpiracao)
                    {
                        ObterToken();
                    }
                }

                return _loginRespostaModel.Value.Token;
            }

    }
}
