namespace CSharpExercises
{
	internal class TypeBasics
	{
		public static void RunExamples()
		{
			Console.WriteLine(Int32.MinValue);
			Console.WriteLine(Int32.MaxValue);

			Console.WriteLine(long.MinValue);
			Console.WriteLine(long.MaxValue);

			//Predefined numeric types
			// Unsigned - byte(Byte), ushort(UInt16), uint(UInt32)(0 to 2^32 - 1), ulong(UInt64)
			// Signed - sbyte(SByte), short(Int16), int(Int32)(2^31 to 2^31 - 1), long(Int64) 
			// Real, float(32), decimal(128), double(64)

			// Of the real number types, float and double are called floating-point types2 and are typically used for scientific and graphical calculations. The decimal type is typically used for financial calculations, for which base-10-accurate arithmetic and high precision are required.

			var p1 = new Point();
			p1.X = 1;

			var p2 = p1;
			Console.WriteLine(p2.X);

			p2.X = 2;
			Console.WriteLine(p2.X);
			Console.WriteLine(p1.X);

			Console.WriteLine("----------------------");
			var p1Ref = new PointRef();
			p1Ref.X = 1;

			var p2Ref = p1Ref;
			Console.WriteLine(p2Ref.X);

			p2Ref.X = 2;
			Console.WriteLine(p2Ref.X);
			Console.WriteLine(p2Ref.X);

			//Predefined types in C# alias .NET types in the System namespace
			int i = 32;
			System.Int32 j = 32;

			// Insert _ to make more readable
			int million = 1_000_000;
			var b = 0b1010_1011_1100_1101_1110_1111;
			Console.WriteLine(b);

			double million1 = 1E06;
			Console.WriteLine(million1);

			float f = 4.5F; // Will not compile without F as it will be inferred as double
			decimal d = -1.23M;     // Will not compile without the M suffix.

			//The arithmetic operators (+, -, *, /, %) are defined for all numeric types except the 8- and 16-bit integral types:

			checked
			{
				int a = int.MinValue;
				//a--;
				Console.WriteLine(a == int.MaxValue); // True
			}

			unchecked {
				int a = int.MinValue;
				a--;
				Console.WriteLine(a == int.MaxValue); // True
			}

			int y = unchecked(int.MaxValue + 1);

			// string is a reference type rather than a value type. Its equality operators, however, follow value-type semantics:
			string a1 = "test";
			string b1 = "test";
			Console.Write(a1 == b1);  // True

			string a2 = "\\\\server\\fileshare\\helloworld.cs";
			Console.WriteLine(a2);
			string a3 = @"\\server\fileshare\helloworld.cs";
			Console.WriteLine(a3);

			string verbatim = @"First Line
Second Line";
			Console.WriteLine(verbatim);

			//You can include the double-quote character in a verbatim literal by writing it twice:
			string xml = @"<customer id=""123""></customer>";
			Console.WriteLine(xml);

			string s = "a" + 5;  // a5

			string s2 = $"255 in hex is {byte.MaxValue:X2}";  // X2 = 2-digit hexadecimal
															 // Evaluates to "255 in hex is FF"

			bool b2 = true;
			Console.WriteLine($"The answer in binary is {(b2 ? 1 : 0)}");

			//Interpolated strings must complete on a single line, unless you also specify the verbatim string operator:

			int x = 2;
			// Note that $ must appear before @ prior to C# 8:
			string s3 = $@"this interpolation spans {
				x} lines";

			const string greeting = "Hello";
			const string message = $"{greeting}, world";
		}
	}

	public struct Point { public int X, Y; }

	public class PointRef { public int X, Y; }
}
