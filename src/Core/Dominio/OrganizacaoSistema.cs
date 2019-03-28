using MPSC.PlenoSoft.Core.Utils.Abstracao;

namespace MPSC.PlenoSoft.MultiTenancy.Core.Dominio
{
    public class OrganizacaoSistema : Entidade
    {
        public Organizacao Organizacao { get; set; }
        public Sistema Sistema { get; set; }
        public Configuracao Configuracao { get; set; }
    }
}
