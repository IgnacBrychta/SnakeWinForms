namespace SnakeWinForms;

internal class Snake
{
	private int _score = 0; 
	public int _snakeCellWidth;

	public int Score { get => _score; }
	private List<SnakeBodyPart> _bodyParts = new List<SnakeBodyPart>();
	public List<SnakeBodyPart> BodyParts { get => _bodyParts; }
	private SnakeBodyPart Head { get => _bodyParts[0]; }
	public Point SnakeHeadPositionScaled { get => new Point(Head.x * _snakeCellWidth, Head.y * _snakeCellWidth); }
	private SnakeBodyPart Tail { get => _bodyParts[_bodyParts.Count - 1]; }
	private List<Point> fruitsList;
	/// <summary>
	/// Anchor point is the upper left corner
	/// </summary>
	public Snake(int startBodyParts, int startOffsetX, int startOffsetY, int snakeCellWidth, List<Point> fruitsList)
	{
		_snakeCellWidth = snakeCellWidth;
		this.fruitsList = fruitsList;
		for (int i = 0; i < startBodyParts; i++)
		{
			_bodyParts.Add(new SnakeBodyPart(i + startOffsetX, startOffsetY));
		}
	}

	public void IncreaseScore() => _score++;

	public void AddBodySegment()
	{
		_bodyParts.Add(new SnakeBodyPart(Tail.x, Tail.y));
	}

	private void Move(int xOffset, int yOffset)
	{
		Head.isHead = false;
		int xHead = Head.x;
		int yHead = Head.y;
		_bodyParts.Insert(0, Tail);
		_bodyParts.RemoveAt(_bodyParts.Count - 1);
		Head.x = xHead - xOffset;
		Head.y = yHead - yOffset;
		Head.isHead = true;
	}

	public bool DetectFruitCollision(out Point? collidedFruit)
	{
		collidedFruit = null;
		foreach (Point fruit in fruitsList)
		{
			if(fruit.X == Head.x && fruit.Y == Head.y)
			{
				collidedFruit = fruit;
				return true;
			}
		}
		return false;
	}

	public bool DidSnakeLeaveGameArea(Rectangle rect)
	{
		return !(Head.x < rect.Width &&
			Head.y < rect.Height &&
			Head.x > -1 &&
			Head.y > -1);
	}

	public bool DetectSelfCollision()
	{
		return _bodyParts.GetRange(1, _bodyParts.Count - 1)/*get all body parts except for head*/
			.Any(part => part.x == Head.x && part.y == Head.y);
	}

	public void MoveUp()
	{
		Move(0, 1);	
	}

	public void MoveDown()
	{
		Move(0, -1);
	}

	public void MoveLeft()
	{
		Move(1, 0);
	}

	public void MoveRight()
	{
		Move(-1, 0);
	}

	public override string ToString()
	{
		return Head.ToString();
	}
}
