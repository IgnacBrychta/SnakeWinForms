using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeWinForms;

public class Misc : IEqualityComparer<object>
{
	public new bool Equals(object? x, object? y)
	{
		throw new NotImplementedException();
	}

	public int GetHashCode([DisallowNull] object obj)
	{
		throw new NotImplementedException();
	}
}
