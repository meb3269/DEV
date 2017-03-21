using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternsStudy.StrategyPattern
{
	public interface IStrategy
	{
		int Calculate(int value1, int value2);

		string Concat(string s1, string s2);
	}
}