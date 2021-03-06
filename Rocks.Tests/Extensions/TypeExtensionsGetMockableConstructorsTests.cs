﻿using NUnit.Framework;
using Rocks.Construction.InMemory;
using Rocks.Tests.Types;
using System;
using static Rocks.Extensions.TypeExtensions;

namespace Rocks.Tests.Extensions
{
	public static class TypeExtensionsGetMockableConstructorTests
	{
		[Test]
		public static void GetMockableConstructorsFromAbstractTypeWithProtectedConstructorThatUsesProtectedInternalType()
		{
			var constructors = typeof(HasConstructorWithArgumentThatUsesProtectedInternalType).GetMockableConstructors(
				new InMemoryNameGenerator());
			Assert.That(constructors.Count, Is.EqualTo(0));
		}

		[Test]
		public static void GetMockableConstructorsFromTypeWithObsoleteConstructors()
		{
			var constructors = typeof(HasObsoleteConstructors).GetMockableConstructors(
				new InMemoryNameGenerator());
			Assert.That(constructors.Count, Is.EqualTo(1));
		}
	}

	public class HasObsoleteConstructors
	{
		[Obsolete("", false)]
		public HasObsoleteConstructors() { }

		[Obsolete("", true)]
		public HasObsoleteConstructors(int a) { }
	}
}
