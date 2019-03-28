using MPSC.PlenoSoft.Core.Utils.Abstracao;
using System;

namespace MPSC.PlenoSoft.MultiTenancy.Core.Dominio
{
    public class OrganizacaoUsuario : Entidade
	{
        public Organizacao Organizacao { get; set; }
        public Usuario Usuario { get; set; }
        public DateTime InicioVigencia { get; set; }
        public DateTime FinalVigencia { get; set; }
    }
}
