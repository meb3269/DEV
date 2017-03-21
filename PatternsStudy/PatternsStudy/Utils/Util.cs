using System;
using System.Text.RegularExpressions;
using Newtonsoft.Json;

namespace PatternsStudy.Utils
{
	public static class Util
	{
		public static string ToJSONString(this object o)
		{
			return JsonConvert.SerializeObject(o, Newtonsoft.Json.Formatting.Indented);
		}

		public static DateTime ToSafeDate(string dateTime)
		{
			try
			{
				return Convert.ToDateTime(dateTime);
			}
			catch (Exception)
			{
				return DateTime.MinValue;
			}
		}

		/// <summary>
		/// Formats a phone number provided in a string and returns the formatted result as a string
		/// </summary>
		/// <param name="value">String representation of a phone number</param>
		/// <returns>Formatted String representation of a phone number</returns>
		/// <businessRule>A U.S. area code will never start with a "0" or "1"</businessRule>
		public static string FormatPhoneNumber(string value)
		{
			if (string.IsNullOrEmpty(value))
			{
				return value;
			}

			if (String.IsNullOrEmpty(new Regex(@"\D").Replace(value, string.Empty)))
			{
				return value;
			}

			value = new Regex(@"\D").Replace(value, string.Empty);//replaces all non-numeric characters
			value = value.TrimStart('0','1'); //Trims a zero or a 1 from first character --Added "0"
			//Do we want to allow for a 1-800 formatting or truncate the 1???

			try
			{
				//Determine the length of the phone number to determine format.
				switch (value.Length)
				{
					case 7:
						return Convert.ToInt64(value).ToString("###-####");
					case 10:
						return Convert.ToInt64(value).ToString("###-###-####");
					default:
						return Convert.ToInt64(value).ToString("###-###-#### " + new String('#', (value.Length - 10)));
					//Do we want to allow for a 1-800 formatting or truncate the 1???
				}
			}
			catch (Exception ex)
			{
				string err = ex.Message;
				return "999-999-9999"; //Or return string.Empty???
			}
		}

		//Not tested yet
		public static string FormatZipCode(string value)
		{
			if (string.IsNullOrEmpty(value))
			{
				return value;
			}

			value = new Regex(@"\D").Replace(value, string.Empty);

			if (value.Length > 5)
			{
				return string.Format("{0}-{1}", value.Substring(0, 5), value.Substring(5, 4));
			}
			return value;
		}
	}
}