using CarLocadora.Modelo;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarLocadora.Negocio.ClienteNegocio
{
    public interface IClienteNegocio
    {
        List<Cliente> ObterLista();
        Cliente ObterUmCliente(string cpf);

        void Incluir(Cliente cliente);

        void Alterar(Cliente cliente);
    }
}
