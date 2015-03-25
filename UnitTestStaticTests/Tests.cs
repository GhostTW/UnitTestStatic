namespace UnitTestStaticTests
{
	using System;
	using System.Threading;
	using NSubstitute;
	using UnitTestStatic;
	using Xunit;

	public class Tests1 : IDisposable
	{
		[Fact]
		public void Test1()
		{
			var expectedTime = new DateTime(2014, 1, 1);

			TimeProvider.Current = Substitute.For<TimeProvider>();
			TimeProvider.Current.Now.Returns(expectedTime);
			//var tp = Substitute.For<TimeProvider>();
			//tp.Now.Returns(expectedTime);
			var sut = new Target();

			new ManualResetEvent(false).WaitOne(2000);

			Assert.Equal(expectedTime, sut.Show());
		}

		public void Dispose()
		{
			TimeProvider.Reset();
		}
	}

	public class Tests2 : IDisposable
	{
		[Fact]
		public void Test2()
		{
			new ManualResetEvent(false).WaitOne(1000);

			var expectedTime = new DateTime(2013, 1, 1);

			//var tp = Substitute.For<TimeProvider>();
			//tp.Now.Returns(expectedTime);

			TimeProvider.Current = Substitute.For<TimeProvider>();
			TimeProvider.Current.Now.Returns(expectedTime);

			var sut = new Target();

			Assert.Equal(expectedTime, sut.Show());
		}

		public void Dispose()
		{
			TimeProvider.Reset();
		}
	}
}
