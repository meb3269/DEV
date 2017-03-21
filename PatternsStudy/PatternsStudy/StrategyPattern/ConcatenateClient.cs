namespace PatternsStudy.StrategyPattern
{
	public class ConcatenateClient
	{
		private IConcatenate concatenateStrategy;

		//Constructor: assigns strategy to interface
		public ConcatenateClient(IConcatenate strategy)
		{
			concatenateStrategy = strategy;
		}

		//Executes strategy
		public string Concatenate(string value1, string value2)
		{
			return concatenateStrategy.Concat(value1, value2);
		}
	}
}
