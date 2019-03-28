using MPSC.PlenoSoft.Core.Collections.Generic;
using MPSC.PlenoSoft.Core.Utils.Abstracao;
using System;

namespace MPSC.PlenoSoft.MultiTenancy.Core.Dominio
{
	public class Organizacao : Entidade
	{
		public String RazaoSocial { get; set; }

		public Usuario Titular { get; set; }

		public Lista<OrganizacaoSistema> Sistemas { get; set; }

		public Lista<OrganizacaoUsuario> Usuarios { get; set; }

		public Organizacao()
		{
			Sistemas = new Lista<OrganizacaoSistema>(i => i.Organizacao = this, i => i.Organizacao = null);
			Usuarios = new Lista<OrganizacaoUsuario>(i => i.Organizacao = this, i => i.Organizacao = null);
		}

		public void AdicionarUsuario(params Usuario[] usuarios)
		{
			foreach (var usuario in usuarios)
			{
				var organizacaoUsuario = new OrganizacaoUsuario() { Usuario = usuario, InicioVigencia = DateTime.Now };
				Usuarios.Adicionar(organizacaoUsuario);
			}
		}
	}
}
