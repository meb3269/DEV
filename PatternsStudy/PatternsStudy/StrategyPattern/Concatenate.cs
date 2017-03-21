using System.Text;

namespace PatternsStudy.StrategyPattern
{
	public class Concatenate : IConcatenate
	{
		public string Concat(string value1, string value2)
		{
			StringBuilder sb = new StringBuilder();
			sb.AppendFormat("{0} {1}", value1, value2);

			return sb.ToString();
		}

		//Build ConcatCSV functionality - takes a list and builds csv string
	}
}
