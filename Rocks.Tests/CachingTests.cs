﻿using NUnit.Framework;
using Rocks.Options;

namespace Rocks.Tests
{
	public static class CachingTests
	{
		[Test]
		public static void CreateTwoMocksWithCaching()
		{
			var rock1 = Rock.Create<IWillBeCached>(new RockOptions(caching: CachingOption.UseCache));
			rock1.Handle(_ => _.Target(Arg.IsAny<string>()));

			var mock1 = rock1.Make();

			var rock2 = Rock.Create<IWillBeCached>(new RockOptions(caching: CachingOption.UseCache));
			rock2.Handle(_ => _.Target(Arg.IsAny<string>()));

			var mock2 = rock2.Make();

			Assert.That(mock1.GetType(), Is.EqualTo(mock2.GetType()));
		}

		[Test]
		public static void CreateTwoMocksWithoutCaching()
		{
			var rock1 = Rock.Create<IWillNotBeCached>(new RockOptions(caching: CachingOption.UseCache));
			rock1.Handle(_ => _.Target(Arg.IsAny<string>()));

			var mock1 = rock1.Make();

			var rock2 = Rock.Create<IWillNotBeCached>(new RockOptions(caching: CachingOption.GenerateNewVersion));
			rock2.Handle(_ => _.Target(Arg.IsAny<string>()));

			var mock2 = rock2.Make();

			Assert.That(mock1.GetType(), Is.Not.EqualTo(mock2.GetType()));
		}
	}

	public interface IWillBeCached
	{
		void Target(string a);
	}

	public interface IWillNotBeCached
	{
		void Target(string a);
	}
}
