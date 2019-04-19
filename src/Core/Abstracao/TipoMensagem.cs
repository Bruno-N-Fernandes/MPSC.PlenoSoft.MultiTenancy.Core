using System;

namespace MPSC.PlenoSoft.MultiTenancy.Core.Abstracao
{
	[Flags]
	public enum TipoMensagem
	{
		Informação = 1,
		Alerta = 2,
		Validacao = 4,
		Exception = 8,
		Sistema = 16,
		Track = 32,
	}
}
