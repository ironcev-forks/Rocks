﻿using NUnit.Framework;
using System;

namespace Rocks.Tests
{
	public static class HandleFunc13ArgumentTests
	{
		[Test]
		public static void Make()
		{
			var rock = Rock.Create<IHandleFunc13ArgumentTests>();
			rock.Handle(_ => _.ReferenceTarget(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13));
			rock.Handle(_ => _.ValueTarget(10, 20, 30, 40, 50, 60, 70, 80, 90, 100, 110, 120, 130));

			var chunk = rock.Make();
			chunk.ReferenceTarget(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13);
			chunk.ValueTarget(10, 20, 30, 40, 50, 60, 70, 80, 90, 100, 110, 120, 130);

			rock.Verify();
		}

		[Test]
		public static void MakeAndRaiseEvent()
		{
			var rock = Rock.Create<IHandleFunc13ArgumentTests>();
			var referenceAdornment = rock.Handle(_ => _.ReferenceTarget(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13));
			referenceAdornment.Raises(nameof(IHandleFunc13ArgumentTests.TargetEvent), EventArgs.Empty);
			var valueAdornment = rock.Handle(_ => _.ValueTarget(10, 20, 30, 40, 50, 60, 70, 80, 90, 100, 110, 120, 130));
			valueAdornment.Raises(nameof(IHandleFunc13ArgumentTests.TargetEvent), EventArgs.Empty);

			var eventRaisedCount = 0;
			var chunk = rock.Make();
			chunk.TargetEvent += (s, e) => eventRaisedCount++;
			chunk.ReferenceTarget(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13);
			chunk.ValueTarget(10, 20, 30, 40, 50, 60, 70, 80, 90, 100, 110, 120, 130);

			Assert.That(eventRaisedCount, Is.EqualTo(2));
			rock.Verify();
		}

		[Test]
		public static void MakeWithHandler()
		{
			var argumentA = 0;
			var argumentB = 0;
			var argumentC = 0;
			var argumentD = 0;
			var argumentE = 0;
			var argumentF = 0;
			var argumentG = 0;
			var argumentH = 0;
			var argumentI = 0;
			var argumentJ = 0;
			var argumentK = 0;
			var argumentL = 0;
			var argumentM = 0;
			var stringReturnValue = "a";
			var intReturnValue = 1;

			var rock = Rock.Create<IHandleFunc13ArgumentTests>();
			rock.Handle<int, int, int, int, int, int, int, int, int, int, int, int, int, string>(_ => _.ReferenceTarget(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13),
				(a, b, c, d, e, f, g, h, i, j, k, l, m) => { argumentA = a; argumentB = b; argumentC = c; argumentD = d; argumentE = e; argumentF = f; argumentG = g; argumentH = h; argumentI = i; argumentJ = j; argumentK = k; argumentL = l; argumentM = m; return stringReturnValue; });
			rock.Handle<int, int, int, int, int, int, int, int, int, int, int, int, int, int>(_ => _.ValueTarget(10, 20, 30, 40, 50, 60, 70, 80, 90, 100, 110, 120, 130),
				(a, b, c, d, e, f, g, h, i, j, k, l, m) => { argumentA = a; argumentB = b; argumentC = c; argumentD = d; argumentE = e; argumentF = f; argumentG = g; argumentH = h; argumentI = i; argumentJ = j; argumentK = k; argumentL = l; argumentM = m; return intReturnValue; });
			
			var chunk = rock.Make();
			Assert.That(chunk.ReferenceTarget(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13),
				Is.EqualTo(stringReturnValue), nameof(chunk.ReferenceTarget));
			Assert.That(argumentA, Is.EqualTo(1), nameof(argumentA));
			Assert.That(argumentB, Is.EqualTo(2), nameof(argumentB));
			Assert.That(argumentC, Is.EqualTo(3), nameof(argumentC));
			Assert.That(argumentD, Is.EqualTo(4), nameof(argumentD));
			Assert.That(argumentE, Is.EqualTo(5), nameof(argumentE));
			Assert.That(argumentF, Is.EqualTo(6), nameof(argumentF));
			Assert.That(argumentG, Is.EqualTo(7), nameof(argumentG));
			Assert.That(argumentH, Is.EqualTo(8), nameof(argumentH));
			Assert.That(argumentI, Is.EqualTo(9), nameof(argumentI));
			Assert.That(argumentJ, Is.EqualTo(10), nameof(argumentJ));
			Assert.That(argumentK, Is.EqualTo(11), nameof(argumentK));
			Assert.That(argumentL, Is.EqualTo(12), nameof(argumentL));
			Assert.That(argumentM, Is.EqualTo(13), nameof(argumentM));
			argumentA = 0;
			argumentB = 0;
			argumentC = 0;
			argumentD = 0;
			argumentE = 0;
			argumentF = 0;
			argumentG = 0;
			argumentH = 0;
			argumentI = 0;
			argumentJ = 0;
			argumentK = 0;
			argumentL = 0;
			argumentM = 0;
			Assert.That(chunk.ValueTarget(10, 20, 30, 40, 50, 60, 70, 80, 90, 100, 110, 120, 130),
				Is.EqualTo(intReturnValue), nameof(chunk.ValueTarget));
			Assert.That(argumentA, Is.EqualTo(10), nameof(argumentA));
			Assert.That(argumentB, Is.EqualTo(20), nameof(argumentB));
			Assert.That(argumentC, Is.EqualTo(30), nameof(argumentC));
			Assert.That(argumentD, Is.EqualTo(40), nameof(argumentD));
			Assert.That(argumentE, Is.EqualTo(50), nameof(argumentE));
			Assert.That(argumentF, Is.EqualTo(60), nameof(argumentF));
			Assert.That(argumentG, Is.EqualTo(70), nameof(argumentG));
			Assert.That(argumentH, Is.EqualTo(80), nameof(argumentH));
			Assert.That(argumentI, Is.EqualTo(90), nameof(argumentI));
			Assert.That(argumentJ, Is.EqualTo(100), nameof(argumentJ));
			Assert.That(argumentK, Is.EqualTo(110), nameof(argumentK));
			Assert.That(argumentL, Is.EqualTo(120), nameof(argumentL));
			Assert.That(argumentM, Is.EqualTo(130), nameof(argumentM));

			rock.Verify();
		}

