using System;
using System.Reflection;
using System.Text;

namespace PatternsStudy.BuilderPattern
{
	public class PersonBuilder
	{
		private Person person = new Person();

		//string sql = String.Empty; //Part of experiment region

		public Person build()
		{
			return person;
		}
		public PersonBuilder withName(string name)
		{
			this.person.Name = name;
			return this;
		}
		public PersonBuilder withAge(string age)
		{
			this.person.Age = age;
			return this;
		}

		//Not part of the builder pattern extending object functionality
		public PersonBuilder clone(Person personToClone)
		{
			Person personClone = new Person();
			personClone = (Person)personToClone.Clone();
			person = personClone;

			return this;
		}

		#region Experiment

		public PersonBuilder createInsert(string table)
		{
			PropertyInfo[] pi = null;
			pi = person.GetProperties();

			StringBuilder sb = new StringBuilder();
			sb.AppendFormat("INSERT INTO {0} (", table);

			foreach (PropertyInfo p in pi)
			{
				var test1 = p.PropertyType.Name.ToString();

				sb.AppendFormat("{0}, ", p.Name.ToLower());
			}

			sb.AppendFormat(") VALUES (");

			foreach (PropertyInfo p in pi)
			{
				//var test1 = p.PropertyType.GetValue();

				//sb.AppendFormat("{0},", p.Name);
			}

			sb.Append(");");

			//sql = sb.ToString();
			return this;
		}

		public string createDropTable(string table)
		{
			StringBuilder sb = new StringBuilder();
			sb.AppendFormat("DROP TABLE {0};", table);

			return sb.ToString();
		}

		public string createTempTable(string table)
		{
			StringBuilder sb = new StringBuilder();
			sb.AppendFormat("CREATE VOLATILE TABLE {0} (name varchar(20) not null,age varchar(3)) ON COMMIT PRESERVE ROWS;", table);

			return sb.ToString();
		}

		//Working on an idea - not finished
		public string createSelect()
		{
			StringBuilder sb = new StringBuilder();


			return sb.ToString();
		}

		#endregion
	}
}
