using System;

namespace MPSC.PlenoSoft.MultiTenancy.Core.Abstracao
{
	public class Mensagem
	{
		public DateTime DataHora { get; } = DateTime.Now;
		public TipoMensagem Tipo { get; set; }
		public String Descricao { get; set; }
		public String DescricaoDetalhada { get; set; }

		public override string ToString()
		{
			return $"DataHora = {DataHora}, Tipo = {Tipo}, Descricao = {Descricao}, DescricaoDetalhada = {DescricaoDetalhada}";
		}
	}
}
