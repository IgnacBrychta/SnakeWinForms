using NAudio.Wave;
using System.Diagnostics;
using Timer = System.Windows.Forms.Timer;

namespace SnakeWinForms;

public partial class MainWindow : Form
{
	private bool _playSound = true;
	public bool PlaySound { get => _playSound; }
	Snake snake;
	Rectangle screenBorder;
	Rectangle scaledScreenBorder;
	public int desiredFPS = 60;
	Timer timer;
	private Keys pressedKey = Keys.W;
	private Keys lastPressedKey = Keys.Q;
	Keys[] allowedKeys = new[] { Keys.W, Keys.S, Keys.D, Keys.A };
	public int fruitSpawnChance = 1 /* %*/;
	List<Point> fruits = new List<Point>();
	Random random = new Random();
	Bitmap Bitmap { get => (Bitmap)snakeGameScreen.Image; }
	public int maxFruitsOnMap = 5;
	public int scale = 30;
	public int snakeCellWidth = 30;
	public long frameCounter = 0;
	public int fruitsToEatToWin = 50;
	public int increaseSpeedEveryXfruits = 10;
	public float snakeSpeedMultiplier = 1.15f;
	public const int startingSegments = 2;
	public const int startingOffset = 30;
	public const int maxSpeed = 3;

	public bool gameOver = false;
	public float snakeSpeed = 3;
	public int SnakeSpeed { get => Convert.ToInt32(snakeSpeed); }
	bool inputLocked = false;
	WaveOutEvent outputDeviceFruit;
	WaveOutEvent outputDeviceBackground;
	WaveOutEvent outputDeviceGameOver;
	AudioFileReader fruitCollected;
	AudioFileReader backgroundMusic;
	AudioFileReader gameOverSound;

	public MainWindow()
	{
		InitializeComponent();
		GiveAuthorCredit();
		WindowState = FormWindowState.Maximized;
		Text = "Ign�c�v had";
		SetColorTheme(this);
		SetControlTheme(this);
		timer = new Timer() { Enabled = false, Interval = 1000 /*ms*/ / desiredFPS };
		SetSubscriptionsOfControls();
		snake = new Snake(startingSegments, startingOffset, startingOffset, snakeCellWidth, fruits);
		GameDrawer.SnakeCellWidth = snakeCellWidth;
		Bitmap bitmap = new Bitmap(snakeGameScreen.Width, snakeGameScreen.Height);
		snakeGameScreen.Image = bitmap;
		screenBorder = new Rectangle(0, 0, snakeGameScreen.Width, snakeGameScreen.Height);
		scaledScreenBorder = new Rectangle(0, 0, screenBorder.Width / scale, screenBorder.Height / scale);
		KeyPreview = true;
		textBoxSpeed.Text = GetActualSpeed();// Math.Round(snakeSpeed, 1).ToString();
		Load += MainWindow_Load;
		Icon = new Icon("../../../resources/had png.ico");
#if !DoNotChangeCursor
		_ = ConfigureSettings();
#endif
		outputDeviceFruit = new WaveOutEvent();
		outputDeviceBackground = new WaveOutEvent();
		outputDeviceGameOver = new WaveOutEvent();
		fruitCollected = new AudioFileReader("../../../sounds/fruit collected.mp3");
		backgroundMusic = new AudioFileReader("../../../sounds/8bit.wav");
		gameOverSound = new AudioFileReader("../../../sounds/game over cut.mp3");
		outputDeviceFruit.Init(fruitCollected);
		outputDeviceFruit.Volume = 0.06f;
		outputDeviceBackground.Init(backgroundMusic);
		outputDeviceGameOver.Init(gameOverSound);
#warning p�idat n�jak� to nastaven� nav�c
#warning super mega ultra easter egg had
#warning nezapomenout zm�nit compiler options
		outputDeviceFruit.PlaybackStopped += (s, e) =>
		{
			fruitCollected.Position = 0;
		};

		outputDeviceBackground.PlaybackStopped += (s, e) =>
		{
			backgroundMusic.Position = 0;
		};

		outputDeviceGameOver.PlaybackStopped += (s, e) =>
		{
			gameOverSound.Position = 0;
		};
	}

	public static void GiveAuthorCredit()
	{
		Process.Start(new ProcessStartInfo() { UseShellExecute = true, FileName = "https://github.com/IgnacBrychta" });
	}

