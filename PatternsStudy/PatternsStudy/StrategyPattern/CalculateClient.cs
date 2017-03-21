namespace PatternsStudy.StrategyPattern
{
	public class CalculateClient
	{
		private ICalculate calculateStrategy;

		//Constructor: assigns strategy to interface
		public CalculateClient(ICalculate strategy)
		{
			calculateStrategy = strategy;
		}

		//Executes strategy
		public int Calculate(int value1, int value2)
		{
			return calculateStrategy.Calculate(value1, value2);
		}
	}
}
