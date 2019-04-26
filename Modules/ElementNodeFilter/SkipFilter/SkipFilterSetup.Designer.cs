namespace VixenModules.ElementNodeFilter.SkipFilter
{
	partial class SkipFilterSetup
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
			this.numericUpDownFirstN = new System.Windows.Forms.NumericUpDown();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.lblTake = new System.Windows.Forms.Label();
			this.lblSkip = new System.Windows.Forms.Label();
			this.numericUpDownTakeN = new System.Windows.Forms.NumericUpDown();
			this.numericUpDownSkipN = new System.Windows.Forms.NumericUpDown();
			this.lblFirst = new System.Windows.Forms.Label();
			this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
			this.radioButtonSkipFirst = new System.Windows.Forms.RadioButton();
			this.radioButtonUseFirst = new System.Windows.Forms.RadioButton();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownFirstN)).BeginInit();
			this.tableLayoutPanel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownTakeN)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownSkipN)).BeginInit();
			this.flowLayoutPanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// btnOk
			// 
			this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOk.Location = new System.Drawing.Point(124, 132);
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
			this.btnCancel.Location = new System.Drawing.Point(205, 132);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 2;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.MouseLeave += new System.EventHandler(this.buttonBackground_MouseLeave);
			this.btnCancel.MouseHover += new System.EventHandler(this.buttonBackground_MouseHover);
			// 
			// numericUpDownFirstN
			// 
			this.numericUpDownFirstN.Location = new System.Drawing.Point(205, 3);
			this.numericUpDownFirstN.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
			this.numericUpDownFirstN.Name = "numericUpDownFirstN";
			this.numericUpDownFirstN.Size = new System.Drawing.Size(75, 23);
			this.numericUpDownFirstN.TabIndex = 5;
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 2;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.Controls.Add(this.lblTake, 0, 2);
			this.tableLayoutPanel1.Controls.Add(this.lblSkip, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.numericUpDownTakeN, 1, 2);
			this.tableLayoutPanel1.Controls.Add(this.numericUpDownFirstN, 1, 0);
			this.tableLayoutPanel1.Controls.Add(this.numericUpDownSkipN, 1, 1);
			this.tableLayoutPanel1.Controls.Add(this.btnOk, 0, 4);
			this.tableLayoutPanel1.Controls.Add(this.btnCancel, 1, 4);
			this.tableLayoutPanel1.Controls.Add(this.lblFirst, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 3);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 5;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.Size = new System.Drawing.Size(283, 158);
			this.tableLayoutPanel1.TabIndex = 7;
			// 
			// lblTake
			// 
			this.lblTake.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.lblTake.AutoSize = true;
			this.lblTake.Location = new System.Drawing.Point(45, 65);
			this.lblTake.Name = "lblTake";
			this.lblTake.Size = new System.Drawing.Size(154, 15);
			this.lblTake.TabIndex = 13;
			this.lblTake.Text = "Number of Elements To Use";
			// 
			// lblSkip
			// 
			this.lblSkip.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.lblSkip.AutoSize = true;
			this.lblSkip.Location = new System.Drawing.Point(44, 36);
			this.lblSkip.Name = "lblSkip";
			this.lblSkip.Size = new System.Drawing.Size(155, 15);
			this.lblSkip.TabIndex = 12;
			this.lblSkip.Text = "Number of Elements to Skip";
			// 
			// numericUpDownTakeN
			// 
			this.numericUpDownTakeN.Location = new System.Drawing.Point(205, 61);
			this.numericUpDownTakeN.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
			this.numericUpDownTakeN.Name = "numericUpDownTakeN";
			this.numericUpDownTakeN.Size = new System.Drawing.Size(75, 23);
			this.numericUpDownTakeN.TabIndex = 10;
			this.numericUpDownTakeN.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// numericUpDownSkipN
			// 
			this.numericUpDownSkipN.Location = new System.Drawing.Point(205, 32);
			this.numericUpDownSkipN.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
			this.numericUpDownSkipN.Name = "numericUpDownSkipN";
			this.numericUpDownSkipN.Size = new System.Drawing.Size(75, 23);
			this.numericUpDownSkipN.TabIndex = 9;
			this.numericUpDownSkipN.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// lblFirst
			// 
			this.lblFirst.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.lblFirst.AutoSize = true;
			this.lblFirst.Location = new System.Drawing.Point(111, 7);
			this.lblFirst.Name = "lblFirst";
			this.lblFirst.Size = new System.Drawing.Size(88, 15);
			this.lblFirst.TabIndex = 11;
			this.lblFirst.Text = "First Element(s)";
			// 
			// flowLayoutPanel1
			// 
			this.flowLayoutPanel1.Controls.Add(this.radioButtonSkipFirst);
			this.flowLayoutPanel1.Controls.Add(this.radioButtonUseFirst);
			this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 90);
			this.flowLayoutPanel1.Name = "flowLayoutPanel1";
			this.flowLayoutPanel1.Size = new System.Drawing.Size(196, 36);
			this.flowLayoutPanel1.TabIndex = 14;
			// 
			// radioButtonSkipFirst
			// 
			this.radioButtonSkipFirst.AutoSize = true;
			this.radioButtonSkipFirst.Checked = true;
			this.radioButtonSkipFirst.Location = new System.Drawing.Point(3, 3);
			this.radioButtonSkipFirst.Name = "radioButtonSkipFirst";
			this.radioButtonSkipFirst.Size = new System.Drawing.Size(72, 19);
			this.radioButtonSkipFirst.TabIndex = 0;
			this.radioButtonSkipFirst.TabStop = true;
			this.radioButtonSkipFirst.Text = "Skip First";
			this.radioButtonSkipFirst.UseVisualStyleBackColor = true;
			// 
			// radioButtonUseFirst
			// 
			this.radioButtonUseFirst.AutoSize = true;
			this.radioButtonUseFirst.Location = new System.Drawing.Point(81, 3);
			this.radioButtonUseFirst.Name = "radioButtonUseFirst";
			this.radioButtonUseFirst.Size = new System.Drawing.Size(106, 19);
			this.radioButtonUseFirst.TabIndex = 1;
			this.radioButtonUseFirst.Text = "Use before Skip";
			this.radioButtonUseFirst.UseVisualStyleBackColor = true;
			// 
			// SkipFilterSetup
			// 
			this.AcceptButton = this.btnOk;
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(283, 158);
			this.Controls.Add(this.tableLayoutPanel1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.HelpButton = true;
			this.Name = "SkipFilterSetup";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Skip Transform";
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownFirstN)).EndInit();
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownTakeN)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownSkipN)).EndInit();
			this.flowLayoutPanel1.ResumeLayout(false);
			this.flowLayoutPanel1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.Button btnOk;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.NumericUpDown numericUpDownFirstN;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.NumericUpDown numericUpDownTakeN;
		private System.Windows.Forms.NumericUpDown numericUpDownSkipN;
		private System.Windows.Forms.Label lblTake;
		private System.Windows.Forms.Label lblSkip;
		private System.Windows.Forms.Label lblFirst;
		private System.Windows.Forms.RadioButton radioButtonSkipFirst;
		private System.Windows.Forms.RadioButton radioButtonUseFirst;
		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
	}
}