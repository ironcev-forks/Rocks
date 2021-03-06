﻿using NUnit.Framework;
using System.Threading.Tasks;

namespace Rocks.Tests
{
	public static class AsyncTests
	{
		[Test]
		public static async Task RunAsyncSynchronously()
		{
			var rock = Rock.Create<IAmAsync>();
			rock.Handle(_ => _.GoAsync()).Returns(Task.FromResult<int>(44));

			var uses = new UsesAsync(rock.Make());
			Assert.That(await uses.RunGoAsync(), Is.EqualTo(44));

			rock.Verify();
		}

		[Test]
		public static async Task RunAsyncAsynchronously()
		{
			var rock = Rock.Create<IAmAsync>();
			rock.Handle(_ => _.GoAsync(),
				async () =>
				{
					await Task.Yield();
					return 44;
				});

			var uses = new UsesAsync(rock.Make());
			Assert.That(await uses.RunGoAsync(), Is.EqualTo(44));

			rock.Verify();
		}
	}

	public interface IAmAsync
	{
		Task<int> GoAsync();
	}

	public class UsesAsync
	{
		private readonly IAmAsync amAsync;

		public UsesAsync(IAmAsync amAsync) =>
			this.amAsync = amAsync;

		public async Task<int> RunGoAsync() =>
			await this.amAsync.GoAsync();
	}
}
