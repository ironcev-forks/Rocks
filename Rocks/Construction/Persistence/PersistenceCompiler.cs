﻿using Microsoft.CodeAnalysis;
using Rocks.Options;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Reflection;

namespace Rocks.Construction.Persistence
{
	internal sealed class PersistenceCompiler
		: Compiler<FileStream>
	{
		private readonly string assemblyPath;

		internal PersistenceCompiler(IEnumerable<SyntaxTree> trees, OptimizationSetting optimization, 
			string assemblyName, ReadOnlyCollection<Assembly> referencedAssemblies, string assemblyPath,
			bool allowUnsafe, AllowWarnings allowWarnings)
			: base(trees, optimization, assemblyName, referencedAssemblies, allowUnsafe, allowWarnings) => this.assemblyPath = assemblyPath;

		protected override FileStream GetAssemblyStream() =>
			new FileStream($"{Path.Combine(this.assemblyPath, this.AssemblyName)}.dll", FileMode.Create);

		protected override FileStream GetPdbStream() =>
			new FileStream($"{Path.Combine(this.assemblyPath, this.AssemblyName)}.pdb", FileMode.Create);

		protected override Assembly ProcessStreams(FileStream assemblyStream, FileStream pdbStream) =>
			Assembly.LoadFile(assemblyStream.Name);
	}
}