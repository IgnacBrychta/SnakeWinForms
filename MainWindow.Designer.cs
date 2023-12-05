namespace SnakeWinForms
{
	partial class MainWindow
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			groupBox1 = new GroupBox();
			buttonReset = new Button();
			groupBox4 = new GroupBox();
			textBoxSpeed = new TextBox();
			groupBox3 = new GroupBox();
			textBoxScore = new TextBox();
			groupBox2 = new GroupBox();
			radioButtonSoundsNo = new RadioButton();
			radioButtonSoundsYes = new RadioButton();
			buttonStop = new Button();
			buttonStart = new Button();
			snakeGameScreen = new PictureBox();
			groupBoxGame = new GroupBox();
			groupBox1.SuspendLayout();
			groupBox4.SuspendLayout();
			groupBox3.SuspendLayout();
			groupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)snakeGameScreen).BeginInit();
			groupBoxGame.SuspendLayout();
			SuspendLayout();
			// 
			// groupBox1
			// 
			groupBox1.Controls.Add(buttonReset);
			groupBox1.Controls.Add(groupBox4);
			groupBox1.Controls.Add(groupBox3);
			groupBox1.Controls.Add(groupBox2);
			groupBox1.Controls.Add(buttonStop);
			groupBox1.Controls.Add(buttonStart);
			groupBox1.Location = new Point(12, 12);
			groupBox1.Name = "groupBox1";
			groupBox1.Size = new Size(2540, 200);
			groupBox1.TabIndex = 0;
			groupBox1.TabStop = false;
			groupBox1.Text = "Ovládání";
			// 
			// buttonReset
			// 
			buttonReset.Enabled = false;
			buttonReset.Location = new Point(497, 52);
			buttonReset.Name = "buttonReset";
			buttonReset.Size = new Size(231, 112);
			buttonReset.TabIndex = 5;
			buttonReset.Text = "RESET";
			buttonReset.UseVisualStyleBackColor = true;
			// 
			// groupBox4
			// 
			groupBox4.Controls.Add(textBoxSpeed);
			groupBox4.Location = new Point(1303, 52);
			groupBox4.Name = "groupBox4";
			groupBox4.Size = new Size(227, 116);
			groupBox4.TabIndex = 4;
			groupBox4.TabStop = false;
			groupBox4.Text = "Rychlost";
			// 
			// textBoxSpeed
			// 
			textBoxSpeed.Font = new Font("Bernard MT Condensed", 13F, FontStyle.Bold, GraphicsUnit.Point);
			textBoxSpeed.Location = new Point(20, 37);
			textBoxSpeed.Name = "textBoxSpeed";
			textBoxSpeed.ReadOnly = true;
			textBoxSpeed.Size = new Size(148, 49);
			textBoxSpeed.TabIndex = 0;
			textBoxSpeed.TextAlign = HorizontalAlignment.Center;
			// 
			// groupBox3
			// 
			groupBox3.Controls.Add(textBoxScore);
			groupBox3.Location = new Point(1070, 52);
			groupBox3.Name = "groupBox3";
			groupBox3.Size = new Size(227, 116);
			groupBox3.TabIndex = 3;
			groupBox3.TabStop = false;
			groupBox3.Text = "Skóre";
			// 
			// textBoxScore
			// 
			textBoxScore.Font = new Font("Bernard MT Condensed", 13F, FontStyle.Bold, GraphicsUnit.Point);
			textBoxScore.Location = new Point(20, 37);
			textBoxScore.Name = "textBoxScore";
			textBoxScore.ReadOnly = true;
			textBoxScore.Size = new Size(148, 49);
			textBoxScore.TabIndex = 0;
			textBoxScore.TextAlign = HorizontalAlignment.Center;
			// 
			// groupBox2
			// 
			groupBox2.Controls.Add(radioButtonSoundsNo);
			groupBox2.Controls.Add(radioButtonSoundsYes);
			groupBox2.Location = new Point(734, 52);
			groupBox2.Name = "groupBox2";
			groupBox2.Size = new Size(330, 112);
			groupBox2.TabIndex = 2;
			groupBox2.TabStop = false;
			groupBox2.Text = "Zvukové efekty";
			// 
			// radioButtonSoundsNo
			// 
			radioButtonSoundsNo.AutoSize = true;
			radioButtonSoundsNo.Location = new Point(183, 50);
			radioButtonSoundsNo.Name = "radioButtonSoundsNo";
			radioButtonSoundsNo.Size = new Size(76, 36);
			radioButtonSoundsNo.TabIndex = 1;
			radioButtonSoundsNo.TabStop = true;
			radioButtonSoundsNo.Text = "Ne";
			radioButtonSoundsNo.UseVisualStyleBackColor = true;
			// 
			// radioButtonSoundsYes
			// 
			radioButtonSoundsYes.AutoSize = true;
			radioButtonSoundsYes.Location = new Point(63, 46);
			radioButtonSoundsYes.Name = "radioButtonSoundsYes";
			radioButtonSoundsYes.Size = new Size(88, 36);
			radioButtonSoundsYes.TabIndex = 0;
			radioButtonSoundsYes.TabStop = true;
			radioButtonSoundsYes.Text = "Ano";
			radioButtonSoundsYes.UseVisualStyleBackColor = true;
			// 
			// buttonStop
			// 
			buttonStop.Location = new Point(260, 52);
			buttonStop.Name = "buttonStop";
			buttonStop.Size = new Size(231, 112);
			buttonStop.TabIndex = 1;
			buttonStop.Text = "STOP";
			buttonStop.UseVisualStyleBackColor = true;
			// 
			// buttonStart
			// 
			buttonStart.Location = new Point(23, 52);
			buttonStart.Name = "buttonStart";
			buttonStart.Size = new Size(231, 112);
			buttonStart.TabIndex = 0;
			buttonStart.Text = "START";
			buttonStart.UseVisualStyleBackColor = true;
			// 
			// snakeGameScreen
			// 
			snakeGameScreen.Location = new Point(19, 38);
			snakeGameScreen.Name = "snakeGameScreen";
			snakeGameScreen.Size = new Size(2500, 1140);
			snakeGameScreen.TabIndex = 1;
			snakeGameScreen.TabStop = false;
			// 
			// groupBoxGame
			// 
			groupBoxGame.Controls.Add(snakeGameScreen);
			groupBoxGame.Location = new Point(12, 218);
			groupBoxGame.Name = "groupBoxGame";
			groupBoxGame.Size = new Size(2540, 1200);
			groupBoxGame.TabIndex = 2;
			groupBoxGame.TabStop = false;
			groupBoxGame.Text = "Hra";
			// 
			// MainWindow
			// 
			AutoScaleDimensions = new SizeF(13F, 32F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(1597, 737);
			Controls.Add(groupBoxGame);
			Controls.Add(groupBox1);
			Name = "MainWindow";
			Text = "Form1";
			groupBox1.ResumeLayout(false);
			groupBox4.ResumeLayout(false);
			groupBox4.PerformLayout();
			groupBox3.ResumeLayout(false);
			groupBox3.PerformLayout();
			groupBox2.ResumeLayout(false);
			groupBox2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)snakeGameScreen).EndInit();
			groupBoxGame.ResumeLayout(false);
			ResumeLayout(false);
		}

		#endregion

		private GroupBox groupBox1;
		private Button buttonStop;
		private Button buttonStart;
		private GroupBox groupBox2;
		private RadioButton radioButtonSoundsNo;
		private RadioButton radioButtonSoundsYes;
		private PictureBox snakeGameScreen;
		private GroupBox groupBoxGame;
		private GroupBox groupBox3;
		private TextBox textBoxScore;
		private Button buttonReset;
		private GroupBox groupBox4;
		private TextBox textBoxSpeed;
	}
}