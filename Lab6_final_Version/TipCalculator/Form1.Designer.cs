namespace TipCalculator
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
            System.Windows.Forms.Label bill;
            this.bill_box = new System.Windows.Forms.TextBox();
            this.tip_button = new System.Windows.Forms.Button();
            this.tip_box = new System.Windows.Forms.TextBox();
            this.tip_percent = new System.Windows.Forms.Label();
            this.tip = new System.Windows.Forms.TextBox();
            this.tip_cal_2 = new System.Windows.Forms.Label();
            this.tip_cal_2_entry = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            bill = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // bill
            // 
            bill.AutoSize = true;
            bill.Location = new System.Drawing.Point(118, 83);
            bill.Name = "bill";
            bill.Size = new System.Drawing.Size(111, 20);
            bill.TabIndex = 1;
            bill.Text = "Enter Total Bill";
            bill.Click += new System.EventHandler(this.label1_Click);
            // 
            // bill_box
            // 
            this.bill_box.Location = new System.Drawing.Point(288, 80);
            this.bill_box.Name = "bill_box";
            this.bill_box.Size = new System.Drawing.Size(229, 26);
            this.bill_box.TabIndex = 0;
            this.bill_box.TextChanged += new System.EventHandler(this.Bill_box);
            // 
            // tip_button
            // 
            this.tip_button.Location = new System.Drawing.Point(112, 133);
            this.tip_button.Name = "tip_button";
            this.tip_button.Size = new System.Drawing.Size(147, 48);
            this.tip_button.TabIndex = 2;
            this.tip_button.Text = "Compute Tip";
            this.tip_button.UseVisualStyleBackColor = true;
            this.tip_button.Click += new System.EventHandler(this.button1_Click);
            // 
            // tip_box
            // 
            this.tip_box.Location = new System.Drawing.Point(288, 144);
            this.tip_box.Name = "tip_box";
            this.tip_box.Size = new System.Drawing.Size(229, 26);
            this.tip_box.TabIndex = 3;
            this.tip_box.TextChanged += new System.EventHandler(this.tip_box_TextChanged);
            // 
            // tip_percent
            // 
            this.tip_percent.AutoSize = true;
            this.tip_percent.Location = new System.Drawing.Point(118, 215);
            this.tip_percent.Name = "tip_percent";
            this.tip_percent.Size = new System.Drawing.Size(174, 30);
            this.tip_percent.TabIndex = 4;
            this.tip_percent.Text = "Tip Percentage";
            this.tip_percent.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // tip
            // 
            this.tip.Location = new System.Drawing.Point(288, 209);
            this.tip.Name = "tip";
            this.tip.Size = new System.Drawing.Size(229, 26);
            this.tip.TabIndex = 5;
            this.tip.TextChanged += new System.EventHandler(this.amount_box_TextChanged);
            // 
            // tip_cal_2
            // 
            this.tip_cal_2.AutoSize = true;
            this.tip_cal_2.Location = new System.Drawing.Point(118, 271);
            this.tip_cal_2.Name = "tip_cal_2";
            this.tip_cal_2.Size = new System.Drawing.Size(150, 30);
            this.tip_cal_2.TabIndex = 6;
            this.tip_cal_2.Text = "Tip Calculate";
            this.tip_cal_2.Click += new System.EventHandler(this.label1_Click_2);
            // 
            // tip_cal_2_entry
            // 
            this.tip_cal_2_entry.Location = new System.Drawing.Point(288, 262);
            this.tip_cal_2_entry.Name = "tip_cal_2_entry";
            this.tip_cal_2_entry.Size = new System.Drawing.Size(229, 26);
            this.tip_cal_2_entry.TabIndex = 7;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(0, 0);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 26);
            this.textBox1.TabIndex = 8;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.tip_cal_2_entry);
            this.Controls.Add(this.tip_cal_2);
            this.Controls.Add(this.tip);
            this.Controls.Add(this.tip_percent);
            this.Controls.Add(this.tip_box);
            this.Controls.Add(this.tip_button);
            this.Controls.Add(bill);
            this.Controls.Add(this.bill_box);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox bill_box;
        private System.Windows.Forms.Button tip_button;
        private System.Windows.Forms.TextBox tip_box;
        private System.Windows.Forms.Label tip_percent;
        private System.Windows.Forms.TextBox tip;
        private System.Windows.Forms.Label tip_cal_2;
        private System.Windows.Forms.TextBox tip_cal_2_entry;
        private System.Windows.Forms.TextBox textBox1;
    }
}

