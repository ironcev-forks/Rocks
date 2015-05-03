﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Rocks.Extensions
{
	internal static class MethodBaseExtensions
	{
		internal static GenericArgumentsResult GetGenericArguments(this MethodBase @this, SortedSet<string> namespaces)
		{
			var arguments = string.Empty;
			var constraints = string.Empty;

			if (@this.IsGenericMethodDefinition)
			{
				var genericArguments = new List<string>();
				var genericConstraints = new List<string>();

				foreach (var argument in @this.GetGenericArguments())
				{
					genericArguments.Add(argument.GetSafeName());
					var constraint = argument.GetConstraints(namespaces);

					if (!string.IsNullOrWhiteSpace(constraint))
					{
						genericConstraints.Add(constraint);
					}
				}

				arguments = $"<{string.Join(", ", genericArguments)}>";
				// TODO: This should not add a space in front. The Maker class
				// should adjust the constraints to have a space in front.
				constraints = genericConstraints.Count == 0 ?
					string.Empty : $"{string.Join(" ", genericConstraints)}";
			}

			return new GenericArgumentsResult(arguments, constraints);
		}

		internal static string GetArgumentNameList(this MethodBase @this)
		{
			return string.Join(", ",
				(from parameter in @this.GetParameters()
				 let modifier = parameter.GetModifier(true)
				 select $"{modifier}{parameter.Name}"));
		}

		internal static string GetExpectationExceptionMessage(this MethodBase @this)
		{
			var hasPointerTypes = @this.GetParameters()
				.Where(_ => new TypeDissector(_.ParameterType).IsPointer).Any();
			var argumentlist = hasPointerTypes ? @this.GetParameters(new SortedSet<string>()) : @this.GetLiteralArgumentNameList();
			return $"{@this.Name}{@this.GetGenericArguments(new SortedSet<string>()).Arguments}({argumentlist})";
		}

		internal static string GetLiteralArgumentNameList(this MethodBase @this)
		{
			return string.Join(", ",
				(from parameter in @this.GetParameters()
				 select $"{{{parameter.Name}}}"));
		}

		internal static string GetParameters(this MethodBase @this, SortedSet<string> namespaces)
		{
			return string.Join(", ",
				from parameter in @this.GetParameters()
				let parameterType = parameter.ParameterType
				let _ = parameterType.AddNamespaces(namespaces)
				let modifier = parameter.GetModifier()
				select $"{modifier}{parameterType.GetFullName(namespaces)} {parameter.Name}");
		}
	}
}
