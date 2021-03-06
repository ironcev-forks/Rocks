﻿using System;
using System.Reflection;

namespace Rocks.Construction.Persistence
{
	internal sealed class PersistenceNameGenerator
		: NameGenerator
	{
		internal PersistenceNameGenerator(Type type)
			: this(type.Assembly)
		{ }

		internal PersistenceNameGenerator(Assembly assembly)
			: base($"{assembly.GetName().Name}.Rocks")
		{ }
	}
}
