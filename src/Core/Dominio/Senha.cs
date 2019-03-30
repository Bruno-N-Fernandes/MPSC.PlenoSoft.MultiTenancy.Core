using MPSC.PlenoSoft.Core.Utils.Abstracao;
using System;

namespace MPSC.PlenoSoft.MultiTenancy.Core.Dominio
{
	public class Senha : Entidade
	{
		public Usuario Usuario { get; internal set; }
		public Int64 UsuarioId => Usuario?.Id ?? 0L;
		public String SenhaCriptografada { get; set; }

		public Senha()
		{
			Inclusao = DateTime.UtcNow.AddMilliseconds(_controle++);
		}
	}
}