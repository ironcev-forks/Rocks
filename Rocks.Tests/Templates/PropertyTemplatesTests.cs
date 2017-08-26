﻿using NUnit.Framework;
using Rocks.Templates;

namespace Rocks.Tests.Templates
{
	[TestFixture]
	public sealed class PropertyTemplatesTests
	{
		[Test]
		public void GetProperty() =>
			Assert.That(PropertyTemplates.GetProperty("a", "b", "c", "d", "e"),
				Is.EqualTo("d a eb { c }"));

		[Test]
		public void GetPropertyIndexer() =>
			Assert.That(PropertyTemplates.GetPropertyIndexer("a", "b", "c", "d", "e"),
				Is.EqualTo("d a ethis[b] { c }"));

		[Test]
		public void GetPropertyGetWithReferenceTypeReturnValueAndHasEventsIsTrue() =>
			Assert.That(PropertyTemplates.GetPropertyGetWithReferenceTypeReturnValue(1, "b", "c", "d", "e", "f", "g", true), Is.EqualTo(
@"g get
{
	if (this.handlers.TryGetValue(1, out var methodHandlers))
	{
		foreach(var methodHandler in methodHandlers)
		{
			if(d)
			{
				var result = methodHandler.Method != null ?
					(methodHandler.Method as e)(b) as c :
					(methodHandler as R.HandlerInformation<c>).ReturnValue;
				methodHandler.RaiseEvents(this);
				methodHandler.IncrementCallCount();
				return result;
			}
		}

		throw new RE.ExpectationException($""No handlers were found for f"");
	}
	else
	{
		throw new S.NotImplementedException();
	}
}"));

		[Test]
		public void GetPropertyGetWithReferenceTypeReturnValueAndHasEventsIsFalse() =>
			Assert.That(PropertyTemplates.GetPropertyGetWithReferenceTypeReturnValue(1, "b", "c", "d", "e", "f", "g", false), Is.EqualTo(
@"g get
{
	if (this.handlers.TryGetValue(1, out var methodHandlers))
	{
		foreach(var methodHandler in methodHandlers)
		{
			if(d)
			{
				var result = methodHandler.Method != null ?
					(methodHandler.Method as e)(b) as c :
					(methodHandler as R.HandlerInformation<c>).ReturnValue;
				
				methodHandler.IncrementCallCount();
				return result;
			}
		}

		throw new RE.ExpectationException($""No handlers were found for f"");
	}
	else
	{
		throw new S.NotImplementedException();
	}
}"));

		[Test]
		public void GetPropertyGetWithReferenceTypeReturnValueAndNoIndexersAndHasEventsIsTrue() =>
			Assert.That(PropertyTemplates.GetPropertyGetWithReferenceTypeReturnValueAndNoIndexers(1, "b", "c", "d", "e", true), Is.EqualTo(
@"e get
{
	if (this.handlers.TryGetValue(1, out var methodHandlers))
	{
		var methodHandler = methodHandlers[0];
		var result = methodHandler.Method != null ?
			(methodHandler.Method as d)(b) as c :
			(methodHandler as R.HandlerInformation<c>).ReturnValue;
		methodHandler.RaiseEvents(this);
		methodHandler.IncrementCallCount();
		return result;
	}
	else
	{
		throw new S.NotImplementedException();
	}
}"));

		[Test]
		public void GetPropertyGetWithReferenceTypeReturnValueAndNoIndexersAndHasEventsIsFalse() =>
			Assert.That(PropertyTemplates.GetPropertyGetWithReferenceTypeReturnValueAndNoIndexers(1, "b", "c", "d", "e", false), Is.EqualTo(
@"e get
{
	if (this.handlers.TryGetValue(1, out var methodHandlers))
	{
		var methodHandler = methodHandlers[0];
		var result = methodHandler.Method != null ?
			(methodHandler.Method as d)(b) as c :
			(methodHandler as R.HandlerInformation<c>).ReturnValue;
		
		methodHandler.IncrementCallCount();
		return result;
	}
	else
	{
		throw new S.NotImplementedException();
	}
}"));

		[Test]
		public void GetPropertyGetWithValueTypeReturnValueAndHasEventsIsTrue() =>
			Assert.That(PropertyTemplates.GetPropertyGetWithValueTypeReturnValue(1, "b", "c", "d", "e", "f", "g", true), Is.EqualTo(
@"g get
{
	if (this.handlers.TryGetValue(1, out var methodHandlers))
	{
		foreach(var methodHandler in methodHandlers)
		{
			if(d)
			{
				var result = methodHandler.Method != null ?
					(c)(methodHandler.Method as e)(b) :
					(methodHandler as R.HandlerInformation<c>).ReturnValue;
				methodHandler.RaiseEvents(this);
				methodHandler.IncrementCallCount();
				return result;
			}
		}

		throw new RE.ExpectationException($""No handlers were found for f"");
	}
	else
	{
		throw new S.NotImplementedException();
	}
}"));

		[Test]
		public void GetPropertyGetWithValueTypeReturnValueAndHasEventsIsFalse() =>
			Assert.That(PropertyTemplates.GetPropertyGetWithValueTypeReturnValue(1, "b", "c", "d", "e", "f", "g", false), Is.EqualTo(
@"g get
{
	if (this.handlers.TryGetValue(1, out var methodHandlers))
	{
		foreach(var methodHandler in methodHandlers)
		{
			if(d)
			{
				var result = methodHandler.Method != null ?
					(c)(methodHandler.Method as e)(b) :
					(methodHandler as R.HandlerInformation<c>).ReturnValue;
				
				methodHandler.IncrementCallCount();
				return result;
			}
		}

		throw new RE.ExpectationException($""No handlers were found for f"");
	}
	else
	{
		throw new S.NotImplementedException();
	}
}"));

		[Test]
		public void GetPropertyGetWithValueTypeReturnValueAndNoIndexersAndHasEventsIsTrue() =>
			Assert.That(PropertyTemplates.GetPropertyGetWithValueTypeReturnValueAndNoIndexers(1, "b", "c", "d", "e", true), Is.EqualTo(
@"e get
{
	if (this.handlers.TryGetValue(1, out var methodHandlers))
	{
		var methodHandler = methodHandlers[0];
		var result = methodHandler.Method != null ?
			(c)(methodHandler.Method as d)(b) :
			(methodHandler as R.HandlerInformation<c>).ReturnValue;
		methodHandler.RaiseEvents(this);
		methodHandler.IncrementCallCount();
		return result;
	}
	else
	{
		throw new S.NotImplementedException();
	}
}"));

		[Test]
		public void GetPropertyGetWithValueTypeReturnValueAndNoIndexersAndHasEventsIsFalse() =>
			Assert.That(PropertyTemplates.GetPropertyGetWithValueTypeReturnValueAndNoIndexers(1, "b", "c", "d", "e", false), Is.EqualTo(
@"e get
{
	if (this.handlers.TryGetValue(1, out var methodHandlers))
	{
		var methodHandler = methodHandlers[0];
		var result = methodHandler.Method != null ?
			(c)(methodHandler.Method as d)(b) :
			(methodHandler as R.HandlerInformation<c>).ReturnValue;
		
		methodHandler.IncrementCallCount();
		return result;
	}
	else
	{
		throw new S.NotImplementedException();
	}
}"));

		[Test]
		public void GetPropertyGetForMake() =>
			Assert.That(PropertyTemplates.GetPropertyGetForMake("a", "b"), Is.EqualTo(
@"a get
{
	return default(b);
}"));

		[Test]
		public void GetPropertySetAndHasEventsIsTrue() =>
			Assert.That(PropertyTemplates.GetPropertySet(1, "b", "c", "d", "e", "f", true), Is.EqualTo(
@"f set
{
	if (this.handlers.TryGetValue(1, out var methodHandlers))
	{
		var foundMatch = false;

		foreach(var methodHandler in methodHandlers)
		{
			if(c)
			{
				foundMatch = true;

				if(methodHandler.Method != null)
				{
					(methodHandler.Method as d)(b);
				}
	
				methodHandler.RaiseEvents(this);
				methodHandler.IncrementCallCount();
				break;
			}
		}

		if(!foundMatch)
		{
			throw new RE.ExpectationException($""No handlers were found for e"");
		}
	}
	else
	{
		throw new S.NotImplementedException();
	}
}"));

		[Test]
		public void GetPropertySetAndHasEventsIsFalse() =>
			Assert.That(PropertyTemplates.GetPropertySet(1, "b", "c", "d", "e", "f", false), Is.EqualTo(
@"f set
{
	if (this.handlers.TryGetValue(1, out var methodHandlers))
	{
		var foundMatch = false;

		foreach(var methodHandler in methodHandlers)
		{
			if(c)
			{
				foundMatch = true;

				if(methodHandler.Method != null)
				{
					(methodHandler.Method as d)(b);
				}
	
				
				methodHandler.IncrementCallCount();
				break;
			}
		}

		if(!foundMatch)
		{
			throw new RE.ExpectationException($""No handlers were found for e"");
		}
	}
	else
	{
		throw new S.NotImplementedException();
	}
}"));

		[Test]
		public void GetPropertySetAndNoIndexersAndHasEventsIsTrue() =>
			Assert.That(PropertyTemplates.GetPropertySetAndNoIndexers(1, "b", "c", "d", true), Is.EqualTo(
@"d set
{
	if (this.handlers.TryGetValue(1, out var methodHandlers))
	{
		var methodHandler = methodHandlers[0];

		if(methodHandler.Method != null)
		{
			(methodHandler.Method as c)(b);
		}
	
		methodHandler.RaiseEvents(this);
		methodHandler.IncrementCallCount();
	}
	else
	{
		throw new S.NotImplementedException();
	}
}"));

		[Test]
		public void GetPropertySetAndNoIndexersAndHasEventsIsFalse() =>
			Assert.That(PropertyTemplates.GetPropertySetAndNoIndexers(1, "b", "c", "d", false), Is.EqualTo(
@"d set
{
	if (this.handlers.TryGetValue(1, out var methodHandlers))
	{
		var methodHandler = methodHandlers[0];

		if(methodHandler.Method != null)
		{
			(methodHandler.Method as c)(b);
		}
	
		
		methodHandler.IncrementCallCount();
	}
	else
	{
		throw new S.NotImplementedException();
	}
}"));

		[Test]
		public void GetPropertySetForMake() =>
			Assert.That(PropertyTemplates.GetPropertySetForMake("a"),
				Is.EqualTo("a set { }"));
	}
}