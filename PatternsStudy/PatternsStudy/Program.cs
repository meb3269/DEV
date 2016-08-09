using System;
using System.Reflection;
using PatternsStudy.BuilderPattern;

namespace PatternsStudy
{
	class Program
	{
		static void Main(string[] args)
		{
			#region BuilderPattern

			Person p = new PersonBuilder()
				.withName("Mike")
				.withAge("21")
				.build();

			string test = p.ToString();

			Person p2 = new PersonBuilder()
				.clone(p)
				.withName("Fred")
				.build();

			#endregion


			#region StrategyPattern



			#endregion


			#region FactoryPattern

			#endregion
		}
	}
}
