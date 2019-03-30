using MPSC.PlenoSoft.Core.Collections.Generic;
using MPSC.PlenoSoft.Core.Utils.Abstracao;
using System;

namespace MPSC.PlenoSoft.MultiTenancy.Core.Dominio
{
	public class Sistema : Entidade
	{
        public String Sigla { get; set; }
        public String Nome { get; set; }
        public String UltimaVersaoSistema { get; set; }
        public String UltimaVersaoBanco { get; set; }

        public Lista<Script> Scripts { get; set; }
        public Lista<OrganizacaoSistema> Organizacoes { get; set; }

		public Sistema()
		{
			Scripts = new Lista<Script>(i => i.Sistema = this, i => i.Sistema = null);
			Organizacoes = new Lista<OrganizacaoSistema>(i => i.Sistema = this, i => i.Sistema = null);
		}
	}
}
