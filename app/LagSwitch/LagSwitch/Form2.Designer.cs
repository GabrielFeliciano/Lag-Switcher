
namespace LagSwitch
{
    partial class AlwaysOnTop
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
            this.timeInput = new System.Windows.Forms.NumericUpDown();
            this.shortcutInput = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.checker = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.timeInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checker)).BeginInit();
            this.SuspendLayout();
            // 
            // timeInput
            // 
            this.timeInput.Location = new System.Drawing.Point(21, 4);
            this.timeInput.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.timeInput.Name = "timeInput";
            this.timeInput.Size = new System.Drawing.Size(73, 20);
            this.timeInput.TabIndex = 0;
            this.timeInput.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // shortcutInput
            // 
            this.shortcutInput.Location = new System.Drawing.Point(21, 30);
            this.shortcutInput.Name = "shortcutInput";
            this.shortcutInput.Size = new System.Drawing.Size(73, 20);
            this.shortcutInput.TabIndex = 1;
            this.shortcutInput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(100, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Key";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(100, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Timer";
            // 
            // checker
            // 
            this.checker.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.checker.Location = new System.Drawing.Point(5, 5);
            this.checker.Name = "checker";
            this.checker.Size = new System.Drawing.Size(10, 44);
            this.checker.TabIndex = 6;
            this.checker.TabStop = false;
            // 
            // AlwaysOnTop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(140, 54);
            this.ControlBox = false;
            this.Controls.Add(this.checker);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.shortcutInput);
            this.Controls.Add(this.timeInput);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AlwaysOnTop";
            this.ShowIcon = false;
            this.Text = "Lag Switcher";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.timeInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checker)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown timeInput;
        private System.Windows.Forms.TextBox shortcutInput;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox checker;
    }
}