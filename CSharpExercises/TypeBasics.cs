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
		}
	}

	public struct Point { public int X, Y; }

	public class PointRef { public int X, Y; }
}
