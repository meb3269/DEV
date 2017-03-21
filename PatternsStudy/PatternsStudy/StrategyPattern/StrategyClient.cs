using System;
using PatternsStudy.Extensions;

namespace PatternsStudy.StrategyPattern
{
	public class StrategyClient
	{
		private ICalculate calculateStrategy;
		private IConcatenate concatenateStrategy;

		//Default Constructor
		public StrategyClient(ICalculate strategy)
		{
			calculateStrategy = strategy;
		}

		public StrategyClient(IConcatenate concatenate)
		{
			concatenateStrategy = concatenate;
		}

		//Executes Calculate Strategy
		public int Calculate(int value1, int value2)
		{
			return calculateStrategy.Calculate(value1, value2);
		}

		//Executes Concatenate Strategy
		public string Concatenate(string value1, string value2)
		{
			return concatenateStrategy.Concat(value1, value2);
		}
	}

	public class StrategyClientGen<T>
	{
		private readonly IStrategyGen<T> _strategyGen;

		public StrategyClientGen(IStrategyGen<T> strategyGen)
		{
			_strategyGen = strategyGen;
		}

		public T Execute(T rh, T lh)
		{
			return _strategyGen.Execute(rh, lh);
		}
	}

	public interface IStrategyGen<T>
	{
		T Execute(T rh, T lh);
	}

	//public class ConCat : IStrategyGen<ConCat>
	//{
		//public ConCat Execute(ConCat rh, ConCat lh)
		//{
		//	return lh.ConCat(rh);
		//}

		//private ConCat ConCat(ConCat rh)
		//{
		//	reutrn new ConCat();
		//}
	//}
}