namespace SQADemicApp
{
    partial class SetupGameForm
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
            this.Player1ComboBox = new System.Windows.Forms.ComboBox();
            this.Player1CheckBox = new System.Windows.Forms.CheckBox();
            this.Player2CheckBox = new System.Windows.Forms.CheckBox();
            this.Player2ComboBox = new System.Windows.Forms.ComboBox();
            this.Player3CheckBox = new System.Windows.Forms.CheckBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // Player1ComboBox
            // 
            this.Player1ComboBox.FormattingEnabled = true;
            this.Player1ComboBox.Items.AddRange(new object[] {
            "Dispatcher",
            "Operations Expert",
            "Scientist",
            "Medic",
            "Researcher"});
            this.Player1ComboBox.Location = new System.Drawing.Point(115, 27);
            this.Player1ComboBox.Name = "Player1ComboBox";
            this.Player1ComboBox.Size = new System.Drawing.Size(121, 24);
            this.Player1ComboBox.TabIndex = 0;
            // 
            // Player1CheckBox
            // 
            this.Player1CheckBox.AutoSize = true;
            this.Player1CheckBox.Location = new System.Drawing.Point(11, 29);
            this.Player1CheckBox.Name = "Player1CheckBox";
            this.Player1CheckBox.Size = new System.Drawing.Size(82, 21);
            this.Player1CheckBox.TabIndex = 2;
            this.Player1CheckBox.Text = "Player 1";
            this.Player1CheckBox.UseVisualStyleBackColor = true;
            // 
            // Player2CheckBox
            // 
            this.Player2CheckBox.AutoSize = true;
            this.Player2CheckBox.Location = new System.Drawing.Point(11, 71);
            this.Player2CheckBox.Name = "Player2CheckBox";
            this.Player2CheckBox.Size = new System.Drawing.Size(82, 21);
            this.Player2CheckBox.TabIndex = 3;
            this.Player2CheckBox.Text = "Player 2";
            this.Player2CheckBox.UseVisualStyleBackColor = true;
            // 
            // Player2ComboBox
            // 
            this.Player2ComboBox.FormattingEnabled = true;
            this.Player2ComboBox.Items.AddRange(new object[] {
            "Dispatcher",
            "Operations Expert",
            "Scientist",
            "Medic",
            "Researcher"});
            this.Player2ComboBox.Location = new System.Drawing.Point(115, 71);
            this.Player2ComboBox.Name = "Player2ComboBox";
            this.Player2ComboBox.Size = new System.Drawing.Size(121, 24);
            this.Player2ComboBox.TabIndex = 4;
            // 
            // Player3CheckBox
            // 
            this.Player3CheckBox.AutoSize = true;
            this.Player3CheckBox.Location = new System.Drawing.Point(11, 113);
            this.Player3CheckBox.Name = "Player3CheckBox";
            this.Player3CheckBox.Size = new System.Drawing.Size(82, 21);
            this.Player3CheckBox.TabIndex = 5;
            this.Player3CheckBox.Text = "Player 3";
            this.Player3CheckBox.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Dispatcher",
            "Operations Expert",
            "Scientist",
            "Medic",
            "Researcher"});
            this.comboBox1.Location = new System.Drawing.Point(115, 113);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 24);
            this.comboBox1.TabIndex = 6;
            // 
            // SetupGameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(593, 576);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.Player3CheckBox);
            this.Controls.Add(this.Player2ComboBox);
            this.Controls.Add(this.Player2CheckBox);
            this.Controls.Add(this.Player1CheckBox);
            this.Controls.Add(this.Player1ComboBox);
            this.Name = "SetupGameForm";
            this.Text = "SetupGameForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox Player1ComboBox;
        private System.Windows.Forms.CheckBox Player1CheckBox;
        private System.Windows.Forms.CheckBox Player2CheckBox;
        private System.Windows.Forms.ComboBox Player2ComboBox;
        private System.Windows.Forms.CheckBox Player3CheckBox;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}