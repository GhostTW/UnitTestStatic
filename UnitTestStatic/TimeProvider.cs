namespace UnitTestStatic
{
	using System;

	public abstract class TimeProvider
	{
		private static TimeProvider defaultProvider = new Default();

		private static TimeProvider current = defaultProvider;

		public static TimeProvider Current
		{
			get { return current; }

			set
			{
				if (value == null)
				{
					throw new ArgumentNullException("Can not set null value.");
				}

				current = value;
			}
		}

		public static void Reset() { current = defaultProvider; }

		public abstract DateTime Now { get; }

		private class Default : TimeProvider
		{
			public override DateTime Now { get { return DateTime.Now; } }
		}
	}
}