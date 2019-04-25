using System;
using System.Collections.Generic;

namespace MPSC.PlenoSoft.MultiTenancy.Core.Abstracao
{
	public class FluxArg<TObject> : FluxArg
	{
		public TObject Result { get; set; }
	}

	public class FluxArg : FluxContainer
	{
		private readonly List<Mensagem> _mensagens = new List<Mensagem>();

		public Boolean Status { get; private set; } = true;
		public IEnumerable<Mensagem> Mensagens { get { return _mensagens.ToArray(); } }

		public void Add(Mensagem mensagem)
		{
			_mensagens.Add(mensagem);
		}

		public void AddTrack(string descricao)
		{
			Add(new Mensagem { Descricao = descricao, DescricaoDetalhada = $"{(Status ? "Sim" : "Não")} - {descricao}", Tipo = TipoMensagem.Track });
		}

		public void AddValidation(string mensagem, string descricaoDetalhada = null)
		{
			Status = false;
			Add(new Mensagem { Descricao = mensagem, DescricaoDetalhada = descricaoDetalhada ?? mensagem, Tipo = TipoMensagem.Validacao });
		}

		public Exception AddException(Exception exception)
		{
			Status = false;
			Add(new Mensagem { Descricao = exception.Message, DescricaoDetalhada = exception.Message, Tipo = TipoMensagem.Exception });
			return exception;
		}
	}
}