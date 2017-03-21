using System;
using System.Collections.Generic;
using System.Diagnostics;
using PatternsStudy.BuilderPattern;
using PatternsStudy.FactoryPattern;
using PatternsStudy.StrategyPattern;
using PatternsStudy.Utils;

namespace PatternsStudy
{
	class Program
	{
		static void Main(string[] args)
		{
			#region Util Tests

			//DateTime testDate = Util.ToSafeDate("1/1/2000 1:00PM");
			//Console.WriteLine("Test date: {0}", testDate);

			string emptyString = Util.FormatPhoneNumber(" ");
			string tenDigitNoCharsStartingWithOne = Util.FormatPhoneNumber("1234567890"); //with bogus area code
			string tenDigitWithCharsStartingwithOne = Util.FormatPhoneNumber("123-456-7890"); //with bogus area code with dashes
			string eightHundredNumberNoChars = Util.FormatPhoneNumber("18001234567"); //800 number
			string eightHundredNumberWithChars = Util.FormatPhoneNumber("1-800-123-1234"); //800 number with dashes
			string sevenDigitNoChars = Util.FormatPhoneNumber("3824336"); //standard phone number with no area code no dashes
			string sevenDigitWithChars = Util.FormatPhoneNumber("382.4336"); //standard phone number with no area code with chars

			//Success returns string.Empty
			Console.WriteLine("Empty string: '{0}'", emptyString);

			//First digit removed and hits default in the case statement and get a negative number error
			Console.WriteLine("10 digit phone number no chars: {0}", tenDigitNoCharsStartingWithOne);

			//First digit removed also dashes removed and hits the default in the case statement and get a negative number error
			Console.WriteLine("10 digit phone number with chars: {0}", tenDigitWithCharsStartingwithOne);

			//First digit removed and hits the default in the case statement and get a negative number error
			Console.WriteLine("1-800 phone number with no chars: {0}", eightHundredNumberNoChars);

			//First digit removed also dashes removed and hits the default in the case statement and get a negative number error
			Console.WriteLine("1-800 phone number with chars: {0}", eightHundredNumberWithChars);

			//Success
			Console.WriteLine("Seven digit phone number no chars: {0}", sevenDigitNoChars);

			//Success
			Console.WriteLine("Seven digit phone number with chars: {0}", sevenDigitWithChars);

			Console.WriteLine("\n");
			//Console.ReadKey();

			#endregion


			#region BuilderPattern

			Person p = new PersonBuilder()
				.withName("Mike")
				.withAge("21")
				.build();

			string test = p.ToString();

			Console.WriteLine("Builder Pattern - person 1: {0}", test);

			Person p2 = new PersonBuilder()
				.clone(p)
				.withName("Fred")
				.build();

			Console.WriteLine("\n");

			#endregion


			#region StrategyPattern

			CalculateClient minusClient = new CalculateClient(new Minus());
			string minusTest = minusClient.Calculate(7, 1).ToString();

			CalculateClient plusClient = new CalculateClient(new Plus());
			string plusTest = plusClient.Calculate(2, 2).ToString();

			ConcatenateClient concatClient = new ConcatenateClient(new Concatenate());
			string concatTest = concatClient.Concatenate("Fred", "Flintstone");

			Console.WriteLine("Subtraction Example result: {0}", minusTest);
			Console.WriteLine("Addition Example result: {0}", plusTest);
			Console.WriteLine("Concatenation Example result: {0}", concatTest);

			StrategyClient anonCalcClientMinus = new StrategyClient(new Minus());
			string anonMinusTest = anonCalcClientMinus.Calculate(5, 2).ToString();

			StrategyClient anonCalcClientPlus = new StrategyClient(new Plus());
			string anonPlusTest = anonCalcClientPlus.Calculate(2, 2).ToString();

			StrategyClient anonConcatClient = new StrategyClient(new Concatenate());
			string anonConcatTest = anonConcatClient.Concatenate("Wilma", "Flintstone");

			Console.WriteLine("Anonymous Subtraction Example result: {0}", anonMinusTest);
			Console.WriteLine("Anonymous Addition Example result: {0}", anonPlusTest);
			Console.WriteLine("Anonymous Concatenation Example result: {0}", anonConcatTest);

			Console.WriteLine("\n");
			//Console.ReadKey();

			#endregion


			#region FactoryPattern

			for (int i = 0; i <= 3; i++)
			{
				var position = Factory.Get(i);
				Console.WriteLine("Factory Pattern - Where id = {0}, position = {1} ", i, position.Title);
			}

			Console.WriteLine("\n");
			//Console.ReadKey();

			#endregion


			#region Read File

			// Read the file as one string.
			string text = System.IO.File.ReadAllText(@"C:\Test\ReadMe.txt");

			// Display the file contents to the console. Variable text is a string.
			System.Console.WriteLine("\nContents of ReadMe.txt: \n{0}", text);

			// Read each line of the file into a string array. Each element
			// of the array is one line of the file.
			string[] lines = System.IO.File.ReadAllLines(@"C:\Test\ReadMe2.txt");

			// Display the file contents by using a foreach loop.
			System.Console.WriteLine("\nContents of ReadMe2.txt = ");
			foreach (string line in lines)
			{
				// Use a tab to indent each line of the file.
				Console.WriteLine("\t" + line);
			}

			// Keep the console window open in debug mode.
			//Console.WriteLine("\n Press any key to exit.");
			//System.Console.ReadKey();

			#endregion


			#region Content Filter

			string testData = "<html><head><title>Test Content</title></head><body><p class=\"data\"><p class=\"data\"><u>Test</u></p></p><div class=\"hide\">1</div></body></html>";

			string testData2 = "<html><head><title>Test Content</title></head><body><div><u>Underline</u></div><p>paragraph</p><div class=\"hide\">1</div></body></html>";

			string testData3 =
				"<html><head><title>Test Content</title></head><body><div class=\"something\"><div class=\"something\">ya ya</div><div class=\"testClass\">Hello</div><a class=\"testClass\"><span class=\"geez\">amount</span></a></div></body></html>";

			string result = ContentFilter.HtmlFilter(testData3, "div", "something", true);

			//List<string> tags = new List<string>();
			//tags.Add("<div class=\"hide\">.*?</div>"); //Removes specified tag and content

			//string result = ContentFilter.RemoveNonPrintTags(testData, tags);

			//List<string> tags2 = new List<string>();
			//tags2.Add("(</?b>|</?p>|</?i>|</?u>)"); //Removes specified tag and leaves the content

			//string tagResult = ContentFilter.RemoveNonPrintTags(testData2, tags2);

			//List<string> chars = new List<string>();
			//chars.Add("<u>");
			//chars.Add("</u>");

			//string charResult = ContentFilter.RemoveNonPrintChars(testData, chars);

			//Console.WriteLine("\n");
			//Console.WriteLine("Original Content: " + testData);
			//Console.WriteLine("\n");
			//Console.WriteLine("Filtered Content: " + result);
			//Console.WriteLine("\n");
			//Console.WriteLine("Char Filtered Content: " + charResult);
			//Console.WriteLine("\n");
			//Console.WriteLine("Tags2 Filtered Content: " + tagResult);

			Console.WriteLine("\n");
			Console.WriteLine("Filtered Content: " + result);

			Console.ReadKey();

			#endregion
		}
	}
}