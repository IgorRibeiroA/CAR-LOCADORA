using CarLocadora.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarLocadora.Negocio.UsuarioNegocio
{
    public interface IUsuarioNegocio
    {
        List<Usuario> ObterLista();
        Usuario ObterUmUsuario(string cpf);

        void Incluir(Usuario usuario);

        void Alterar(Usuario usuario);
    }
}
