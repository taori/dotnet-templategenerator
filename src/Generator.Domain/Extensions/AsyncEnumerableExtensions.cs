using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace Generator.Domain.Extensions
{
	public static class AsyncEnumerableExtensions
	{
		public static async IAsyncEnumerable<TResult> SelectAsync<T, TResult>(this IEnumerable<T> enumerable,
			Func<T, Task<TResult>> selector)
		{
			using var enumerator = enumerable.GetEnumerator();
			while (enumerator.MoveNext())
			{
				yield return await selector(enumerator.Current).ConfigureAwait(false);
			}
		}
	}}