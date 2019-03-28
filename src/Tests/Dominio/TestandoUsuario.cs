using Microsoft.VisualStudio.TestTools.UnitTesting;
using MPSC.PlenoSoft.MultiTenancy.Core.Dominio;

namespace MPSC.PlenoSoft.MultiTenancy.Core.Testes
{
    [TestClass]
    public class TestandoUsuario
    {
        [TestMethod]
        public void QuandoContrataNovoSistema_Deve()
        {
            var usuarioAdmin = new Usuario() { Nome = "Bruno Fernandes (Admin)" };
            var sistema = new Sistema() { Nome = "MPSC.PlenoSoft.MultiTenancy_Security" };

            var usuarioTitular = new Usuario() { Owner = usuarioAdmin };
            var organizacao = new Organizacao() { Titular = usuarioTitular };

            usuarioTitular.AdicionarUsuarioNaOrganizacao(organizacao, new Usuario());
        }
    }
}
