using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternsStudy.Extensions
{
	public static class Extension
	{
		public static T CastTo<T>(this Object value, T targetType)
		{
			// targetType above is just for compiler magic
			// to infer the type to cast x to
			return (T)value;
		}
	}
}