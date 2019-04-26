namespace VixenModules.ElementNodeFilter.GroupFilter
{
	partial class GroupFilterSetup
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
			this.btnOk = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.numericUpDownElementsPerGroup = new System.Windows.Forms.NumericUpDown();
			this.chkSingleGroup = new System.Windows.Forms.CheckBox();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownElementsPerGroup)).BeginInit();
			this.SuspendLayout();
			// 
			// btnOk
			// 
			this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOk.Location = new System.Drawing.Point(58, 102);
			this.btnOk.Name = "btnOk";
			this.btnOk.Size = new System.Drawing.Size(75, 23);
			this.btnOk.TabIndex = 1;
			this.btnOk.Text = "OK";
			this.btnOk.UseVisualStyleBackColor = true;
			this.btnOk.MouseLeave += new System.EventHandler(this.buttonBackground_MouseLeave);
			this.btnOk.MouseHover += new System.EventHandler(this.buttonBackground_MouseHover);
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(139, 102);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 2;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.MouseLeave += new System.EventHandler(this.buttonBackground_MouseLeave);
			this.btnCancel.MouseHover += new System.EventHandler(this.buttonBackground_MouseHover);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(22, 59);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(111, 15);
			this.label1.TabIndex = 4;
			this.label1.Text = "Elements Per Group";
			// 
			// numericUpDownElementsPerGroup
			// 
			this.numericUpDownElementsPerGroup.Location = new System.Drawing.Point(139, 57);
			this.numericUpDownElementsPerGroup.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
			this.numericUpDownElementsPerGroup.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.numericUpDownElementsPerGroup.Name = "numericUpDownElementsPerGroup";
			this.numericUpDownElementsPerGroup.Size = new System.Drawing.Size(75, 23);
			this.numericUpDownElementsPerGroup.TabIndex = 5;
			this.numericUpDownElementsPerGroup.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// chkGroupAll
			// 
			this.chkSingleGroup.AutoSize = true;
			this.chkSingleGroup.Checked = true;
			this.chkSingleGroup.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkSingleGroup.Location = new System.Drawing.Point(27, 23);
			this.chkSingleGroup.Name = "chkSingleGroup";
			this.chkSingleGroup.Size = new System.Drawing.Size(94, 19);
			this.chkSingleGroup.TabIndex = 6;
			this.chkSingleGroup.Text = "Single Group";
			this.chkSingleGroup.UseVisualStyleBackColor = true;
			// 
			// GroupFilterSetup
			// 
			this.AcceptButton = this.btnOk;
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(226, 137);
			this.Controls.Add(this.chkSingleGroup);
			this.Controls.Add(this.numericUpDownElementsPerGroup);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOk);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.HelpButton = true;
			this.Name = "GroupFilterSetup";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Group Transform";
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownElementsPerGroup)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Button btnOk;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.NumericUpDown numericUpDownElementsPerGroup;
		private System.Windows.Forms.CheckBox chkSingleGroup;
	}
}