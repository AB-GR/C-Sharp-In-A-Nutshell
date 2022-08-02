using System.Text;

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
			int i1 = 32;
			System.Int32 j1 = 32;

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
				int a10 = int.MinValue;
				//a--;
				Console.WriteLine(a10 == int.MaxValue); // True
			}

			unchecked {
				int a12 = int.MinValue;
				a12--;
				Console.WriteLine(a12 == int.MaxValue); // True
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


			char[] vowels = new char[] { 'a', 'e', 'i', 'o', 'u' };

			// Or
			char[] vowels1 = { 'a', 'e', 'i', 'o', 'u' };
			Index last = ^1;
			Index first = 0;
			var firstElement = vowels1[first];
			var lastElement = vowels1[last];
			var secondLastElement = vowels1[^2];

			char[] firstTwo = vowels[..2];    // 'a', 'e'
			char[] lastThree = vowels[2..];    // 'i', 'o', 'u'
			char[] middleOne = vowels[2..3];   // 'i'
			char[] lastTwo = vowels[^2..];     // 'o', 'u'
			Range firstTwoRange = 0..2;
			char[] firstTwoWithRange = vowels[firstTwoRange];   // 'a', 'e'

			//var error = vowels1[^0]; //^0 represents the length of the array, so results in IndexOutOfRange Exception

			// An array itself is always a reference type object, regardless of the element type. For instance, the following is legal:
			int[] a = null;

			// Rectangular array
			int[,] matrix = new int[3, 3];
			for (int i = 0; i < matrix.GetLength(0); i++)
				for (int j = 0; j < matrix.GetLength(1); j++)
					matrix[i, j] = i * 3 + j;

			int[,] matrix1 = new int[,]
							{
							  {0,1,2},
							  {3,4,5},
							  {6,7,8}
							};

			// jagged
			int[][] jaggedMatrix = new int[3][];
			for (int i = 0; i < jaggedMatrix.Length; i++)
			{
				jaggedMatrix[i] = new int[3];                    // Create inner array
				for (int j = 0; j < jaggedMatrix[i].Length; j++)
					jaggedMatrix[i][j] = i * 3 + j;
			}

			int[][] jaggedMatrix1 = new int[][]
							{
							  new int[] {0,1,2},
							  new int[] {3,4,5},
							  new int[] {6,7,8,9}
							};

			// Implicit typing can be taken one stage further with arrays: you can omit the type qualifier after the new keyword and have the compiler infer the array type:
			var vowels2 = new[] { 'a', 'e', 'i', 'o', 'u' };   // Compiler infers char[]
			//Split("Abhilash G Raja", out string x1, out _);// _ is a discard
			//Console.WriteLine(x1);

			//For backward compatibility, this language feature will not take effect if a real underscore variable is in scope:
			string _;
			Split("Stevie Ray Vaughan", out string x2, out _);
			Console.WriteLine(_);     // Vaughan

			//An in parameter is similar to a ref parameter except that the argument’s value cannot be modified by the method (doing so generates a compile-time error)
			int[] ints = { 1, 2, 3, 4 };
			ref int ref2 = ref ints[2];
			Console.WriteLine(ints[2]);
			ref2++;
			Console.WriteLine(ints[2]);

			ref var ref3 = ref GetRandomStringValue();
			Console.WriteLine(randomStringValue);
			ref3 = "Not so random";
			Console.WriteLine(randomStringValue);

			var ref4 = GetRandomStringValueReadOnly();
			ref4 = "dfdf";
			Console.WriteLine(randomStringValue);
			MyMethod(new("Hello"));//Target typed new Expressions

			string foo = null;
			char? c = foo?[1];  // c is null
			GuessTheType(true);
			GuessTheType("Hello");
			Console.WriteLine(GuessTheCard(13));

		}
		static void MyMethod(StringBuilder str)
		{

		}

		static string GuessTheCard(int card) => card switch { 
			13 => "King",
			12 => "Queen",
			11 => "Jack",
			_ => "Pip Card"
		};

		static void GuessTheType(object x)
		{
			switch(x)
			{
				case bool b when true:
					Console.WriteLine($"Is a bool with value {b}");
					break;
				default:
					Console.WriteLine("Unknown");
					break;
			}
		}

		static ref string RandomStringProp => ref randomStringValue;

		static ref string GetRandomStringValue()
			=> ref randomStringValue;

		static ref readonly string GetRandomStringValueReadOnly()
			=> ref randomStringValue;

		static string randomStringValue = "Random Value";

		static void Split(string name, out string firstNames, out string lastName)
		{
			int i = name.LastIndexOf(' ');
			firstNames = name.Substring(0, i);
			lastName = name.Substring(i + 1);
		}
	}

	public struct Point { public int X, Y; }

	public class PointRef { public int X, Y; }
}
