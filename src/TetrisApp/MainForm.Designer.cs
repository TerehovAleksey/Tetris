namespace TetrisApp;

partial class MainForm
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

    #region Код, автоматически созданный конструктором форм Windows

    /// <summary>
    /// Требуемый метод для поддержки конструктора — не изменяйте 
    /// содержимое этого метода с помощью редактора кода.
    /// </summary>
    private void InitializeComponent()
    {
            this.InfoPanel = new System.Windows.Forms.Panel();
            this.LableScore = new System.Windows.Forms.Label();
            this.ButtonStart = new System.Windows.Forms.Button();
            this.SettingsGroup = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.ButtonEditor = new System.Windows.Forms.Button();
            this.WithAcceleration = new System.Windows.Forms.CheckBox();
            this.IsGhostEnable = new System.Windows.Forms.CheckBox();
            this.ColumnsSelector = new System.Windows.Forms.NumericUpDown();
            this.RowsSelector = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.NextBlockGroup = new System.Windows.Forms.GroupBox();
            this.HeldBlockGroup = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.InfoPanel.SuspendLayout();
            this.SettingsGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ColumnsSelector)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RowsSelector)).BeginInit();
            this.SuspendLayout();
            // 
            // InfoPanel
            // 
            this.InfoPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.InfoPanel.Controls.Add(this.LableScore);
            this.InfoPanel.Controls.Add(this.ButtonStart);
            this.InfoPanel.Controls.Add(this.SettingsGroup);
            this.InfoPanel.Location = new System.Drawing.Point(771, 32);
            this.InfoPanel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.InfoPanel.Name = "InfoPanel";
            this.InfoPanel.Size = new System.Drawing.Size(658, 632);
            this.InfoPanel.TabIndex = 0;
            // 
            // LableScore
            // 
            this.LableScore.AutoSize = true;
            this.LableScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.LableScore.Location = new System.Drawing.Point(139, 540);
            this.LableScore.Name = "LableScore";
            this.LableScore.Size = new System.Drawing.Size(333, 55);
            this.LableScore.TabIndex = 2;
            this.LableScore.Text = "Результат:  0";
            this.LableScore.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // ButtonStart
            // 
            this.ButtonStart.Location = new System.Drawing.Point(179, 449);
            this.ButtonStart.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ButtonStart.Name = "ButtonStart";
            this.ButtonStart.Size = new System.Drawing.Size(286, 71);
            this.ButtonStart.TabIndex = 1;
            this.ButtonStart.Text = "Новая игра";
            this.ButtonStart.UseVisualStyleBackColor = true;
            this.ButtonStart.Click += new System.EventHandler(this.ButtonStart_Click);
            // 
            // SettingsGroup
            // 
            this.SettingsGroup.Controls.Add(this.label7);
            this.SettingsGroup.Controls.Add(this.label6);
            this.SettingsGroup.Controls.Add(this.label5);
            this.SettingsGroup.Controls.Add(this.label4);
            this.SettingsGroup.Controls.Add(this.button2);
            this.SettingsGroup.Controls.Add(this.ButtonEditor);
            this.SettingsGroup.Controls.Add(this.WithAcceleration);
            this.SettingsGroup.Controls.Add(this.IsGhostEnable);
            this.SettingsGroup.Controls.Add(this.ColumnsSelector);
            this.SettingsGroup.Controls.Add(this.RowsSelector);
            this.SettingsGroup.Controls.Add(this.label3);
            this.SettingsGroup.Controls.Add(this.label2);
            this.SettingsGroup.Controls.Add(this.label1);
            this.SettingsGroup.Location = new System.Drawing.Point(3, 4);
            this.SettingsGroup.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.SettingsGroup.Name = "SettingsGroup";
            this.SettingsGroup.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.SettingsGroup.Size = new System.Drawing.Size(651, 416);
            this.SettingsGroup.TabIndex = 0;
            this.SettingsGroup.TabStop = false;
            this.SettingsGroup.Text = "Параметры игры";
            // 
            // button2
            // 
            this.button2.Enabled = false;
            this.button2.Location = new System.Drawing.Point(61, 279);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(233, 46);
            this.button2.TabIndex = 8;
            this.button2.Text = "Результаты";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // ButtonEditor
            // 
            this.ButtonEditor.Location = new System.Drawing.Point(61, 344);
            this.ButtonEditor.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ButtonEditor.Name = "ButtonEditor";
            this.ButtonEditor.Size = new System.Drawing.Size(233, 46);
            this.ButtonEditor.TabIndex = 7;
            this.ButtonEditor.Text = "Редактор";
            this.ButtonEditor.UseVisualStyleBackColor = true;
            this.ButtonEditor.Click += new System.EventHandler(this.ButtonEditor_Click);
            // 
            // WithAcceleration
            // 
            this.WithAcceleration.AutoSize = true;
            this.WithAcceleration.Location = new System.Drawing.Point(61, 225);
            this.WithAcceleration.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.WithAcceleration.Name = "WithAcceleration";
            this.WithAcceleration.Size = new System.Drawing.Size(195, 29);
            this.WithAcceleration.TabIndex = 6;
            this.WithAcceleration.Text = "Игра с ускорением";
            this.WithAcceleration.UseVisualStyleBackColor = true;
            // 
            // IsGhostEnable
            // 
            this.IsGhostEnable.AutoSize = true;
            this.IsGhostEnable.Location = new System.Drawing.Point(61, 175);
            this.IsGhostEnable.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.IsGhostEnable.Name = "IsGhostEnable";
            this.IsGhostEnable.Size = new System.Drawing.Size(241, 29);
            this.IsGhostEnable.TabIndex = 5;
            this.IsGhostEnable.Text = "Использовать подсказки";
            this.IsGhostEnable.UseVisualStyleBackColor = true;
            // 
            // ColumnsSelector
            // 
            this.ColumnsSelector.Location = new System.Drawing.Point(161, 118);
            this.ColumnsSelector.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ColumnsSelector.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.ColumnsSelector.Minimum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.ColumnsSelector.Name = "ColumnsSelector";
            this.ColumnsSelector.Size = new System.Drawing.Size(133, 31);
            this.ColumnsSelector.TabIndex = 4;
            this.ColumnsSelector.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.ColumnsSelector.ValueChanged += new System.EventHandler(this.ColumnsSelector_ValueChanged);
            // 
            // RowsSelector
            // 
            this.RowsSelector.Location = new System.Drawing.Point(161, 78);
            this.RowsSelector.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.RowsSelector.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.RowsSelector.Minimum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.RowsSelector.Name = "RowsSelector";
            this.RowsSelector.Size = new System.Drawing.Size(133, 31);
            this.RowsSelector.TabIndex = 3;
            this.RowsSelector.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.RowsSelector.ValueChanged += new System.EventHandler(this.RowsSelector_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(57, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 25);
            this.label3.TabIndex = 2;
            this.label3.Text = "Ширина:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(57, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Высота:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(199, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Размер игрового поля";
            // 
            // NextBlockGroup
            // 
            this.NextBlockGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.NextBlockGroup.Location = new System.Drawing.Point(776, 672);
            this.NextBlockGroup.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.NextBlockGroup.Name = "NextBlockGroup";
            this.NextBlockGroup.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.NextBlockGroup.Size = new System.Drawing.Size(313, 289);
            this.NextBlockGroup.TabIndex = 1;
            this.NextBlockGroup.TabStop = false;
            this.NextBlockGroup.Text = "Следующий блок";
            this.NextBlockGroup.Paint += new System.Windows.Forms.PaintEventHandler(this.NextBlockGroup_Paint);
            // 
            // HeldBlockGroup
            // 
            this.HeldBlockGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.HeldBlockGroup.Location = new System.Drawing.Point(1096, 672);
            this.HeldBlockGroup.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.HeldBlockGroup.Name = "HeldBlockGroup";
            this.HeldBlockGroup.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.HeldBlockGroup.Size = new System.Drawing.Size(330, 289);
            this.HeldBlockGroup.TabIndex = 2;
            this.HeldBlockGroup.TabStop = false;
            this.HeldBlockGroup.Text = "Спрятанный блок";
            this.HeldBlockGroup.Paint += new System.Windows.Forms.PaintEventHandler(this.HeldBlockGroup_Paint);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(443, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(109, 25);
            this.label4.TabIndex = 9;
            this.label4.Text = "Управление";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(384, 78);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(235, 25);
            this.label5.TabIndex = 10;
            this.label5.Text = "Пробел - положить фигуру";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(384, 118);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(173, 25);
            this.label6.TabIndex = 11;
            this.label6.Text = "С - спрятать фигуру";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(384, 153);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(178, 25);
            this.label7.TabIndex = 12;
            this.label7.Text = "Вверх и Z - поворот";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1442, 1276);
            this.Controls.Add(this.HeldBlockGroup);
            this.Controls.Add(this.NextBlockGroup);
            this.Controls.Add(this.InfoPanel);
            this.DoubleBuffered = true;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MainForm";
            this.Text = "Тетрис";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.MainForm_Paint);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyUp);
            this.InfoPanel.ResumeLayout(false);
            this.InfoPanel.PerformLayout();
            this.SettingsGroup.ResumeLayout(false);
            this.SettingsGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ColumnsSelector)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RowsSelector)).EndInit();
            this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Panel InfoPanel;
    private System.Windows.Forms.GroupBox SettingsGroup;
    private System.Windows.Forms.NumericUpDown ColumnsSelector;
    private System.Windows.Forms.NumericUpDown RowsSelector;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Button ButtonStart;
    private System.Windows.Forms.CheckBox WithAcceleration;
    private System.Windows.Forms.CheckBox IsGhostEnable;
    private System.Windows.Forms.Button button2;
    private System.Windows.Forms.Button ButtonEditor;
    private System.Windows.Forms.Label LableScore;
    private System.Windows.Forms.GroupBox NextBlockGroup;
    private System.Windows.Forms.GroupBox HeldBlockGroup;
    private Label label6;
    private Label label5;
    private Label label4;
    private Label label7;
}