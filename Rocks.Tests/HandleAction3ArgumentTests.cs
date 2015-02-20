﻿using NUnit.Framework;

namespace Rocks.Tests
{
	[TestFixture]
	public sealed class HandleAction3ArgumentTests
	{
		[Test]
		public void Make()
		{
			var rock = Rock.Create<IHandleAction3ArgumentTests>();
			rock.HandleAction(_ => _.Target(44, 44, 44));

			var chunk = rock.Make();
			chunk.Target(44, 44, 44);

			rock.Verify();
		}

		[Test]
		public void MakeWithHandler()
		{
			var wasCalled = false;

			var rock = Rock.Create<IHandleAction3ArgumentTests>();
			rock.HandleAction<int, int, int>(_ => _.Target(44, 44, 44),
				(a, b, c) => wasCalled = true);

			var chunk = rock.Make();
			chunk.Target(44, 44, 44);

			rock.Verify();
			Assert.IsTrue(wasCalled);
		}

		[Test]
		public void MakeWithExpectedCallCount()
		{
			var rock = Rock.Create<IHandleAction3ArgumentTests>();
			rock.HandleAction(_ => _.Target(44, 44, 44), 2);

			var chunk = rock.Make();
			chunk.Target(44, 44, 44);
			chunk.Target(44, 44, 44);

			rock.Verify();
		}

		[Test]
		public void MakeWithHandlerAndExpectedCallCount()
		{
			var wasCalled = false;

			var rock = Rock.Create<IHandleAction3ArgumentTests>();
			rock.HandleAction<int, int, int>(_ => _.Target(44, 44, 44),
				(a, b, c) => wasCalled = true, 2);

			var chunk = rock.Make();
			chunk.Target(44, 44, 44);
			chunk.Target(44, 44, 44);

			rock.Verify();
			Assert.IsTrue(wasCalled);
		}
	}

	public interface IHandleAction3ArgumentTests
	{
		void Target(int a, int b, int c);
	}
}