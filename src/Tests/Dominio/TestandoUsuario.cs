using Microsoft.VisualStudio.TestTools.UnitTesting;
using MPSC.PlenoSoft.Core.Collections.Generic;
using MPSC.PlenoSoft.MultiTenancy.Core.Dominio;

namespace MPSC.PlenoSoft.MultiTenancy.Core.Testes
{
	[TestClass]
	public class TestandoUsuario
	{
		private static readonly ContainerObject _containerObject = Setup(new ContainerObject());

		private static ContainerObject Setup(ContainerObject co)
		{
			var usuario = co.Adicionar(new Usuario() { Id = 1, Owner = null, Nome = "Nome Usuario Sobrenome (Admin)", EMail = "usuario@dominio.com.br", Celular = "21 9 8765-4321" });
			usuario.DefinirSenhaInicial("Abc@123!", "Abc@123!");

			var sistema = co.Adicionar(new Sistema() { Id = 1, Nome = "MPSC.PlenoSoft.MultiTenancy.Core", Sigla = "MPSC.PlenoSoft.MultiTenancy.Core" });
			var organizacao = co.Adicionar(new Organizacao { Id = 1, Titular = usuario, RazaoSocial = "Mercado Pleno Soluções em Computação Ltda M.E." });

			return co;
		}


		[TestMethod]
		public void QuandoContrataNovoSistema_Deve()
		{
			var usuarioAdmin = _containerObject.Obter<Usuario>(u => u.Id == 1);

			var usuarioTitular = new Usuario() { Owner = usuarioAdmin };
			var organizacao = new Organizacao() { Titular = usuarioTitular };

			usuarioTitular.AdicionarUsuarioNaOrganizacao(organizacao, new Usuario());
		}
	}
}