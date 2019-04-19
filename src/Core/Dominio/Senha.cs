using MPSC.PlenoSoft.Core.Utils.Abstracao;
using MPSC.PlenoSoft.Core.Utils.Statics;
using System;

namespace MPSC.PlenoSoft.MultiTenancy.Core.Dominio
{
	public class Senha : Entidade
	{
		public static readonly String VaziaCriptografada = String.Empty.Criptografar();


		public Usuario Usuario { get; internal set; }
		public Int64 UsuarioId => Usuario?.Id ?? 0L;
		public String SenhaCriptografada { get; set; }

		private String SenhaNova { get; set; }
		private String SenhaNovaConfirma { get; set; }

		public Senha()
		{
			Inclusao = DateTime.UtcNow.AddMilliseconds(_controle++);
		}

		public Senha(String senhaNova, String senhaNovaConfirma) : this()
		{
			SenhaNova = senhaNova;
			SenhaNovaConfirma = senhaNovaConfirma;
			SenhaCriptografada = senhaNova.Criptografar();
		}

		public override void EhValido()
		{
			AssegureQue.NaoEhNulo(SenhaNova, "A nova senha informada não pode ser nula");
			AssegureQue.NaoEhVazio(SenhaNova, "A nova senha informada não pode ser vazia (1)");
			AssegureQue.EhDiferente(SenhaNova, VaziaCriptografada, "A nova senha informada não pode ser vazia (2)");

			AssegureQue.NaoEhNulo(SenhaNovaConfirma, "A confirmação da nova senha informada não pode ser nula");
			AssegureQue.NaoEhVazio(SenhaNovaConfirma, "A confirmação da nova senha informada não pode ser vazia (1)");
			AssegureQue.EhDiferente(SenhaNovaConfirma, VaziaCriptografada, "A confirmação da nova senha informada não pode ser vazia (2)");

			AssegureQue.EhIgual(SenhaNova, SenhaNovaConfirma, "A confirmação da nova senha não coincide com a nova senha");
		}
	}
}