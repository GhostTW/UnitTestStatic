namespace UnitTestStatic
{
	using System;

	public class Target
	{
		private TimeProvider timeProvider;

		public Target(TimeProvider tp = null) { this.timeProvider = tp ?? TimeProvider.Current; }

		public DateTime Show()
		{
			//return TimeProvider.Current.Now;
			return TimeProvider.Current.Now;
		}
	}
}