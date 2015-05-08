namespace SQADemicApp
{
    partial class Form3
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
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.MoveButton = new System.Windows.Forms.Button();
            this.ResearchButton = new System.Windows.Forms.Button();
            this.CreateCureButton = new System.Windows.Forms.Button();
            this.CureCityButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(46, 540);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(202, 23);
            this.progressBar1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(77, 577);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Move Count: 4/4";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Location = new System.Drawing.Point(43, 303);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(202, 180);
            this.listBox1.TabIndex = 2;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // MoveButton
            // 
            this.MoveButton.Location = new System.Drawing.Point(25, 12);
            this.MoveButton.Name = "MoveButton";
            this.MoveButton.Size = new System.Drawing.Size(101, 63);
            this.MoveButton.TabIndex = 3;
            this.MoveButton.Text = "Move";
            this.MoveButton.UseVisualStyleBackColor = true;
            this.MoveButton.Click += new System.EventHandler(this.MoveButton_Click);
            // 
            // ResearchButton
            // 
            this.ResearchButton.Location = new System.Drawing.Point(159, 12);
            this.ResearchButton.Name = "ResearchButton";
            this.ResearchButton.Size = new System.Drawing.Size(101, 63);
            this.ResearchButton.TabIndex = 4;
            this.ResearchButton.Text = "Build Research Station";
            this.ResearchButton.UseVisualStyleBackColor = true;
            this.ResearchButton.Click += new System.EventHandler(this.ResearchButton_Click);
            // 
            // CreateCureButton
            // 
            this.CreateCureButton.Location = new System.Drawing.Point(25, 100);
            this.CreateCureButton.Name = "CreateCureButton";
            this.CreateCureButton.Size = new System.Drawing.Size(101, 63);
            this.CreateCureButton.TabIndex = 5;
            this.CreateCureButton.Text = "Create Cure";
            this.CreateCureButton.UseVisualStyleBackColor = true;
            this.CreateCureButton.Click += new System.EventHandler(this.CreateCureButton_Click);
            // 
            // CureCityButton
            // 
            this.CureCityButton.Location = new System.Drawing.Point(159, 100);
            this.CureCityButton.Name = "CureCityButton";
            this.CureCityButton.Size = new System.Drawing.Size(101, 63);
            this.CureCityButton.TabIndex = 6;
            this.CureCityButton.Text = "Cure City";
            this.CureCityButton.UseVisualStyleBackColor = true;
            this.CureCityButton.Click += new System.EventHandler(this.CureCityButton_Click);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(286, 612);
            this.Controls.Add(this.CureCityButton);
            this.Controls.Add(this.CreateCureButton);
            this.Controls.Add(this.ResearchButton);
            this.Controls.Add(this.MoveButton);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.progressBar1);
            this.Name = "Form3";
            this.Text = "Player Turn";
            this.Load += new System.EventHandler(this.Form3_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ProgressBar progressBar1;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button MoveButton;
        private System.Windows.Forms.Button ResearchButton;
        private System.Windows.Forms.Button CreateCureButton;
        private System.Windows.Forms.Button CureCityButton;
    }
}