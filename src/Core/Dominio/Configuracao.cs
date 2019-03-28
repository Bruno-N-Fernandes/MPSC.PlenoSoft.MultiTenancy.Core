using MPSC.PlenoSoft.Core.Utils.Abstracao;
using System;

namespace MPSC.PlenoSoft.MultiTenancy.Core.Dominio
{
    public class Configuracao : Entidade
	{
        public String ConnectionString { get; set; }
    }
}
