namespace PolyDividor
{
    partial class Main
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
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
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.PB_Space = new System.Windows.Forms.PictureBox();
            this.B_GenNewTriangle = new System.Windows.Forms.Button();
            this.B_ShowWire = new System.Windows.Forms.Button();
            this.B_ShowPoly = new System.Windows.Forms.Button();
            this.B_Divide = new System.Windows.Forms.Button();
            this.B_AddGoodTriangle = new System.Windows.Forms.Button();
            this.Log = new System.Windows.Forms.TextBox();
            this.B_Clear = new System.Windows.Forms.Button();
            this.PolygonCount = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.Stop = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.PB_Space)).BeginInit();
            this.SuspendLayout();
            // 
            // PB_Space
            // 
            this.PB_Space.Location = new System.Drawing.Point(12, 12);
            this.PB_Space.Name = "PB_Space";
            this.PB_Space.Size = new System.Drawing.Size(400, 400);
            this.PB_Space.TabIndex = 0;
            this.PB_Space.TabStop = false;
            // 
            // B_GenNewTriangle
            // 
            this.B_GenNewTriangle.Location = new System.Drawing.Point(418, 12);
            this.B_GenNewTriangle.Name = "B_GenNewTriangle";
            this.B_GenNewTriangle.Size = new System.Drawing.Size(202, 23);
            this.B_GenNewTriangle.TabIndex = 1;
            this.B_GenNewTriangle.Text = "Сгенерировать новый треугольник";
            this.B_GenNewTriangle.UseVisualStyleBackColor = true;
            this.B_GenNewTriangle.Click += new System.EventHandler(this.B_GenNewTriangle_Click);
            // 
            // B_ShowWire
            // 
            this.B_ShowWire.Location = new System.Drawing.Point(418, 109);
            this.B_ShowWire.Name = "B_ShowWire";
            this.B_ShowWire.Size = new System.Drawing.Size(202, 23);
            this.B_ShowWire.TabIndex = 2;
            this.B_ShowWire.Text = "Показать обводку";
            this.B_ShowWire.UseVisualStyleBackColor = true;
            this.B_ShowWire.Click += new System.EventHandler(this.B_ShowWire_Click);
            // 
            // B_ShowPoly
            // 
            this.B_ShowPoly.Location = new System.Drawing.Point(418, 138);
            this.B_ShowPoly.Name = "B_ShowPoly";
            this.B_ShowPoly.Size = new System.Drawing.Size(202, 23);
            this.B_ShowPoly.TabIndex = 3;
            this.B_ShowPoly.Text = "Показать с заливкой";
            this.B_ShowPoly.UseVisualStyleBackColor = true;
            this.B_ShowPoly.Click += new System.EventHandler(this.B_ShowPoly_Click);
            // 
            // B_Divide
            // 
            this.B_Divide.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.B_Divide.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.B_Divide.Location = new System.Drawing.Point(418, 227);
            this.B_Divide.Name = "B_Divide";
            this.B_Divide.Size = new System.Drawing.Size(202, 23);
            this.B_Divide.TabIndex = 4;
            this.B_Divide.Text = "Разбить";
            this.B_Divide.UseVisualStyleBackColor = false;
            this.B_Divide.Click += new System.EventHandler(this.B_Divide_Click);
            // 
            // B_AddGoodTriangle
            // 
            this.B_AddGoodTriangle.Location = new System.Drawing.Point(418, 41);
            this.B_AddGoodTriangle.Name = "B_AddGoodTriangle";
            this.B_AddGoodTriangle.Size = new System.Drawing.Size(202, 23);
            this.B_AddGoodTriangle.TabIndex = 5;
            this.B_AddGoodTriangle.Text = "Добавить хороший треугольник";
            this.B_AddGoodTriangle.UseVisualStyleBackColor = true;
            this.B_AddGoodTriangle.Click += new System.EventHandler(this.B_AddGoodTriangle_Click);
            // 
            // Log
            // 
            this.Log.Location = new System.Drawing.Point(418, 256);
            this.Log.Multiline = true;
            this.Log.Name = "Log";
            this.Log.Size = new System.Drawing.Size(202, 156);
            this.Log.TabIndex = 6;
            this.Log.Text = "вавыаы\r\n\\n dsd";
            // 
            // B_Clear
            // 
            this.B_Clear.Location = new System.Drawing.Point(418, 70);
            this.B_Clear.Name = "B_Clear";
            this.B_Clear.Size = new System.Drawing.Size(203, 23);
            this.B_Clear.TabIndex = 7;
            this.B_Clear.Text = "Зачистить";
            this.B_Clear.UseVisualStyleBackColor = true;
            this.B_Clear.Click += new System.EventHandler(this.B_Clear_Click);
            // 
            // PolygonCount
            // 
            this.PolygonCount.AutoSize = true;
            this.PolygonCount.Location = new System.Drawing.Point(415, 164);
            this.PolygonCount.Name = "PolygonCount";
            this.PolygonCount.Size = new System.Drawing.Size(35, 13);
            this.PolygonCount.TabIndex = 8;
            this.PolygonCount.Text = "label1";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Stop
            // 
            this.Stop.Location = new System.Drawing.Point(418, 198);
            this.Stop.Name = "Stop";
            this.Stop.Size = new System.Drawing.Size(75, 23);
            this.Stop.TabIndex = 9;
            this.Stop.Text = "Стоп";
            this.Stop.UseVisualStyleBackColor = true;
            this.Stop.Click += new System.EventHandler(this.Stop_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(546, 198);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = "Стянуть";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(633, 424);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Stop);
            this.Controls.Add(this.PolygonCount);
            this.Controls.Add(this.B_Clear);
            this.Controls.Add(this.Log);
            this.Controls.Add(this.B_AddGoodTriangle);
            this.Controls.Add(this.B_Divide);
            this.Controls.Add(this.B_ShowPoly);
            this.Controls.Add(this.B_ShowWire);
            this.Controls.Add(this.B_GenNewTriangle);
            this.Controls.Add(this.PB_Space);
            this.Name = "Main";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.PB_Space)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox PB_Space;
        private System.Windows.Forms.Button B_GenNewTriangle;
        private System.Windows.Forms.Button B_ShowWire;
        private System.Windows.Forms.Button B_ShowPoly;
        private System.Windows.Forms.Button B_Divide;
        private System.Windows.Forms.Button B_AddGoodTriangle;
        private System.Windows.Forms.TextBox Log;
        private System.Windows.Forms.Button B_Clear;
        private System.Windows.Forms.Label PolygonCount;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button Stop;
        private System.Windows.Forms.Button button1;
    }
}

