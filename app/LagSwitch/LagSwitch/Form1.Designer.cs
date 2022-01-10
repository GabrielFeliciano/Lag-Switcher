
namespace LagSwitch
{
    partial class MainForm
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
            this.lagBtn = new System.Windows.Forms.Button();
            this.timeInput = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.pathShow = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.searchBtn = new System.Windows.Forms.Button();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.shortcutInput = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.alwaysOnTopCheckBox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.timeInput)).BeginInit();
            this.SuspendLayout();
            // 
            // lagBtn
            // 
            this.lagBtn.Location = new System.Drawing.Point(238, 70);
            this.lagBtn.Name = "lagBtn";
            this.lagBtn.Size = new System.Drawing.Size(103, 23);
            this.lagBtn.TabIndex = 0;
            this.lagBtn.Text = "Lag";
            this.lagBtn.UseVisualStyleBackColor = true;
            this.lagBtn.Click += new System.EventHandler(this.lagBtn_Click);
            // 
            // timeInput
            // 
            this.timeInput.Location = new System.Drawing.Point(10, 73);
            this.timeInput.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.timeInput.Name = "timeInput";
            this.timeInput.Size = new System.Drawing.Size(107, 20);
            this.timeInput.TabIndex = 1;
            this.timeInput.ValueChanged += new System.EventHandler(this.timeInput_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Time (ms)";
            // 
            // pathShow
            // 
            this.pathShow.Enabled = false;
            this.pathShow.Location = new System.Drawing.Point(12, 25);
            this.pathShow.Name = "pathShow";
            this.pathShow.Size = new System.Drawing.Size(219, 20);
            this.pathShow.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Path to executable";
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "Browser";
            this.openFileDialog.Filter = "(*.exe)|*.exe";
            this.openFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog_FileOk);
            // 
            // searchBtn
            // 
            this.searchBtn.Location = new System.Drawing.Point(238, 23);
            this.searchBtn.Name = "searchBtn";
            this.searchBtn.Size = new System.Drawing.Size(102, 23);
            this.searchBtn.TabIndex = 5;
            this.searchBtn.Text = "Search";
            this.searchBtn.UseVisualStyleBackColor = true;
            this.searchBtn.Click += new System.EventHandler(this.searchBtn_Click);
            // 
            // timer
            // 
            this.timer.Interval = 1;
            // 
            // shortcutInput
            // 
            this.shortcutInput.Location = new System.Drawing.Point(123, 72);
            this.shortcutInput.Name = "shortcutInput";
            this.shortcutInput.Size = new System.Drawing.Size(108, 20);
            this.shortcutInput.TabIndex = 6;
            this.shortcutInput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.shortcutInput_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(120, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Shortcut";
            // 
            // alwaysOnTopCheckBox
            // 
            this.alwaysOnTopCheckBox.AutoSize = true;
            this.alwaysOnTopCheckBox.Location = new System.Drawing.Point(129, 101);
            this.alwaysOnTopCheckBox.Name = "alwaysOnTopCheckBox";
            this.alwaysOnTopCheckBox.Size = new System.Drawing.Size(96, 17);
            this.alwaysOnTopCheckBox.TabIndex = 8;
            this.alwaysOnTopCheckBox.Text = "Always on Top";
            this.alwaysOnTopCheckBox.UseVisualStyleBackColor = true;
            this.alwaysOnTopCheckBox.CheckedChanged += new System.EventHandler(this.AlwaysOnTopCheckBox_CheckedChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(352, 130);
            this.Controls.Add(this.alwaysOnTopCheckBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.shortcutInput);
            this.Controls.Add(this.searchBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pathShow);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.timeInput);
            this.Controls.Add(this.lagBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "MainForm";
            this.Text = "Lag Switcher";
            ((System.ComponentModel.ISupportInitialize)(this.timeInput)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button lagBtn;
        private System.Windows.Forms.NumericUpDown timeInput;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox pathShow;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button searchBtn;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.TextBox shortcutInput;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox alwaysOnTopCheckBox;
    }
}

