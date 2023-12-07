namespace SnakeWinForms;

internal static class GameDrawer
{
	private static int _snakeCellWidth = 30;
	public static int SnakeCellWidth { get => _snakeCellWidth; set =>  _snakeCellWidth = value; }
	private static Color bodyPartColor = Color.Green;
	private static Color headPartColor = Color.Blue;
	private static Color blankScreenColor = Color.Black;
	private static Color fruitColor = Color.Red;
	private static Pen pen = new Pen(bodyPartColor, 1);
	private static Pen headPen = new Pen(headPartColor, 1);
	private static Pen fruitPen = new Pen(fruitColor, 1);
	public static void DrawSnake(Snake snake, Bitmap bitmap)
	{
		foreach (SnakeBodyPart part in snake.BodyParts.Reverse<SnakeBodyPart>())
		{
			DrawBodyPart(part, bitmap);
		}
	}

	public static void DrawFruits(List<Point> fruits, Bitmap bitmap)
	{
		foreach (Point fruit in fruits)
		{
			DrawFruit(fruit, bitmap);
		}
	}

	private static void DrawBodyPart(SnakeBodyPart bodyPart, Bitmap bitmap)
	{
		Graphics g = Graphics.FromImage(bitmap);
		g.DrawRectangle(bodyPart.isHead ? pen : headPen, bodyPart.x * _snakeCellWidth, bodyPart.y * _snakeCellWidth, _snakeCellWidth, _snakeCellWidth);
	}

	private static void DrawFruit(Point fruit, Bitmap bitmap)
	{
		Graphics g = Graphics.FromImage(bitmap);
		g.DrawRectangle(fruitPen, fruit.X * _snakeCellWidth, fruit.Y * _snakeCellWidth, _snakeCellWidth, _snakeCellWidth);
	}

	public static void ClearBitmap(Bitmap bitmap)
	{
		Graphics g = Graphics.FromImage(bitmap);
		g.Clear(blankScreenColor);
	}

	public static void DrawGameOverOverlay(Bitmap bitmap, string? text = null, int height = 150)
	{
		Graphics g = Graphics.FromImage(bitmap);
		Font font = new Font("Bernard MT Condensed", height);
		Brush brush = new SolidBrush(Color.White);

		// Specify the text and its position
		text ??= "Obecná prohra.";
		PointF position = new PointF(10, 40);

		// Draw the text on the Bitmap
		g.DrawString(text, font, brush, position);
	}
}
