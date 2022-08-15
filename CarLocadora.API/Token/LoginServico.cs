
using CarLocadora.Modelo.ModelsToken;

namespace CarLocadora.API.Token
{
    public class LoginServico
    {
        public async Task<LoginRespostaModel> Login(LoginRequisicaoModel loginRequisicaoModel)
        {
            LoginRespostaModel loginRespostaModel = new LoginRespostaModel();
            loginRespostaModel.Autenticado = false;
            loginRespostaModel.Usuario = loginRequisicaoModel.Usuario;
            loginRespostaModel.Token = "";
            loginRespostaModel.DataExpiracao = null;

            if (loginRequisicaoModel.Usuario == "UsuarioDevPratica" && loginRequisicaoModel.Senha == "SenhaDevPratica")
            {
                loginRespostaModel = new GeradorToken().GerarToken(loginRespostaModel);
            }
            else
            {

            }

            return loginRespostaModel;
        }
    }
}
