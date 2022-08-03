namespace CSharpExercises
{
	internal class CreatingTypes
	{
		public static void RunExamples()
		{
			//a deconstructor does the reverse and assigns fields back to a set of variables.
			var rect = new Rectangle(3, 4);
			(float width, float height) = rect; // Deconstruction
			WriteLine(width + " " + height);    // 3 4

			var note = new Note { Pitch = 50 };
			//note.Pitch = 200;  // Error – init-only setter!
		}

		// the following pairs of methods cannot coexist in the same type, because the return type and the params modifier are not part of a method’s signature
		void Goo(int[] x) {}

		//void Goo(params int[] x) {}

		void Foo(int x) {}
		void Foo(ref int x) {}     // OK so far
		//void Foo(out int x) {}     // Compile-time error
	}

	// From C# 9, you can declare a property accessor with init instead of set:
	// These init-only properties act like read-only properties, except that they can also be set via an object initializer:
	// Should the class be part of a public library, this approach makes versioning difficult, in that adding an optional parameter to the constructor at a later date breaks binary compatibility with consumers (whereas adding a new init-only property breaks nothing).
	public class Note
	{
		// Notice that the _pitch field is read-only: init-only setters are permitted to modify readonly fields in their own class. (Without this feature, _pitch would need to be writable, and the class would fail at being internally immutable.)
		readonly int _pitch;
		public int Pitch { get => _pitch; init => _pitch = value; }

		public int Duration { get; init; } = 100;  // “Init-only” property
	}


	class Rectangle
	{
		public readonly float Width, Height;

		//You can use a deconstructing assignment to simplify your class’s constructor:
		public Rectangle(float width, float height) 
			=> (Width, Height) = (width, height);

		public void Deconstruct(out float width, out float height)
		{
			width = Width;
			height = Height;
		}
	}

	public class Wine
	{
		public decimal Price;
		public int Year;
		public Wine(decimal price) { Price = price; }

		// When one constructor calls another, the called constructor executes first.
		public Wine(decimal price, int year) : this(price) { Year = year; }
	}

	class Player
	{
		//Field initializations occur before the constructor is executed, and in the declaration order of the fields.
		int shields = 50;   // Initialized first
		int health = 100;   // Initialized second
	}
}
