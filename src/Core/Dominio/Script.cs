using MPSC.PlenoSoft.Core.Collections.Generic;
using MPSC.PlenoSoft.Core.Utils.Abstracao;

namespace MPSC.PlenoSoft.MultiTenancy.Core.Dominio
{
	public class Script : Entidade
	{
        public int Versao { get; set; }
        public Lista<DDL> DDLs { get; set; }
		public Sistema Sistema { get; internal set; }

		public Script()
		{
			DDLs = new Lista<DDL>(i => i.Script = this, i => i.Script = null);
		}
	}
}
