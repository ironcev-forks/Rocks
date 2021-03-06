﻿using NUnit.Framework;

namespace Rocks.Tests
{
	public sealed class NestedTypesTests
	{
		private void Nested(ref int a) => a = 2;

		[Test]
		public void Make()
		{
			var a = 1;
			var rock = Rock.Create<NestedClass.IAmNested>();
			rock.Handle(_ => _.Target(ref a), 
				new NestedClass.NestedDelegate(this.Nested));

			var chunk = rock.Make();
			chunk.Target(ref a);

			Assert.That(a, Is.EqualTo(2), nameof(a));
			rock.Verify();
		}

		public class NestedClass
		{
			public delegate void NestedDelegate(ref int a);
			public interface IAmNested
			{
				void Target(ref int a);
			}
		}
	}
}
