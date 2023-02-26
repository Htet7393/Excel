namespace SpreadsheetGUI
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.spreadsheetPanel1 = new SS.SpreadsheetPanel();
            this.CellContent = new System.Windows.Forms.TextBox();
            this.UpButton = new System.Windows.Forms.Button();
            this.DownButton = new System.Windows.Forms.Button();
            this.RightButton = new System.Windows.Forms.Button();
            this.LeftButton = new System.Windows.Forms.Button();
            this.CellName = new System.Windows.Forms.TextBox();
            this.CellValue = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Enter = new System.Windows.Forms.Button();
            this.FileMenu = new System.Windows.Forms.Panel();
            this.Close = new System.Windows.Forms.Button();
            this.SaveAs = new System.Windows.Forms.Button();
            this.Save = new System.Windows.Forms.Button();
            this.Open = new System.Windows.Forms.Button();
            this.New = new System.Windows.Forms.Button();
            this.File = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.Help = new System.Windows.Forms.Button();
            this.DisplayPanel = new System.Windows.Forms.Panel();
            this.ControlPanel = new System.Windows.Forms.Panel();
            this.FileMenu.SuspendLayout();
            this.DisplayPanel.SuspendLayout();
            this.ControlPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // spreadsheetPanel1
            // 
            this.spreadsheetPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.spreadsheetPanel1.Location = new System.Drawing.Point(2, 215);
            this.spreadsheetPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.spreadsheetPanel1.Name = "spreadsheetPanel1";
            this.spreadsheetPanel1.Size = new System.Drawing.Size(933, 317);
            this.spreadsheetPanel1.TabIndex = 0;
            // 
            // CellContent
            // 
            this.CellContent.Location = new System.Drawing.Point(3, 39);
            this.CellContent.Name = "CellContent";
            this.CellContent.Size = new System.Drawing.Size(100, 20);
            this.CellContent.TabIndex = 2;
            // 
            // UpButton
            // 
            this.UpButton.BackColor = System.Drawing.Color.DodgerBlue;
            this.UpButton.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UpButton.Location = new System.Drawing.Point(86, 2);
            this.UpButton.Name = "UpButton";
            this.UpButton.Size = new System.Drawing.Size(75, 23);
            this.UpButton.TabIndex = 3;
            this.UpButton.Text = "Up";
            this.UpButton.UseVisualStyleBackColor = false;
            this.UpButton.Click += new System.EventHandler(this.UpButton_Click);
            // 
            // DownButton
            // 
            this.DownButton.BackColor = System.Drawing.Color.DodgerBlue;
            this.DownButton.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DownButton.Location = new System.Drawing.Point(86, 73);
            this.DownButton.Name = "DownButton";
            this.DownButton.Size = new System.Drawing.Size(75, 23);
            this.DownButton.TabIndex = 4;
            this.DownButton.Text = "Down";
            this.DownButton.UseVisualStyleBackColor = false;
            this.DownButton.Click += new System.EventHandler(this.DownButton_Click);
            // 
            // RightButton
            // 
            this.RightButton.BackColor = System.Drawing.Color.DodgerBlue;
            this.RightButton.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RightButton.Location = new System.Drawing.Point(170, 39);
            this.RightButton.Name = "RightButton";
            this.RightButton.Size = new System.Drawing.Size(75, 23);
            this.RightButton.TabIndex = 5;
            this.RightButton.Text = "Right";
            this.RightButton.UseVisualStyleBackColor = false;
            this.RightButton.Click += new System.EventHandler(this.RightButton_Click);
            // 
            // LeftButton
            // 
            this.LeftButton.BackColor = System.Drawing.Color.DodgerBlue;
            this.LeftButton.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LeftButton.Location = new System.Drawing.Point(3, 38);
            this.LeftButton.Name = "LeftButton";
            this.LeftButton.Size = new System.Drawing.Size(75, 23);
            this.LeftButton.TabIndex = 6;
            this.LeftButton.Text = "Left";
            this.LeftButton.UseVisualStyleBackColor = false;
            this.LeftButton.Click += new System.EventHandler(this.LeftButton_Click);
            // 
            // CellName
            // 
            this.CellName.Location = new System.Drawing.Point(3, 6);
            this.CellName.Name = "CellName";
            this.CellName.ReadOnly = true;
            this.CellName.Size = new System.Drawing.Size(100, 20);
            this.CellName.TabIndex = 7;
            // 
            // CellValue
            // 
            this.CellValue.Location = new System.Drawing.Point(3, 77);
            this.CellValue.Name = "CellValue";
            this.CellValue.ReadOnly = true;
            this.CellValue.Size = new System.Drawing.Size(100, 20);
            this.CellValue.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Microsoft Tai Le", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(125, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 16);
            this.label1.TabIndex = 9;
            this.label1.Text = "Cell Name";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Font = new System.Drawing.Font("Microsoft Tai Le", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(125, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 16);
            this.label2.TabIndex = 10;
            this.label2.Text = "Cell Value";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Font = new System.Drawing.Font("Microsoft Tai Le", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(125, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 16);
            this.label3.TabIndex = 11;
            this.label3.Text = "Cell Content";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Enter
            // 
            this.Enter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.Enter.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Enter.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Enter.Location = new System.Drawing.Point(84, 32);
            this.Enter.Name = "Enter";
            this.Enter.Size = new System.Drawing.Size(80, 35);
            this.Enter.TabIndex = 12;
            this.Enter.Text = "Enter";
            this.Enter.UseVisualStyleBackColor = false;
            this.Enter.Click += new System.EventHandler(this.Enter_Click);
            // 
            // FileMenu
            // 
            this.FileMenu.Controls.Add(this.Close);
            this.FileMenu.Controls.Add(this.SaveAs);
            this.FileMenu.Controls.Add(this.Save);
            this.FileMenu.Controls.Add(this.Open);
            this.FileMenu.Controls.Add(this.New);
            this.FileMenu.Controls.Add(this.File);
            this.FileMenu.Location = new System.Drawing.Point(2, 2);
            this.FileMenu.MaximumSize = new System.Drawing.Size(89, 158);
            this.FileMenu.MinimumSize = new System.Drawing.Size(89, 26);
            this.FileMenu.Name = "FileMenu";
            this.FileMenu.Size = new System.Drawing.Size(89, 26);
            this.FileMenu.TabIndex = 13;
            // 
            // Close
            // 
            this.Close.BackColor = System.Drawing.SystemColors.Highlight;
            this.Close.Dock = System.Windows.Forms.DockStyle.Top;
            this.Close.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Close.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Close.Location = new System.Drawing.Point(0, 130);
            this.Close.Name = "Close";
            this.Close.Size = new System.Drawing.Size(89, 26);
            this.Close.TabIndex = 5;
            this.Close.Text = "Close";
            this.Close.UseVisualStyleBackColor = false;
            this.Close.Click += new System.EventHandler(this.Close_Click);
            // 
            // SaveAs
            // 
            this.SaveAs.BackColor = System.Drawing.SystemColors.Highlight;
            this.SaveAs.Dock = System.Windows.Forms.DockStyle.Top;
            this.SaveAs.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.SaveAs.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaveAs.Location = new System.Drawing.Point(0, 104);
            this.SaveAs.Name = "SaveAs";
            this.SaveAs.Size = new System.Drawing.Size(89, 26);
            this.SaveAs.TabIndex = 4;
            this.SaveAs.Text = "SaveAs";
            this.SaveAs.UseVisualStyleBackColor = false;
            this.SaveAs.Click += new System.EventHandler(this.SaveAs_Click);
            // 
            // Save
            // 
            this.Save.BackColor = System.Drawing.SystemColors.Highlight;
            this.Save.Dock = System.Windows.Forms.DockStyle.Top;
            this.Save.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Save.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Save.Location = new System.Drawing.Point(0, 78);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(89, 26);
            this.Save.TabIndex = 3;
            this.Save.Text = "Save";
            this.Save.UseVisualStyleBackColor = false;
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // Open
            // 
            this.Open.BackColor = System.Drawing.SystemColors.Highlight;
            this.Open.Dock = System.Windows.Forms.DockStyle.Top;
            this.Open.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Open.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Open.Location = new System.Drawing.Point(0, 52);
            this.Open.Name = "Open";
            this.Open.Size = new System.Drawing.Size(89, 26);
            this.Open.TabIndex = 2;
            this.Open.Text = "Open";
            this.Open.UseVisualStyleBackColor = false;
            this.Open.Click += new System.EventHandler(this.Open_Click);
            // 
            // New
            // 
            this.New.BackColor = System.Drawing.SystemColors.Highlight;
            this.New.Dock = System.Windows.Forms.DockStyle.Top;
            this.New.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.New.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.New.Location = new System.Drawing.Point(0, 26);
            this.New.Name = "New";
            this.New.Size = new System.Drawing.Size(89, 26);
            this.New.TabIndex = 1;
            this.New.Text = "New";
            this.New.UseVisualStyleBackColor = false;
            this.New.Click += new System.EventHandler(this.New_Click);
            // 
            // File
            // 
            this.File.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.File.CausesValidation = false;
            this.File.Dock = System.Windows.Forms.DockStyle.Top;
            this.File.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.File.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.File.Location = new System.Drawing.Point(0, 0);
            this.File.Name = "File";
            this.File.Size = new System.Drawing.Size(89, 26);
            this.File.TabIndex = 0;
            this.File.Text = "File";
            this.File.UseVisualStyleBackColor = false;
            this.File.Click += new System.EventHandler(this.File_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 15;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Help
            // 
            this.Help.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.Help.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Help.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Help.Location = new System.Drawing.Point(98, 2);
            this.Help.Name = "Help";
            this.Help.Size = new System.Drawing.Size(89, 26);
            this.Help.TabIndex = 14;
            this.Help.Text = "Help";
            this.Help.UseVisualStyleBackColor = false;
            this.Help.Click += new System.EventHandler(this.Help_Click);
            // 
            // DisplayPanel
            // 
            this.DisplayPanel.BackColor = System.Drawing.Color.MistyRose;
            this.DisplayPanel.Controls.Add(this.CellName);
            this.DisplayPanel.Controls.Add(this.CellContent);
            this.DisplayPanel.Controls.Add(this.CellValue);
            this.DisplayPanel.Controls.Add(this.label1);
            this.DisplayPanel.Controls.Add(this.label3);
            this.DisplayPanel.Controls.Add(this.label2);
            this.DisplayPanel.Location = new System.Drawing.Point(193, 3);
            this.DisplayPanel.Name = "DisplayPanel";
            this.DisplayPanel.Size = new System.Drawing.Size(200, 100);
            this.DisplayPanel.TabIndex = 15;
            // 
            // ControlPanel
            // 
            this.ControlPanel.BackColor = System.Drawing.Color.MistyRose;
            this.ControlPanel.Controls.Add(this.Enter);
            this.ControlPanel.Controls.Add(this.RightButton);
            this.ControlPanel.Controls.Add(this.UpButton);
            this.ControlPanel.Controls.Add(this.LeftButton);
            this.ControlPanel.Controls.Add(this.DownButton);
            this.ControlPanel.Location = new System.Drawing.Point(409, 3);
            this.ControlPanel.Name = "ControlPanel";
            this.ControlPanel.Size = new System.Drawing.Size(249, 100);
            this.ControlPanel.TabIndex = 16;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(935, 543);
            this.Controls.Add(this.ControlPanel);
            this.Controls.Add(this.DisplayPanel);
            this.Controls.Add(this.Help);
            this.Controls.Add(this.FileMenu);
            this.Controls.Add(this.spreadsheetPanel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.FileMenu.ResumeLayout(false);
            this.DisplayPanel.ResumeLayout(false);
            this.DisplayPanel.PerformLayout();
            this.ControlPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private SS.SpreadsheetPanel spreadsheetPanel1;
        private System.Windows.Forms.TextBox CellContent;
        private System.Windows.Forms.Button UpButton;
        private System.Windows.Forms.Button DownButton;
        private System.Windows.Forms.Button RightButton;
        private System.Windows.Forms.Button LeftButton;
        private System.Windows.Forms.TextBox CellName;
        private System.Windows.Forms.TextBox CellValue;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button Enter;
        private System.Windows.Forms.Panel FileMenu;
        private System.Windows.Forms.Button File;
        private System.Windows.Forms.Button SaveAs;
        private System.Windows.Forms.Button Save;
        private System.Windows.Forms.Button Open;
        private System.Windows.Forms.Button New;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button Help;
        private System.Windows.Forms.Panel DisplayPanel;
        private System.Windows.Forms.Panel ControlPanel;
        private System.Windows.Forms.Button Close;
    }
}

