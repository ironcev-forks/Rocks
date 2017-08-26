﻿using Rocks.Extensions;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace Rocks.Construction.Persistence
{
	internal sealed class PersistenceTypeNameGenerator
		: TypeNameGenerator
	{
		internal PersistenceTypeNameGenerator(SortedSet<string> namespaces)
			: base() => this.Namespaces = namespaces;

		internal override string Generate(Type baseType)
		{
			var name = baseType.IsGenericTypeDefinition ?
				$"{baseType.GetFullName(this.Namespaces)}" : new TypeDissector(baseType).SafeName;
			return $"Rock{name.Replace(".", string.Empty)}";
		}

		private SortedSet<string> Namespaces { get; }
	}
}