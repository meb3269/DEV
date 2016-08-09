using System;
using System.Reflection;
using PatternsStudy.Utils;

namespace PatternsStudy.BuilderPattern
{
	public class Person : ICloneable
	{
		public Person()
		{
			name = String.Empty;
			age = String.Empty;
		}

		private string name;
		private string age;

		public string Name
		{
			get { return name; }
			set { name = value; }
		}

		public string Age
		{
			get { return age; }
			set { age = value; }
		}

		public override string ToString()
		{
			return this.ToJSONString();
		}

		//Not part of the builder pattern extending object functionality
		public PropertyInfo[] GetProperties()
		{
			return this.GetType().GetProperties();
		}

		//Not part of the builder pattern extending object functionality
		public object Clone()
		{
			return this.MemberwiseClone();
		}
	}
}
