using Microsoft.VisualStudio.TestTools.UnitTesting;
using MPSC.PlenoSoft.MultiTenancy.Core.Abstracao;

namespace MPSC.PlenoSoft.MultiTenancy.Core.Testes.Dominio
{
	[TestClass]
	public class TestandoFlux
	{
		[TestMethod]
		public void Testando()
		{
			Flux.To("Obter Informacoes da pessoa", out var fluxArg)
				.Do("Obter Pessoa Por CPF", p => { })
				.Do("Obter Vendas da PessoaId", p => { })
				.Do("Verificar se tá tudo ok", p => { })
			;

			Assert.IsTrue(fluxArg.Status);
		}

		[TestMethod]
		public void Testando2()
		{
			Flux.To("Obter Informacoes da pessoa", out var fluxArg)
				.Do("Obter Pessoa Por CPF",ObterPessoaPorCPF)
				.Do("Obter Vendas da PessoaId", ObterVendasDaPessoaId)
				.Do("Verificar se tá tudo ok", VerificarSeTaTudoOk)
			;

			Assert.IsTrue(fluxArg.Status);
		}

		private void ObterPessoaPorCPF(FluxArg fluxArg)
		{
			Flux.With(fluxArg, "Obter Informacoes da pessoa2")
				.Do("Obter Vendas da PessoaId2", ObterVendasDaPessoaId2)
				.Do("Verificar se tá tudo ok2", VerificarSeTaTudoOk)
			;
		}

		private void ObterVendasDaPessoaId2(FluxArg fluxArg)
		{
			fluxArg.AddValidation("Pessoa não encontrada");
		}

		private void ObterVendasDaPessoaId(FluxArg fluxArg)
		{
		}

		private void VerificarSeTaTudoOk(FluxArg fluxArg)
		{
		}
	}
}
