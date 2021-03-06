﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Threading;

namespace Rocks
{
   // TODO: Consider making this immutable - that is,
   // make AddRaiseEvent and IncrementCallCount return 
	// new instances.
   [Serializable]
	public class HandlerInformation
	{
		public const string ErrorAtLeastOnceCallCount = "The method should have been called at least once.";
		private const string ErrorExpectedCallCount = "The expected call count is incorrect. Expected: {0}, received: {1}.";

		private int callCount;
		[NonSerialized]
		private readonly List<RaiseEventInformation> raiseEvents = new List<RaiseEventInformation>();

		internal HandlerInformation()
			: this(null, null, new ReadOnlyDictionary<string, ArgumentExpectation>(new Dictionary<string, ArgumentExpectation>()))
		{ }

		internal HandlerInformation(uint expectedCallCount)
			: this(null, expectedCallCount, new ReadOnlyDictionary<string, ArgumentExpectation>(new Dictionary<string, ArgumentExpectation>()))
		{ }

		internal HandlerInformation(Delegate method)
			: this(method, null, new ReadOnlyDictionary<string, ArgumentExpectation>(new Dictionary<string, ArgumentExpectation>()))
		{ }

		internal HandlerInformation(Delegate method, uint expectedCallCount)
			: this(method, expectedCallCount, new ReadOnlyDictionary<string, ArgumentExpectation>(new Dictionary<string, ArgumentExpectation>()))
		{ }

		internal HandlerInformation(ReadOnlyDictionary<string, ArgumentExpectation> expectations)
			: this(null, null, expectations)
		{ }

		internal HandlerInformation(Delegate method, ReadOnlyDictionary<string, ArgumentExpectation> expectations)
			: this(method, null, expectations)
		{ }

		internal HandlerInformation(uint expectedCallCount, ReadOnlyDictionary<string, ArgumentExpectation> expectations)
			: this(null, expectedCallCount, expectations)
		{ }

		internal HandlerInformation(Delegate? method, uint? expectedCallCount, ReadOnlyDictionary<string, ArgumentExpectation> expectations) =>
			(this.Method, this.ExpectedCallCount, this.Expectations) = (method, expectedCallCount, expectations);

		internal void AddRaiseEvent(RaiseEventInformation raiseEvent) => this.raiseEvents.Add(raiseEvent);

		public void IncrementCallCount() => Interlocked.Increment(ref this.callCount);

		public void RaiseEvents(IMockWithEvents target)
		{
			if(target is null) { throw new ArgumentNullException(nameof(target)); }

			foreach (var raiseEvent in this.raiseEvents)
			{
				target.Raise(raiseEvent.Name, raiseEvent.Args);
			}
		}

		internal IReadOnlyList<string> Verify()
		{
			var verifications = new List<string>();

			if (this.ExpectedCallCount is null)
			{
				if (this.callCount < 1)
				{
					verifications.Add(HandlerInformation.ErrorAtLeastOnceCallCount);
				}
			}
			else
			{
				if (this.ExpectedCallCount != this.callCount)
				{
					verifications.Add(string.Format(
						CultureInfo.CurrentCulture, HandlerInformation.ErrorExpectedCallCount, 
						this.ExpectedCallCount.ToString(), this.callCount.ToString(CultureInfo.CurrentCulture)));
				}
			}

			return verifications.AsReadOnly();
		}

		internal int CallCount => this.callCount;

		public ReadOnlyDictionary<string, ArgumentExpectation> Expectations { get; }
		internal uint? ExpectedCallCount { get; }
		public Delegate? Method { get; }
		internal ReadOnlyCollection<RaiseEventInformation> GetRaiseEvents() => this.raiseEvents.AsReadOnly();
	}
}