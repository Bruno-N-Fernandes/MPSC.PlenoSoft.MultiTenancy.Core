using MPSC.PlenoSoft.Core.Utils.Abstracao;
using System;

namespace MPSC.PlenoSoft.MultiTenancy.Core.Dominio
{
    public class DDL : Entidade
	{
		public Script Script { get; internal set; }
        public String CmdSql { get; set; }
	}
}
