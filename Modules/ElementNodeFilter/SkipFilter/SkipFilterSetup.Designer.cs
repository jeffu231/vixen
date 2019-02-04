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
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownFirstN)).BeginInit();
			this.tableLayoutPanel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownTakeN)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownSkipN)).BeginInit();
			this.SuspendLayout();
			// 
			// btnOk
			// 
			this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOk.Location = new System.Drawing.Point(47, 116);
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
			this.btnCancel.Location = new System.Drawing.Point(128, 116);
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
			this.numericUpDownFirstN.Location = new System.Drawing.Point(128, 3);
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
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 5;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.Size = new System.Drawing.Size(206, 142);
			this.tableLayoutPanel1.TabIndex = 7;
			// 
			// lblTake
			// 
			this.lblTake.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.lblTake.AutoSize = true;
			this.lblTake.Location = new System.Drawing.Point(79, 65);
			this.lblTake.Name = "lblTake";
			this.lblTake.Size = new System.Drawing.Size(43, 15);
			this.lblTake.TabIndex = 13;
			this.lblTake.Text = "Take N";
			// 
			// lblSkip
			// 
			this.lblSkip.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.lblSkip.AutoSize = true;
			this.lblSkip.Location = new System.Drawing.Point(81, 36);
			this.lblSkip.Name = "lblSkip";
			this.lblSkip.Size = new System.Drawing.Size(41, 15);
			this.lblSkip.TabIndex = 12;
			this.lblSkip.Text = "Skip N";
			// 
			// numericUpDownTakeN
			// 
			this.numericUpDownTakeN.Location = new System.Drawing.Point(128, 61);
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
			this.numericUpDownSkipN.Location = new System.Drawing.Point(128, 32);
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
			this.lblFirst.Location = new System.Drawing.Point(81, 7);
			this.lblFirst.Name = "lblFirst";
			this.lblFirst.Size = new System.Drawing.Size(41, 15);
			this.lblFirst.TabIndex = 11;
			this.lblFirst.Text = "First N";
			// 
			// SkipFilterSetup
			// 
			this.AcceptButton = this.btnOk;
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(206, 142);
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
	}
}