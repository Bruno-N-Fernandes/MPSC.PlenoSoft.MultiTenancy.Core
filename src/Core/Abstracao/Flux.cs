using System;

namespace MPSC.PlenoSoft.MultiTenancy.Core.Abstracao
{
	public interface IFluxDo
	{
		IFluxDo Do<T>(String descricao, Func<FluxArg, T> step);
		IFluxDo Do(String descricao, Action<FluxArg> step);
	}

	public class Flux : IFluxDo
	{
		private readonly FluxArg FluxArg;

		public static IFluxDo To(String descricao, out FluxArg fluxArg) => new Flux(descricao, out fluxArg);
		public static IFluxDo With(FluxArg fluxArg, String descricao) => new Flux(descricao, fluxArg);

		private Flux(String descricao, out FluxArg fluxArg)
		{
			FluxArg = fluxArg = new FluxArg();
			FluxArg.AddTrack(descricao);
		}

		private Flux(String descricao, FluxArg fluxArg)
		{
			FluxArg = fluxArg ?? new FluxArg();
			FluxArg.AddTrack(descricao);
		}

		public IFluxDo Do<T>(String descricao, Func<FluxArg, T> acao)
		{
			return Do(descricao, f =>
			{
				var retorno = acao.Invoke(FluxArg);
				f.AddObject(retorno);
			});
		}

		public IFluxDo Do(String descricao, Action<FluxArg> acao)
		{
			FluxArg.AddTrack(descricao);

			if (FluxArg.Status)
			{
				try
				{
					acao?.Invoke(FluxArg);
				}
				catch (Exception exception)
				{
					FluxArg.AddException(exception);
					throw;
				}
			}

			return this;
		}
	}
}