	private void MainWindow_Load(object? sender, EventArgs e)
	{
		MaximumSize = Size;
		MinimumSize = Size;
	}

	private void SetColorTheme(Control parent)
	{
		foreach (Control control in parent.Controls)
		{
			SetControlTheme(control);
			if (control.HasChildren) SetColorTheme(control);
		}
	}
	 
	private void SetControlTheme(Control control)
	{
		control.BackColor = Color.Black;
		control.ForeColor = Color.White;
	}

	private void SetSubscriptionsOfControls()
	{
		radioButtonSoundsNo.CheckedChanged += SoundSettingsChange;
		buttonStart.Click += ButtonStart_Click;
		buttonStop.Click += ButtonStop_Click;
		timer.Tick += NewFrameTick;
		KeyDown += MainWindow_KeyDown;
		buttonReset.Click += ButtonResetClick;
	}

	private void ButtonResetClick(object? sender, EventArgs e)
	{
		buttonReset.Enabled = false;
		fruits.Clear();
		gameOver = false;
		snakeSpeed = 3;
		snake = new Snake(startingSegments, startingOffset, startingOffset, snakeCellWidth, fruits);
		Bitmap b = Bitmap;
		GameDrawer.ClearBitmap(b);
		snakeGameScreen.Image = b;
		pressedKey = Keys.W;
		lastPressedKey = Keys.W;
		textBoxScore.Text = string.Empty;
	}

	private void MainWindow_KeyDown(object? sender, KeyEventArgs e)
	{
		Keys key = e.KeyCode;
		if (!allowedKeys.Contains(key) || key == pressedKey || inputLocked) return;

		inputLocked = true;

		lastPressedKey = pressedKey;
		pressedKey = key;
	}

	private string GetActualSpeed()
	{
		return Math.Round(maxSpeed - snakeSpeed + 0.1, 2).ToString();
	}

	private void NewFrameTick(object? sender, EventArgs e)
	{
		if (frameCounter % (SnakeSpeed <= 0 ? 1 : SnakeSpeed) == 0)
		{
			switch (pressedKey)
			{
				case Keys.S:
					if (lastPressedKey == Keys.W) goto case Keys.W;
					snake.MoveDown();
					break;
				case Keys.W:
					if (lastPressedKey == Keys.S) goto case Keys.S;
					snake.MoveUp();
					break;
				case Keys.D:
					if (lastPressedKey == Keys.A) goto case Keys.A;
					snake.MoveRight();
					break;
				case Keys.A:
					if (lastPressedKey == Keys.D) goto case Keys.D;
					snake.MoveLeft();
					break;
			}
			/*
			unlocking input MUST happen HERE when the snake moves, if it is unlocked somewhere else,
			the snake can collide with itself when it's moving in a particular direction and the player
			sets it to move in the opposite direction while pressing a key for a perpendicular direction
			in between
			trust me, i spent 4+ hours diagnosing this lol
			*/
			inputLocked = false;
		}

		if (TryFindSnakeCollision() || TryDetectWallCollision())
		{
			DrawNewFrame();
			ShowGameOverScreen();
			return;
		}
		TryFindFruitCollision();
		TryGenerateFruit();
		DrawNewFrame();

		if (fruitsToEatToWin <= snake.Score) ShowYouWonScreen();
		frameCounter++;

		textBoxSpeed.Text = GetActualSpeed();
	}

	private bool TryDetectWallCollision()
	{
		if (!snake.DidSnakeLeaveGameArea(scaledScreenBorder)) return false;

		return true;
	}

	private void PlayCollectSound()
	{
		outputDeviceFruit.Play();
	}

	private void TryFindFruitCollision()
	{
		if (!snake.DetectFruitCollision(out Point? fruit)) return;

		if (_playSound) PlayCollectSound();
		fruits.Remove((Point)fruit!);
		snake.IncreaseScore();
		snake.AddBodySegment();
		if (snake.Score % increaseSpeedEveryXfruits == 0 && snake.Score != 0)
		{
			snakeSpeed /= snakeSpeedMultiplier;
		}
	}

	private bool TryFindSnakeCollision()
	{
		if (!snake.DetectSelfCollision()) return false;

		return true;
	}