		[Test]
		public static void MakeWithExpectedCallCount()
		{
			var rock = Rock.Create<IHandleFunc13ArgumentTests>();
			rock.Handle(_ => _.ReferenceTarget(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13), 2);
			rock.Handle(_ => _.ValueTarget(10, 20, 30, 40, 50, 60, 70, 80, 90, 100, 110, 120, 130), 2);

			var chunk = rock.Make();
			chunk.ReferenceTarget(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13);
			chunk.ReferenceTarget(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13);
			chunk.ValueTarget(10, 20, 30, 40, 50, 60, 70, 80, 90, 100, 110, 120, 130);
			chunk.ValueTarget(10, 20, 30, 40, 50, 60, 70, 80, 90, 100, 110, 120, 130);

			rock.Verify();
		}

		[Test]
		public static void MakeWithHandlerAndExpectedCallCount()
		{
			var argumentA = 0;
			var argumentB = 0;
			var argumentC = 0;
			var argumentD = 0;
			var argumentE = 0;
			var argumentF = 0;
			var argumentG = 0;
			var argumentH = 0;
			var argumentI = 0;
			var argumentJ = 0;
			var argumentK = 0;
			var argumentL = 0;
			var argumentM = 0;
			var stringReturnValue = "a";
			var intReturnValue = 1;

			var rock = Rock.Create<IHandleFunc13ArgumentTests>();
			rock.Handle<int, int, int, int, int, int, int, int, int, int, int, int, int, string>(_ => _.ReferenceTarget(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13),
				(a, b, c, d, e, f, g, h, i, j, k, l, m) => { argumentA = a; argumentB = b; argumentC = c; argumentD = d; argumentE = e; argumentF = f; argumentG = g; argumentH = h; argumentI = i; argumentJ = j; argumentK = k; argumentL = l; argumentM = m; return stringReturnValue; }, 2);
			rock.Handle<int, int, int, int, int, int, int, int, int, int, int, int, int, int>(_ => _.ValueTarget(10, 20, 30, 40, 50, 60, 70, 80, 90, 100, 110, 120, 130),
				(a, b, c, d, e, f, g, h, i, j, k, l, m) => { argumentA = a; argumentB = b; argumentC = c; argumentD = d; argumentE = e; argumentF = f; argumentG = g; argumentH = h; argumentI = i; argumentJ = j; argumentK = k; argumentL = l; argumentM = m; return intReturnValue; }, 2);

			var chunk = rock.Make();
			Assert.That(chunk.ReferenceTarget(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13),
				Is.EqualTo(stringReturnValue), nameof(chunk.ReferenceTarget));
			Assert.That(argumentA, Is.EqualTo(1), nameof(argumentA));
			Assert.That(argumentB, Is.EqualTo(2), nameof(argumentB));
			Assert.That(argumentC, Is.EqualTo(3), nameof(argumentC));
			Assert.That(argumentD, Is.EqualTo(4), nameof(argumentD));
			Assert.That(argumentE, Is.EqualTo(5), nameof(argumentE));
			Assert.That(argumentF, Is.EqualTo(6), nameof(argumentF));
			Assert.That(argumentG, Is.EqualTo(7), nameof(argumentG));
			Assert.That(argumentH, Is.EqualTo(8), nameof(argumentH));
			Assert.That(argumentI, Is.EqualTo(9), nameof(argumentI));
			Assert.That(argumentJ, Is.EqualTo(10), nameof(argumentJ));
			Assert.That(argumentK, Is.EqualTo(11), nameof(argumentK));
			Assert.That(argumentL, Is.EqualTo(12), nameof(argumentL));
			Assert.That(argumentM, Is.EqualTo(13), nameof(argumentM));
			argumentA = 0;
			argumentB = 0;
			argumentC = 0;
			argumentD = 0;
			argumentE = 0;
			argumentF = 0;
			argumentG = 0;
			argumentH = 0;
			argumentI = 0;
			argumentJ = 0;
			argumentK = 0;
			argumentL = 0;
			argumentM = 0;
			Assert.That(chunk.ReferenceTarget(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13),
				Is.EqualTo(stringReturnValue), nameof(chunk.ReferenceTarget));
			Assert.That(argumentA, Is.EqualTo(1), nameof(argumentA));
			Assert.That(argumentB, Is.EqualTo(2), nameof(argumentB));
			Assert.That(argumentC, Is.EqualTo(3), nameof(argumentC));
			Assert.That(argumentD, Is.EqualTo(4), nameof(argumentD));
			Assert.That(argumentE, Is.EqualTo(5), nameof(argumentE));
			Assert.That(argumentF, Is.EqualTo(6), nameof(argumentF));
			Assert.That(argumentG, Is.EqualTo(7), nameof(argumentG));
			Assert.That(argumentH, Is.EqualTo(8), nameof(argumentH));
			Assert.That(argumentI, Is.EqualTo(9), nameof(argumentI));
			Assert.That(argumentJ, Is.EqualTo(10), nameof(argumentJ));
			Assert.That(argumentK, Is.EqualTo(11), nameof(argumentK));
			Assert.That(argumentL, Is.EqualTo(12), nameof(argumentL));
			Assert.That(argumentM, Is.EqualTo(13), nameof(argumentM));
			argumentA = 0;
			argumentB = 0;
			argumentC = 0;
			argumentD = 0;
			argumentE = 0;
			argumentF = 0;
			argumentG = 0;
			argumentH = 0;
			argumentI = 0;
			argumentJ = 0;
			argumentK = 0;
			argumentL = 0;
			argumentM = 0;
			Assert.That(chunk.ValueTarget(10, 20, 30, 40, 50, 60, 70, 80, 90, 100, 110, 120, 130),
				Is.EqualTo(intReturnValue), nameof(chunk.ValueTarget));
			Assert.That(argumentA, Is.EqualTo(10), nameof(argumentA));
			Assert.That(argumentB, Is.EqualTo(20), nameof(argumentB));
			Assert.That(argumentC, Is.EqualTo(30), nameof(argumentC));
			Assert.That(argumentD, Is.EqualTo(40), nameof(argumentD));
			Assert.That(argumentE, Is.EqualTo(50), nameof(argumentE));
			Assert.That(argumentF, Is.EqualTo(60), nameof(argumentF));
			Assert.That(argumentG, Is.EqualTo(70), nameof(argumentG));
			Assert.That(argumentH, Is.EqualTo(80), nameof(argumentH));
			Assert.That(argumentI, Is.EqualTo(90), nameof(argumentI));
			Assert.That(argumentJ, Is.EqualTo(100), nameof(argumentJ));
			Assert.That(argumentK, Is.EqualTo(110), nameof(argumentK));
			Assert.That(argumentL, Is.EqualTo(120), nameof(argumentL));
			Assert.That(argumentM, Is.EqualTo(130), nameof(argumentM));
			argumentA = 0;
			argumentB = 0;
			argumentC = 0;
			argumentD = 0;
			argumentE = 0;
			argumentF = 0;
			argumentG = 0;
			argumentH = 0;
			argumentI = 0;
			argumentJ = 0;
			argumentK = 0;
			argumentL = 0;
			argumentM = 0;
			Assert.That(chunk.ValueTarget(10, 20, 30, 40, 50, 60, 70, 80, 90, 100, 110, 120, 130),
				Is.EqualTo(intReturnValue), nameof(chunk.ValueTarget));
			Assert.That(argumentA, Is.EqualTo(10), nameof(argumentA));
			Assert.That(argumentB, Is.EqualTo(20), nameof(argumentB));
			Assert.That(argumentC, Is.EqualTo(30), nameof(argumentC));
			Assert.That(argumentD, Is.EqualTo(40), nameof(argumentD));
			Assert.That(argumentE, Is.EqualTo(50), nameof(argumentE));
			Assert.That(argumentF, Is.EqualTo(60), nameof(argumentF));
			Assert.That(argumentG, Is.EqualTo(70), nameof(argumentG));
			Assert.That(argumentH, Is.EqualTo(80), nameof(argumentH));
			Assert.That(argumentI, Is.EqualTo(90), nameof(argumentI));
			Assert.That(argumentJ, Is.EqualTo(100), nameof(argumentJ));
			Assert.That(argumentK, Is.EqualTo(110), nameof(argumentK));
			Assert.That(argumentL, Is.EqualTo(120), nameof(argumentL));
			Assert.That(argumentM, Is.EqualTo(130), nameof(argumentM));

			rock.Verify();
		}
	}

	public interface IHandleFunc13ArgumentTests
	{
		event EventHandler TargetEvent;
		string ReferenceTarget(int a, int b, int c, int d, int e, int f, int g, int h, int i, int j, int k, int l, int m);
		int ValueTarget(int a, int b, int c, int d, int e, int f, int g, int h, int i, int j, int k, int l, int m);
	}
}