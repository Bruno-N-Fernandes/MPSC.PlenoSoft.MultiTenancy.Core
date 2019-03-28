using MPSC.PlenoSoft.Core.Utils.Abstracao;

namespace MPSC.PlenoSoft.MultiTenancy.Core.Dominio
{
	public class Senha : Entidade
	{
		public Usuario Usuario { get; internal set; }
	}
}