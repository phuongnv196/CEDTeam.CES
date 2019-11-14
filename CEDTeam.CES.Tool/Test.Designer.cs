namespace CEDTeam.CES.Tool
{
    partial class Test
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
            PresentationControls.CheckBoxProperties checkBoxProperties1 = new PresentationControls.CheckBoxProperties();
            this.checkBoxComboBox1 = new PresentationControls.CheckBoxComboBox();
            this.SuspendLayout();
            // 
            // checkBoxComboBox1
            // 
            checkBoxProperties1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.checkBoxComboBox1.CheckBoxProperties = checkBoxProperties1;
            this.checkBoxComboBox1.DisplayMemberSingleItem = "";
            this.checkBoxComboBox1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.checkBoxComboBox1.DropDownControl = this.checkBoxComboBox1;
            this.checkBoxComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.checkBoxComboBox1.FormattingEnabled = true;
            this.checkBoxComboBox1.Items.AddRange(new object[] {
            "aaa",
            "aaa",
            "aaa"});
            this.checkBoxComboBox1.Location = new System.Drawing.Point(41, 52);
            this.checkBoxComboBox1.MaximumSize = new System.Drawing.Size(231, 0);
            this.checkBoxComboBox1.MinimumSize = new System.Drawing.Size(231, 0);
            this.checkBoxComboBox1.Name = "checkBoxComboBox1";
            this.checkBoxComboBox1.Size = new System.Drawing.Size(231, 21);
            this.checkBoxComboBox1.Sorted = true;
            this.checkBoxComboBox1.TabIndex = 0;
            // 
            // Test
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.checkBoxComboBox1);
            this.MaximumSize = new System.Drawing.Size(816, 489);
            this.MinimumSize = new System.Drawing.Size(816, 489);
            this.Name = "Test";
            this.Text = "Test";
            this.ResumeLayout(false);

        }

        #endregion

        private PresentationControls.CheckBoxComboBox checkBoxComboBox1;
    }
}