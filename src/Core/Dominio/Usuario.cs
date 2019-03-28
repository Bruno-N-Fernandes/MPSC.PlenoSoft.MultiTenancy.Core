using MPSC.PlenoSoft.Core.Collections.Generic;
using MPSC.PlenoSoft.Core.Utils.Abstracao;
using System;

namespace MPSC.PlenoSoft.MultiTenancy.Core.Dominio
{
	public class Usuario : Entidade
	{
        public Usuario Owner { get; set; }
        public String Nome { get; set; }
        public String EMail { get; set; }
        public String Telefone { get; set; }
        public Lista<Senha> Senhas { get; set; }

		public Usuario()
		{
			Senhas = new Lista<Senha>(i => i.Usuario = this, i => i.Usuario = null);
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
    }
}