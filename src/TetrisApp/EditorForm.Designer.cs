namespace TetrisApp
{
    partial class EditorForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.BlockSelector = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.EditPanel = new System.Windows.Forms.PictureBox();
            this.ButtonSave = new System.Windows.Forms.Button();
            this.ButtonDelete = new System.Windows.Forms.Button();
            this.ButtonCwRotate = new System.Windows.Forms.Button();
            this.ButtonCcwRotate = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.TextBoxName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.ButtonColor = new System.Windows.Forms.Button();
            this.LabelPosition = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.EditPanel)).BeginInit();
            this.SuspendLayout();
            // 
            // BlockSelector
            // 
            this.BlockSelector.FormattingEnabled = true;
            this.BlockSelector.Location = new System.Drawing.Point(355, 15);
            this.BlockSelector.Name = "BlockSelector";
            this.BlockSelector.Size = new System.Drawing.Size(238, 33);
            this.BlockSelector.TabIndex = 0;
            this.BlockSelector.SelectedValueChanged += new System.EventHandler(this.BlockSelector_SelectedValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(311, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Выберете блок для редактирования:";
            // 
            // EditPanel
            // 
            this.EditPanel.Location = new System.Drawing.Point(67, 170);
            this.EditPanel.Name = "EditPanel";
            this.EditPanel.Size = new System.Drawing.Size(256, 241);
            this.EditPanel.TabIndex = 2;
            this.EditPanel.TabStop = false;
            this.EditPanel.Click += new System.EventHandler(this.EditPanel_Click);
            this.EditPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.EditPanel_Paint);
            // 
            // ButtonSave
            // 
            this.ButtonSave.Location = new System.Drawing.Point(32, 593);
            this.ButtonSave.Name = "ButtonSave";
            this.ButtonSave.Size = new System.Drawing.Size(280, 53);
            this.ButtonSave.TabIndex = 3;
            this.ButtonSave.Text = "Сохранить";
            this.ButtonSave.UseVisualStyleBackColor = true;
            this.ButtonSave.Click += new System.EventHandler(this.ButtonSave_Click);
            // 
            // ButtonDelete
            // 
            this.ButtonDelete.Location = new System.Drawing.Point(318, 593);
            this.ButtonDelete.Name = "ButtonDelete";
            this.ButtonDelete.Size = new System.Drawing.Size(280, 53);
            this.ButtonDelete.TabIndex = 4;
            this.ButtonDelete.Text = "Удалить";
            this.ButtonDelete.UseVisualStyleBackColor = true;
            this.ButtonDelete.Click += new System.EventHandler(this.ButtonDelete_Click);
            // 
            // ButtonCwRotate
            // 
            this.ButtonCwRotate.Image = global::TetrisApp.Properties.Resources.cw;
            this.ButtonCwRotate.Location = new System.Drawing.Point(417, 154);
            this.ButtonCwRotate.Name = "ButtonCwRotate";
            this.ButtonCwRotate.Size = new System.Drawing.Size(85, 85);
            this.ButtonCwRotate.TabIndex = 5;
            this.ButtonCwRotate.UseVisualStyleBackColor = true;
            this.ButtonCwRotate.Click += new System.EventHandler(this.ButtonCwRotate_Click);
            // 
            // ButtonCcwRotate
            // 
            this.ButtonCcwRotate.Image = global::TetrisApp.Properties.Resources.ccw;
            this.ButtonCcwRotate.Location = new System.Drawing.Point(417, 253);
            this.ButtonCcwRotate.Name = "ButtonCcwRotate";
            this.ButtonCcwRotate.Size = new System.Drawing.Size(85, 85);
            this.ButtonCcwRotate.TabIndex = 6;
            this.ButtonCcwRotate.UseVisualStyleBackColor = true;
            this.ButtonCcwRotate.Click += new System.EventHandler(this.ButtonCcwRotate_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 431);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(153, 25);
            this.label2.TabIndex = 7;
            this.label2.Text = "Не более 8 ячеек";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 468);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(461, 25);
            this.label3.TabIndex = 8;
            this.label3.Text = "У каждой ячейки должна быть соседняя по любой оси";
            // 
            // TextBoxName
            // 
            this.TextBoxName.Location = new System.Drawing.Point(355, 76);
            this.TextBoxName.Name = "TextBoxName";
            this.TextBoxName.Size = new System.Drawing.Size(238, 31);
            this.TextBoxName.TabIndex = 9;
            this.TextBoxName.TextChanged += new System.EventHandler(this.TextBoxName_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(238, 79);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 25);
            this.label4.TabIndex = 10;
            this.label4.Text = "Название:";
            // 
            // ButtonColor
            // 
            this.ButtonColor.Location = new System.Drawing.Point(382, 377);
            this.ButtonColor.Name = "ButtonColor";
            this.ButtonColor.Size = new System.Drawing.Size(176, 34);
            this.ButtonColor.TabIndex = 12;
            this.ButtonColor.Text = "Цвет";
            this.ButtonColor.UseVisualStyleBackColor = true;
            this.ButtonColor.Click += new System.EventHandler(this.ButtonColor_Click);
            // 
            // LabelPosition
            // 
            this.LabelPosition.AutoSize = true;
            this.LabelPosition.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.LabelPosition.Location = new System.Drawing.Point(107, 123);
            this.LabelPosition.Name = "LabelPosition";
            this.LabelPosition.Size = new System.Drawing.Size(140, 32);
            this.LabelPosition.TabIndex = 13;
            this.LabelPosition.Text = "Позиция 1";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(27, 507);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(558, 25);
            this.label5.TabIndex = 14;
            this.label5.Text = "Для создания новой фигуры ввести новое имя и отредактировать";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(27, 544);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(393, 25);
            this.label6.TabIndex = 15;
            this.label6.Text = "Редактирование доступно только в позиции 1";
            // 
            // EditorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(625, 671);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.LabelPosition);
            this.Controls.Add(this.ButtonColor);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.TextBoxName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ButtonCcwRotate);
            this.Controls.Add(this.ButtonCwRotate);
            this.Controls.Add(this.ButtonDelete);
            this.Controls.Add(this.ButtonSave);
            this.Controls.Add(this.EditPanel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BlockSelector);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "EditorForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Редактор";
            ((System.ComponentModel.ISupportInitialize)(this.EditPanel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComboBox BlockSelector;
        private Label label1;
        private PictureBox EditPanel;
        private Button ButtonSave;
        private Button ButtonDelete;
        private Button ButtonCwRotate;
        private Button ButtonCcwRotate;
        private Label label2;
        private Label label3;
        private TextBox TextBoxName;
        private Label label4;
        private ColorDialog colorDialog1;
        private Button ButtonColor;
        private Label LabelPosition;
        private Label label5;
        private Label label6;
    }
}