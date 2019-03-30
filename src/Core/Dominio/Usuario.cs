using MPSC.PlenoSoft.Core.Collections.Generic;
using MPSC.PlenoSoft.Core.Utils.Abstracao;
using MPSC.PlenoSoft.Core.Utils.Statics;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MPSC.PlenoSoft.MultiTenancy.Core.Dominio
{
	public class Usuario : Entidade
	{
		private const String _senhaNula = "F@nf4rrã0";
		private static readonly String _senhaVaziaCriptografada = String.Empty.Criptografar();

		public Usuario Owner { get; set; }
		public String Nome { get; set; }
		public String EMail { get; set; }
		public String Celular { get; set; }
		public Lista<Senha> Senhas { get; set; }
		public Lista<OrganizacaoUsuario> Organizacoes { get; set; }

		public Usuario()
		{
			Senhas = new Lista<Senha>(i => i.Usuario = this, i => i.Usuario = null);
			Organizacoes = new Lista<OrganizacaoUsuario>(i => i.Usuario = this, i => i.Usuario = null);
		}

		public void AdicionarUsuarioNaOrganizacao(Organizacao organizacao, params Usuario[] usuario)
		{
			if (UsuarioPertenceOrganizacao(organizacao))
				organizacao.AdicionarUsuario(usuario);
		}

		public bool UsuarioPertenceOrganizacao(Organizacao organizacao)
		{
			return (organizacao.Titular == this) || (Owner?.UsuarioPertenceOrganizacao(organizacao) ?? false);
		}

		private IEnumerable<Senha> UltimasSenhas(Int32 quantidade)
		{
			return Senhas.OrderByDescending(s => s.Inclusao).Take(quantidade);
		}

		private String SenhaAtual
		{
			get { return UltimasSenhas(1).Select(s => s.SenhaCriptografada).FirstOrDefault() ?? _senhaNula.Criptografar(); }
		}

		public Senha DefinirSenhaInicial(String novaSenhaCriptografada, String confirmaNovaSenhaCriptografada)
		{
			AssegureQue.EhVazio(Senhas, "Este Usuário já possui uma senha. Não é possível definir nova senha inicial");
			return TrocarSenha(_senhaNula, novaSenhaCriptografada, confirmaNovaSenhaCriptografada);
		}

		public Senha TrocarSenha(String senhaAntigaCriptografada, String novaSenhaCriptografada, String confirmaNovaSenhaCriptografada)
		{
			AssegureQue.NaoEhNulo(senhaAntigaCriptografada, "A senha atual informada não pode ser nula");
			AssegureQue.NaoEhVazio(senhaAntigaCriptografada, "A senha atual informada não pode ser vazia");

			AssegureQue.NaoEhNulo(novaSenhaCriptografada, "A nova senha informada não pode ser nula");
			AssegureQue.NaoEhVazio(novaSenhaCriptografada, "A nova senha informada não pode ser vazia (1)");
			AssegureQue.EhDiferente(novaSenhaCriptografada, _senhaVaziaCriptografada, "A nova senha informada não pode ser vazia (2)");

			AssegureQue.NaoEhNulo(confirmaNovaSenhaCriptografada, "A confirmação da nova senha informada não pode ser nula");
			AssegureQue.NaoEhVazio(confirmaNovaSenhaCriptografada, "A confirmação da nova senha informada não pode ser vazia (1)");
			AssegureQue.EhDiferente(confirmaNovaSenhaCriptografada, _senhaVaziaCriptografada, "A confirmação da nova senha informada não pode ser vazia (2)");

			AssegureQue.EhIgual(novaSenhaCriptografada, confirmaNovaSenhaCriptografada, "A confirmação da nova senha não coincide com a nova senha");
			AssegureQue.EhIgual(senhaAntigaCriptografada.Criptografar(), SenhaAtual, "A senha informada não é a senha atual");

			AssegureQue.EhDiferente(senhaAntigaCriptografada, novaSenhaCriptografada, "A nova senha informada não pode ser a mesma senha atual");
			AssegureQue.EhDiferente(senhaAntigaCriptografada, SenhaAtual, "A nova senha informada não pode ser a mesma senha atual");

			var senhaCriptografada = novaSenhaCriptografada.Criptografar();
			var usouSenhasAnteriores = UltimasSenhas(5).Any(s => s.SenhaCriptografada == senhaCriptografada);
			AssegureQue.EhFalso(usouSenhasAnteriores, "Não é possível trocar a senha por senhas usadas nas últimas 5 trocas de senha");

			var senha = new Senha { SenhaCriptografada = senhaCriptografada };
			Senhas.Adicionar(senha);

			AssegureQue.EhDiferente(senhaAntigaCriptografada.Criptografar(), SenhaAtual, "A senha antiga continua sendo a senha atual");
			AssegureQue.EhIgual(senhaCriptografada, SenhaAtual, "A nova senha informada não pode ser trocada");

			return senha;
		}

		public Boolean ConfirmarSenha(String senhaCriptografada)
		{
			return SenhaAtual == senhaCriptografada.Criptografar();
		}

		public override void EhValido()
		{
			AssegureQue.NaoEhNulo(Nome, "O nome do usuário não pode ser nulo");
			AssegureQue.NaoEhVazio(Nome, "O nome do usuário não pode ser vazio");

			AssegureQue.NaoEhNulo(EMail, "O E-Mail do usuário não pode ser nulo");
			AssegureQue.NaoEhVazio(EMail, "O E-Mail do usuário não pode ser vazio");

			AssegureQue.NaoEhNulo(Celular, "O Celular do usuário não pode ser nulo");
			AssegureQue.NaoEhVazio(Celular, "O Celular do usuário não pode ser vazio");

			var senhaAtual = UltimasSenhas(1).FirstOrDefault();
			AssegureQue.NaoEhNulo(senhaAtual, "A senha atual não pode ser nula!");
			senhaAtual.EhValido();
		}

		public void Preencher(IEnumerable<Senha> senhas)
		{
			foreach (var senha in senhas.OrderBy(s => s.Inclusao))
				Senhas.Adicionar(senha);
		}
	}
}