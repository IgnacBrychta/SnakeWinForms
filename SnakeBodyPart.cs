using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeWinForms;

public class SnakeBodyPart
{
	public int x; 
	public int y;
	public bool isHead = false;
	public SnakeBodyPart(int x, int y)
	{
		this.x = x;
		this.y = y;
	}

	public override string ToString()
	{
		return $"{x}; {y}";
	}
}