	private static async Task ConfigureSettings()
	{
		await Task.Run(() =>
		{
			try
			{
				// AniTuner is a great program for creating *.ani files
				WaitCursor waitCursor = new WaitCursor();
				waitCursor.TrySetCursorFilePath(Path.GetFullPath("../../../resources/cursor-had.ani"));
				_ = CursorChange.ChangeCursor(waitCursor);

				ArrowCursor arrowCursor = new ArrowCursor();
				arrowCursor.TrySetCursorFilePath(Path.GetFullPath("../../../resources/pointy-snake.cur"));
				_ = CursorChange.ChangeCursor(arrowCursor);

				IBeamCursor beamCursor = new IBeamCursor();
				beamCursor.TrySetCursorFilePath(Path.GetFullPath("../../../resources/snake.cur"));
				_ = CursorChange.ChangeCursor(beamCursor);

				HandCursor handCursor = new HandCursor();
				handCursor.TrySetCursorFilePath(Path.GetFullPath("../../../resources/cursor-had2.ani"));
				_ = CursorChange.ChangeCursor(handCursor);
			}
			catch (Exception) { }
		});

	}

	private void ShowYouWonScreen()
	{
		timer.Stop();
		Bitmap bitmap = (Bitmap)snakeGameScreen.Image;
		GameDrawer.DrawGameOverOverlay(bitmap, $"Hra u konce.\nSesb�rali jste\ndostatek ({fruitsToEatToWin}) ovoce!", 120);
		snakeGameScreen.Image = Bitmap;
		gameOver = true;
		buttonStop.Enabled = false;
		buttonReset.Enabled = true;
	}

	private void ShowGameOverScreen()
	{
		timer.Stop();
		outputDeviceBackground.Stop();
		outputDeviceGameOver.Play();
		
		Bitmap bitmap = (Bitmap)snakeGameScreen.Image;
		GameDrawer.DrawGameOverOverlay(bitmap, "Hra u konce.\nHad naboural!");
		snakeGameScreen.Image = Bitmap;
		
		gameOver = true;
		buttonStop.Enabled = false;
		buttonReset.Enabled = true;
	}

	private void TryGenerateFruit()
	{
		const int offset = 0;
		if (fruits.Count >= maxFruitsOnMap || random.Next(0, 100) > fruitSpawnChance) return;
		int fruitX = random.Next(offset, scaledScreenBorder.Width - offset),
			fruitY = random.Next(offset, scaledScreenBorder.Height - offset);
		while (snake.BodyParts.Any(bodyPart =>
			bodyPart.x == (fruitX = random.Next(offset, scaledScreenBorder.Width - offset)) &&
			bodyPart.y == (fruitY = random.Next(offset, scaledScreenBorder.Height - offset)) &&
			fruits.Any(fruit =>
			fruit.X == fruitX &&
			fruit.Y == fruitY)
		)) { }

		fruits.Add(new Point(fruitX, fruitY));
	}

	private void DrawNewFrame()
	{
		lock (snakeGameScreen.Image)
		{
			Bitmap bitmap = (Bitmap)snakeGameScreen.Image;
			GameDrawer.ClearBitmap(bitmap);
			GameDrawer.DrawFruits(fruits, bitmap);
			GameDrawer.DrawSnake(snake, bitmap);
			snakeGameScreen.Image = bitmap;
		}
		textBoxScore.Text = snake.Score.ToString();
	}

	private void ButtonStop_Click(object? sender, EventArgs e)
	{
		timer.Enabled = false;
		buttonReset.Enabled = true;
	}

	private void ButtonStart_Click(object? sender, EventArgs e)
	{
		if (gameOver) return;
		timer.Enabled = true;
		buttonStop.Enabled = true;
		buttonReset.Enabled = false;
		if (_playSound) PlayBackgroundMusic();
	}

	private void PlayBackgroundMusic()
	{
		outputDeviceBackground.Play();
	}

	private void SoundSettingsChange(object? sender, EventArgs e)
	{
		_playSound = !_playSound;
		if (outputDeviceBackground.PlaybackState == PlaybackState.Playing && !_playSound) 
			outputDeviceBackground.Stop();
		else if (outputDeviceBackground.PlaybackState == PlaybackState.Stopped && _playSound)
			outputDeviceBackground.Play();
	}

}
