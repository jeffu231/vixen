using System.Windows.Forms;

namespace VixenApplication.Setup
{
	partial class SetupPatchingSimple
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
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.groupBoxElements = new System.Windows.Forms.GroupBox();
			this.panel2 = new System.Windows.Forms.Panel();
			this.labelFilterCount = new System.Windows.Forms.Label();
			this.labelElementCount = new System.Windows.Forms.Label();
			this.labelGroupCount = new System.Windows.Forms.Label();
			this.labelItemCount = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.labelUnconnectedPatchPointCount = new System.Windows.Forms.Label();
			this.labelConnectedPatchPointCount = new System.Windows.Forms.Label();
			this.labelPatchPointCount = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.buttonUnpatchElements = new System.Windows.Forms.Button();
			this.checkBoxReverseElementOrder = new System.Windows.Forms.CheckBox();
			this.groupBoxControllers = new System.Windows.Forms.GroupBox();
			this.panel1 = new System.Windows.Forms.Panel();
			this.labelLastOutput = new System.Windows.Forms.Label();
			this.labelFirstOutput = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.labelUnpatchedOutputCount = new System.Windows.Forms.Label();
			this.labelPatchedOutputCount = new System.Windows.Forms.Label();
			this.labelOutputCount = new System.Windows.Forms.Label();
			this.labelControllerCount = new System.Windows.Forms.Label();
			this.label15 = new System.Windows.Forms.Label();
			this.label16 = new System.Windows.Forms.Label();
			this.label20 = new System.Windows.Forms.Label();
			this.label21 = new System.Windows.Forms.Label();
			this.buttonUnpatchControllers = new System.Windows.Forms.Button();
			this.checkBoxReverseOutputOrder = new System.Windows.Forms.CheckBox();
			this.groupBoxElementOptions = new System.Windows.Forms.GroupBox();
			this.radioButtonAllAvailablePatchPoints = new System.Windows.Forms.RadioButton();
			this.radioButtonUnconnectedPatchPointsOnly = new System.Windows.Forms.RadioButton();
			this.groupBoxOutputOptions = new System.Windows.Forms.GroupBox();
			this.radioButtonAllOutputs = new System.Windows.Forms.RadioButton();
			this.radioButtonUnpatchedOutputsOnly = new System.Windows.Forms.RadioButton();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.buttonDoPatching = new System.Windows.Forms.Button();
			this.labelPatchSummary = new System.Windows.Forms.Label();
			this.tableLayoutControllerInfo = new System.Windows.Forms.TableLayoutPanel();
			this.tableLayoutElementInfo = new System.Windows.Forms.TableLayoutPanel();
			this.labelPatchWarning = new System.Windows.Forms.Label();
			this.groupBoxElements.SuspendLayout();
			this.groupBoxControllers.SuspendLayout();
			this.groupBoxElementOptions.SuspendLayout();
			this.groupBoxOutputOptions.SuspendLayout();
			this.tableLayoutPanel1.SuspendLayout();
			this.tableLayoutControllerInfo.SuspendLayout();
			this.tableLayoutElementInfo.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBoxElements
			// 
			this.groupBoxElements.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBoxElements.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.groupBoxElements.Controls.Add(this.tableLayoutElementInfo);
			this.groupBoxElements.Controls.Add(this.panel1);
			this.groupBoxElements.Controls.Add(this.panel2);
			this.groupBoxElements.Location = new System.Drawing.Point(3, 3);
			this.groupBoxElements.Name = "groupBoxElements";
			this.groupBoxElements.Size = new System.Drawing.Size(220, 231);
			this.groupBoxElements.TabIndex = 0;
			this.groupBoxElements.TabStop = false;
			this.groupBoxElements.Text = "Selected Elements";
			this.groupBoxElements.Paint += new System.Windows.Forms.PaintEventHandler(this.groupBoxes_Paint);
			// 
			// panel2
			// 
			this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panel2.AutoSize = true;
			this.panel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.panel2.Location = new System.Drawing.Point(6, 18);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(0, 0);
			this.panel2.TabIndex = 23;
			// 
			// labelFilterCount
			// 
			this.labelFilterCount.AutoSize = true;
			this.labelFilterCount.Location = new System.Drawing.Point(108, 127);
			this.labelFilterCount.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
			this.labelFilterCount.Name = "labelFilterCount";
			this.labelFilterCount.Size = new System.Drawing.Size(13, 13);
			this.labelFilterCount.TabIndex = 21;
			this.labelFilterCount.Text = "0";
			// 
			// labelElementCount
			// 
			this.labelElementCount.AutoSize = true;
			this.labelElementCount.Location = new System.Drawing.Point(108, 111);
			this.labelElementCount.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
			this.labelElementCount.Name = "labelElementCount";
			this.labelElementCount.Size = new System.Drawing.Size(13, 13);
			this.labelElementCount.TabIndex = 20;
			this.labelElementCount.Text = "0";
			// 
			// labelGroupCount
			// 
			this.labelGroupCount.AutoSize = true;
			this.labelGroupCount.Location = new System.Drawing.Point(108, 95);
			this.labelGroupCount.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
			this.labelGroupCount.Name = "labelGroupCount";
			this.labelGroupCount.Size = new System.Drawing.Size(13, 13);
			this.labelGroupCount.TabIndex = 19;
			this.labelGroupCount.Text = "0";
			// 
			// labelItemCount
			// 
			this.labelItemCount.AutoSize = true;
			this.labelItemCount.Location = new System.Drawing.Point(108, 79);
			this.labelItemCount.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
			this.labelItemCount.Name = "labelItemCount";
			this.labelItemCount.Size = new System.Drawing.Size(13, 13);
			this.labelItemCount.TabIndex = 18;
			this.labelItemCount.Text = "0";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(5, 127);
			this.label4.Margin = new System.Windows.Forms.Padding(5, 3, 3, 0);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(37, 13);
			this.label4.TabIndex = 17;
			this.label4.Text = "Filters:";
			this.toolTip1.SetToolTip(this.label4, "The number of filters found in the patching connections from the selected element" +
        "s.");
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(5, 111);
			this.label3.Margin = new System.Windows.Forms.Padding(5, 3, 3, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(53, 13);
			this.label3.TabIndex = 16;
			this.label3.Text = "Elements:";
			this.toolTip1.SetToolTip(this.label3, "The number of elements found in (or descending from) the selected elements.");
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(5, 95);
			this.label2.Margin = new System.Windows.Forms.Padding(5, 3, 3, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(44, 13);
			this.label2.TabIndex = 15;
			this.label2.Text = "Groups:";
			this.toolTip1.SetToolTip(this.label2, "The number of groups found from the selected elements.");
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(5, 79);
			this.label1.Margin = new System.Windows.Forms.Padding(5, 3, 3, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(35, 13);
			this.label1.TabIndex = 14;
			this.label1.Text = "Items:";
			this.toolTip1.SetToolTip(this.label1, "The number of items selected in the element view.");
			// 
			// labelUnconnectedPatchPointCount
			// 
			this.labelUnconnectedPatchPointCount.AutoSize = true;
			this.labelUnconnectedPatchPointCount.Location = new System.Drawing.Point(108, 48);
			this.labelUnconnectedPatchPointCount.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
			this.labelUnconnectedPatchPointCount.Name = "labelUnconnectedPatchPointCount";
			this.labelUnconnectedPatchPointCount.Size = new System.Drawing.Size(13, 13);
			this.labelUnconnectedPatchPointCount.TabIndex = 13;
			this.labelUnconnectedPatchPointCount.Text = "0";
			// 
			// labelConnectedPatchPointCount
			// 
			this.labelConnectedPatchPointCount.AutoSize = true;
			this.labelConnectedPatchPointCount.Location = new System.Drawing.Point(108, 32);
			this.labelConnectedPatchPointCount.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
			this.labelConnectedPatchPointCount.Name = "labelConnectedPatchPointCount";
			this.labelConnectedPatchPointCount.Size = new System.Drawing.Size(13, 13);
			this.labelConnectedPatchPointCount.TabIndex = 12;
			this.labelConnectedPatchPointCount.Text = "0";
			// 
			// labelPatchPointCount
			// 
			this.labelPatchPointCount.AutoSize = true;
			this.labelPatchPointCount.Location = new System.Drawing.Point(108, 13);
			this.labelPatchPointCount.Margin = new System.Windows.Forms.Padding(3);
			this.labelPatchPointCount.Name = "labelPatchPointCount";
			this.labelPatchPointCount.Size = new System.Drawing.Size(13, 13);
			this.labelPatchPointCount.TabIndex = 11;
			this.labelPatchPointCount.Text = "0";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(5, 48);
			this.label7.Margin = new System.Windows.Forms.Padding(5, 3, 3, 0);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(75, 13);
			this.label7.TabIndex = 6;
			this.label7.Text = "Unconnected:";
			this.toolTip1.SetToolTip(this.label7, "The number of Patch Points connected to the selected elements that have nothing e" +
        "lse connected.");
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(5, 32);
			this.label6.Margin = new System.Windows.Forms.Padding(5, 3, 3, 0);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(62, 13);
			this.label6.TabIndex = 5;
			this.label6.Text = "Connected:";
			this.toolTip1.SetToolTip(this.label6, "The number of Patch Points connected to the selected elements that are being patc" +
        "hed to controller outputs.");
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(5, 13);
			this.label5.Margin = new System.Windows.Forms.Padding(5, 3, 3, 3);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(97, 13);
			this.label5.TabIndex = 4;
			this.label5.Text = "Total Patch Points:";
			this.toolTip1.SetToolTip(this.label5, "The total number of Patch Points connected to the selected elements.  Patch Point" +
        "s are the outputs from any element or filter, but before it gets to the controll" +
        "ers.");
			// 
			// buttonUnpatchElements
			// 
			this.buttonUnpatchElements.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.buttonUnpatchElements.AutoSize = true;
			this.tableLayoutElementInfo.SetColumnSpan(this.buttonUnpatchElements, 2);
			this.buttonUnpatchElements.Location = new System.Drawing.Point(55, 176);
			this.buttonUnpatchElements.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
			this.buttonUnpatchElements.Name = "buttonUnpatchElements";
			this.buttonUnpatchElements.Size = new System.Drawing.Size(104, 23);
			this.buttonUnpatchElements.TabIndex = 22;
			this.buttonUnpatchElements.Text = "Unpatch Elements";
			this.buttonUnpatchElements.UseVisualStyleBackColor = true;
			this.buttonUnpatchElements.Click += new System.EventHandler(this.buttonUnpatchElements_Click);
			this.buttonUnpatchElements.MouseLeave += new System.EventHandler(this.buttonBackground_MouseLeave);
			this.buttonUnpatchElements.MouseHover += new System.EventHandler(this.buttonBackground_MouseHover);
			// 
			// checkBoxReverseElementOrder
			// 
			this.checkBoxReverseElementOrder.AutoSize = true;
			this.checkBoxReverseElementOrder.Location = new System.Drawing.Point(9, 65);
			this.checkBoxReverseElementOrder.Name = "checkBoxReverseElementOrder";
			this.checkBoxReverseElementOrder.Size = new System.Drawing.Size(136, 17);
			this.checkBoxReverseElementOrder.TabIndex = 23;
			this.checkBoxReverseElementOrder.Text = "Reverse Element Order";
			this.toolTip1.SetToolTip(this.checkBoxReverseElementOrder, "The order in which Elements will be patched to controller outputs. This does not " +
        "effect the order in which color channels are patched to controller outputs.");
			this.checkBoxReverseElementOrder.UseVisualStyleBackColor = true;
			this.checkBoxReverseElementOrder.CheckedChanged += new System.EventHandler(this.checkBoxReverseElementOrder_CheckedChanged);
			// 
			// groupBoxControllers
			// 
			this.groupBoxControllers.AutoSize = true;
			this.groupBoxControllers.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.groupBoxControllers.Controls.Add(this.tableLayoutControllerInfo);
			this.groupBoxControllers.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBoxControllers.Location = new System.Drawing.Point(229, 3);
			this.groupBoxControllers.Name = "groupBoxControllers";
			this.groupBoxControllers.Size = new System.Drawing.Size(204, 231);
			this.groupBoxControllers.TabIndex = 1;
			this.groupBoxControllers.TabStop = false;
			this.groupBoxControllers.Text = "Selected Controllers";
			this.groupBoxControllers.Paint += new System.Windows.Forms.PaintEventHandler(this.groupBoxes_Paint);
			// 
			// panel1
			// 
			this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panel1.AutoSize = true;
			this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.panel1.Location = new System.Drawing.Point(175, 64);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(0, 0);
			this.panel1.TabIndex = 34;
			// 
			// labelLastOutput
			// 
			this.labelLastOutput.AutoSize = true;
			this.labelLastOutput.Location = new System.Drawing.Point(74, 126);
			this.labelLastOutput.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
			this.labelLastOutput.MaximumSize = new System.Drawing.Size(120, 0);
			this.labelLastOutput.MinimumSize = new System.Drawing.Size(0, 12);
			this.labelLastOutput.Name = "labelLastOutput";
			this.labelLastOutput.Size = new System.Drawing.Size(67, 13);
			this.labelLastOutput.TabIndex = 33;
			this.labelLastOutput.Text = "Controller #0";
			// 
			// labelFirstOutput
			// 
			this.labelFirstOutput.AutoSize = true;
			this.labelFirstOutput.Location = new System.Drawing.Point(74, 110);
			this.labelFirstOutput.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
			this.labelFirstOutput.MaximumSize = new System.Drawing.Size(120, 0);
			this.labelFirstOutput.MinimumSize = new System.Drawing.Size(0, 12);
			this.labelFirstOutput.Name = "labelFirstOutput";
			this.labelFirstOutput.Size = new System.Drawing.Size(67, 13);
			this.labelFirstOutput.TabIndex = 32;
			this.labelFirstOutput.Text = "Controller #0";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(5, 126);
			this.label9.Margin = new System.Windows.Forms.Padding(5, 3, 3, 0);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(63, 13);
			this.label9.TabIndex = 31;
			this.label9.Text = "Last output:";
			this.toolTip1.SetToolTip(this.label9, "The last output in the list of selected outputs (as will be used for patching).");
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(5, 110);
			this.label8.Margin = new System.Windows.Forms.Padding(5, 3, 3, 0);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(62, 13);
			this.label8.TabIndex = 30;
			this.label8.Text = "First output:";
			this.toolTip1.SetToolTip(this.label8, "The first output in the list of selected outputs (as will be used for patching).");
			// 
			// labelUnpatchedOutputCount
			// 
			this.labelUnpatchedOutputCount.AutoSize = true;
			this.labelUnpatchedOutputCount.Location = new System.Drawing.Point(74, 48);
			this.labelUnpatchedOutputCount.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
			this.labelUnpatchedOutputCount.Name = "labelUnpatchedOutputCount";
			this.labelUnpatchedOutputCount.Size = new System.Drawing.Size(13, 13);
			this.labelUnpatchedOutputCount.TabIndex = 27;
			this.labelUnpatchedOutputCount.Text = "0";
			// 
			// labelPatchedOutputCount
			// 
			this.labelPatchedOutputCount.AutoSize = true;
			this.labelPatchedOutputCount.Location = new System.Drawing.Point(74, 32);
			this.labelPatchedOutputCount.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
			this.labelPatchedOutputCount.Name = "labelPatchedOutputCount";
			this.labelPatchedOutputCount.Size = new System.Drawing.Size(13, 13);
			this.labelPatchedOutputCount.TabIndex = 26;
			this.labelPatchedOutputCount.Text = "0";
			// 
			// labelOutputCount
			// 
			this.labelOutputCount.AutoSize = true;
			this.labelOutputCount.Location = new System.Drawing.Point(74, 13);
			this.labelOutputCount.Margin = new System.Windows.Forms.Padding(3);
			this.labelOutputCount.Name = "labelOutputCount";
			this.labelOutputCount.Size = new System.Drawing.Size(13, 13);
			this.labelOutputCount.TabIndex = 22;
			this.labelOutputCount.Text = "0";
			// 
			// labelControllerCount
			// 
			this.labelControllerCount.AutoSize = true;
			this.labelControllerCount.Location = new System.Drawing.Point(74, 79);
			this.labelControllerCount.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
			this.labelControllerCount.Name = "labelControllerCount";
			this.labelControllerCount.Size = new System.Drawing.Size(13, 13);
			this.labelControllerCount.TabIndex = 21;
			this.labelControllerCount.Text = "0";
			// 
			// label15
			// 
			this.label15.AutoSize = true;
			this.label15.Location = new System.Drawing.Point(5, 48);
			this.label15.Margin = new System.Windows.Forms.Padding(5, 3, 3, 0);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(63, 13);
			this.label15.TabIndex = 20;
			this.label15.Text = "Unpatched:";
			this.toolTip1.SetToolTip(this.label15, "The number of controller outputs selected that are not connected to anything.");
			// 
			// label16
			// 
			this.label16.AutoSize = true;
			this.label16.Location = new System.Drawing.Point(5, 32);
			this.label16.Margin = new System.Windows.Forms.Padding(5, 3, 3, 0);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(50, 13);
			this.label16.TabIndex = 19;
			this.label16.Text = "Patched:";
			this.toolTip1.SetToolTip(this.label16, "The number of controller outputs selected that are already connected to something" +
        ".");
			// 
			// label20
			// 
			this.label20.AutoSize = true;
			this.label20.Location = new System.Drawing.Point(5, 13);
			this.label20.Margin = new System.Windows.Forms.Padding(5, 3, 3, 3);
			this.label20.Name = "label20";
			this.label20.Size = new System.Drawing.Size(47, 13);
			this.label20.TabIndex = 15;
			this.label20.Text = "Outputs:";
			this.toolTip1.SetToolTip(this.label20, "The total number of controller outputs selected.");
			// 
			// label21
			// 
			this.label21.AutoSize = true;
			this.label21.Location = new System.Drawing.Point(5, 79);
			this.label21.Margin = new System.Windows.Forms.Padding(5, 3, 3, 0);
			this.label21.Name = "label21";
			this.label21.Size = new System.Drawing.Size(59, 13);
			this.label21.TabIndex = 14;
			this.label21.Text = "Controllers:";
			this.toolTip1.SetToolTip(this.label21, "The number of controllers (or part thereof) selected.");
			// 
			// buttonUnpatchControllers
			// 
			this.buttonUnpatchControllers.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.buttonUnpatchControllers.AutoSize = true;
			this.tableLayoutControllerInfo.SetColumnSpan(this.buttonUnpatchControllers, 2);
			this.buttonUnpatchControllers.Location = new System.Drawing.Point(44, 176);
			this.buttonUnpatchControllers.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
			this.buttonUnpatchControllers.Name = "buttonUnpatchControllers";
			this.buttonUnpatchControllers.Size = new System.Drawing.Size(110, 23);
			this.buttonUnpatchControllers.TabIndex = 28;
			this.buttonUnpatchControllers.Text = "Unpatch Controllers";
			this.buttonUnpatchControllers.UseVisualStyleBackColor = true;
			this.buttonUnpatchControllers.Click += new System.EventHandler(this.buttonUnpatchControllers_Click);
			this.buttonUnpatchControllers.MouseLeave += new System.EventHandler(this.buttonBackground_MouseLeave);
			this.buttonUnpatchControllers.MouseHover += new System.EventHandler(this.buttonBackground_MouseHover);
			// 
			// checkBoxReverseOutputOrder
			// 
			this.checkBoxReverseOutputOrder.AutoSize = true;
			this.checkBoxReverseOutputOrder.Location = new System.Drawing.Point(12, 65);
			this.checkBoxReverseOutputOrder.Name = "checkBoxReverseOutputOrder";
			this.checkBoxReverseOutputOrder.Size = new System.Drawing.Size(186, 17);
			this.checkBoxReverseOutputOrder.TabIndex = 29;
			this.checkBoxReverseOutputOrder.Text = "Reverse order of selected outputs";
			this.checkBoxReverseOutputOrder.UseVisualStyleBackColor = true;
			this.checkBoxReverseOutputOrder.CheckedChanged += new System.EventHandler(this.checkBoxReverseOutputOrder_CheckedChanged);
			// 
			// groupBoxElementOptions
			// 
			this.groupBoxElementOptions.AutoSize = true;
			this.groupBoxElementOptions.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.groupBoxElementOptions.Controls.Add(this.checkBoxReverseElementOrder);
			this.groupBoxElementOptions.Controls.Add(this.radioButtonAllAvailablePatchPoints);
			this.groupBoxElementOptions.Controls.Add(this.radioButtonUnconnectedPatchPointsOnly);
			this.groupBoxElementOptions.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBoxElementOptions.Location = new System.Drawing.Point(3, 240);
			this.groupBoxElementOptions.Name = "groupBoxElementOptions";
			this.groupBoxElementOptions.Size = new System.Drawing.Size(220, 101);
			this.groupBoxElementOptions.TabIndex = 1;
			this.groupBoxElementOptions.TabStop = false;
			this.groupBoxElementOptions.Text = "Element Patching Options";
			this.groupBoxElementOptions.Paint += new System.Windows.Forms.PaintEventHandler(this.groupBoxes_Paint);
			// 
			// radioButtonAllAvailablePatchPoints
			// 
			this.radioButtonAllAvailablePatchPoints.AutoSize = true;
			this.radioButtonAllAvailablePatchPoints.Location = new System.Drawing.Point(8, 42);
			this.radioButtonAllAvailablePatchPoints.Name = "radioButtonAllAvailablePatchPoints";
			this.radioButtonAllAvailablePatchPoints.Size = new System.Drawing.Size(163, 17);
			this.radioButtonAllAvailablePatchPoints.TabIndex = 1;
			this.radioButtonAllAvailablePatchPoints.Text = "Use all available patch points";
			this.radioButtonAllAvailablePatchPoints.UseVisualStyleBackColor = true;
			this.radioButtonAllAvailablePatchPoints.CheckedChanged += new System.EventHandler(this.radioButtonPatching_CheckedChanged);
			// 
			// radioButtonUnconnectedPatchPointsOnly
			// 
			this.radioButtonUnconnectedPatchPointsOnly.AutoSize = true;
			this.radioButtonUnconnectedPatchPointsOnly.Checked = true;
			this.radioButtonUnconnectedPatchPointsOnly.Location = new System.Drawing.Point(8, 19);
			this.radioButtonUnconnectedPatchPointsOnly.Name = "radioButtonUnconnectedPatchPointsOnly";
			this.radioButtonUnconnectedPatchPointsOnly.Size = new System.Drawing.Size(193, 17);
			this.radioButtonUnconnectedPatchPointsOnly.TabIndex = 0;
			this.radioButtonUnconnectedPatchPointsOnly.TabStop = true;
			this.radioButtonUnconnectedPatchPointsOnly.Text = "Use unconnected patch points only";
			this.radioButtonUnconnectedPatchPointsOnly.UseVisualStyleBackColor = true;
			this.radioButtonUnconnectedPatchPointsOnly.CheckedChanged += new System.EventHandler(this.radioButtonPatching_CheckedChanged);
			// 
			// groupBoxOutputOptions
			// 
			this.groupBoxOutputOptions.AutoSize = true;
			this.groupBoxOutputOptions.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.groupBoxOutputOptions.Controls.Add(this.radioButtonAllOutputs);
			this.groupBoxOutputOptions.Controls.Add(this.radioButtonUnpatchedOutputsOnly);
			this.groupBoxOutputOptions.Controls.Add(this.checkBoxReverseOutputOrder);
			this.groupBoxOutputOptions.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBoxOutputOptions.Location = new System.Drawing.Point(229, 240);
			this.groupBoxOutputOptions.Name = "groupBoxOutputOptions";
			this.groupBoxOutputOptions.Size = new System.Drawing.Size(204, 101);
			this.groupBoxOutputOptions.TabIndex = 2;
			this.groupBoxOutputOptions.TabStop = false;
			this.groupBoxOutputOptions.Text = "Controller Patching Options";
			this.groupBoxOutputOptions.Paint += new System.Windows.Forms.PaintEventHandler(this.groupBoxes_Paint);
			// 
			// radioButtonAllOutputs
			// 
			this.radioButtonAllOutputs.AutoSize = true;
			this.radioButtonAllOutputs.Location = new System.Drawing.Point(12, 42);
			this.radioButtonAllOutputs.Name = "radioButtonAllOutputs";
			this.radioButtonAllOutputs.Size = new System.Drawing.Size(184, 17);
			this.radioButtonAllOutputs.TabIndex = 3;
			this.radioButtonAllOutputs.Text = "Use all selected controller outputs";
			this.radioButtonAllOutputs.UseVisualStyleBackColor = true;
			this.radioButtonAllOutputs.CheckedChanged += new System.EventHandler(this.radioButtonPatching_CheckedChanged);
			// 
			// radioButtonUnpatchedOutputsOnly
			// 
			this.radioButtonUnpatchedOutputsOnly.AutoSize = true;
			this.radioButtonUnpatchedOutputsOnly.Checked = true;
			this.radioButtonUnpatchedOutputsOnly.Location = new System.Drawing.Point(12, 19);
			this.radioButtonUnpatchedOutputsOnly.Name = "radioButtonUnpatchedOutputsOnly";
			this.radioButtonUnpatchedOutputsOnly.Size = new System.Drawing.Size(158, 17);
			this.radioButtonUnpatchedOutputsOnly.TabIndex = 2;
			this.radioButtonUnpatchedOutputsOnly.TabStop = true;
			this.radioButtonUnpatchedOutputsOnly.Text = "Only use unpatched outputs";
			this.radioButtonUnpatchedOutputsOnly.UseVisualStyleBackColor = true;
			this.radioButtonUnpatchedOutputsOnly.CheckedChanged += new System.EventHandler(this.radioButtonPatching_CheckedChanged);
			// 
			// toolTip1
			// 
			this.toolTip1.AutomaticDelay = 200;
			this.toolTip1.AutoPopDelay = 5000;
			this.toolTip1.InitialDelay = 200;
			this.toolTip1.ReshowDelay = 40;
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.AutoSize = true;
			this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.tableLayoutPanel1.ColumnCount = 2;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.Controls.Add(this.labelPatchWarning, 0, 3);
			this.tableLayoutPanel1.Controls.Add(this.buttonDoPatching, 0, 5);
			this.tableLayoutPanel1.Controls.Add(this.labelPatchSummary, 0, 2);
			this.tableLayoutPanel1.Controls.Add(this.groupBoxOutputOptions, 1, 1);
			this.tableLayoutPanel1.Controls.Add(this.groupBoxElements, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.groupBoxControllers, 1, 0);
			this.tableLayoutPanel1.Controls.Add(this.groupBoxElementOptions, 0, 1);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 7;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(436, 480);
			this.tableLayoutPanel1.TabIndex = 34;
			// 
			// buttonDoPatching
			// 
			this.buttonDoPatching.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.buttonDoPatching.AutoSize = true;
			this.tableLayoutPanel1.SetColumnSpan(this.buttonDoPatching, 2);
			this.buttonDoPatching.Location = new System.Drawing.Point(132, 407);
			this.buttonDoPatching.Name = "buttonDoPatching";
			this.buttonDoPatching.Size = new System.Drawing.Size(171, 32);
			this.buttonDoPatching.TabIndex = 0;
			this.buttonDoPatching.Text = "Patch Elements";
			this.buttonDoPatching.UseVisualStyleBackColor = true;
			this.buttonDoPatching.Click += new System.EventHandler(this.buttonDoPatching_Click);
			this.buttonDoPatching.MouseLeave += new System.EventHandler(this.buttonBackground_MouseLeave);
			this.buttonDoPatching.MouseHover += new System.EventHandler(this.buttonBackground_MouseHover);
			// 
			// labelPatchSummary
			// 
			this.labelPatchSummary.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.labelPatchSummary.AutoSize = true;
			this.tableLayoutPanel1.SetColumnSpan(this.labelPatchSummary, 2);
			this.labelPatchSummary.Location = new System.Drawing.Point(69, 347);
			this.labelPatchSummary.Name = "labelPatchSummary";
			this.labelPatchSummary.Size = new System.Drawing.Size(298, 13);
			this.labelPatchSummary.TabIndex = 3;
			this.labelPatchSummary.Text = "This will patch 9999 element points to 9999 controller outputs.";
			this.labelPatchSummary.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// tableLayoutControllerInfo
			// 
			this.tableLayoutControllerInfo.AutoSize = true;
			this.tableLayoutControllerInfo.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.tableLayoutControllerInfo.ColumnCount = 2;
			this.tableLayoutControllerInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutControllerInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutControllerInfo.Controls.Add(this.labelLastOutput, 1, 8);
			this.tableLayoutControllerInfo.Controls.Add(this.buttonUnpatchControllers, 0, 9);
			this.tableLayoutControllerInfo.Controls.Add(this.label20, 0, 1);
			this.tableLayoutControllerInfo.Controls.Add(this.label9, 0, 8);
			this.tableLayoutControllerInfo.Controls.Add(this.labelFirstOutput, 1, 7);
			this.tableLayoutControllerInfo.Controls.Add(this.label16, 0, 2);
			this.tableLayoutControllerInfo.Controls.Add(this.label15, 0, 3);
			this.tableLayoutControllerInfo.Controls.Add(this.label8, 0, 7);
			this.tableLayoutControllerInfo.Controls.Add(this.labelOutputCount, 1, 1);
			this.tableLayoutControllerInfo.Controls.Add(this.labelPatchedOutputCount, 1, 2);
			this.tableLayoutControllerInfo.Controls.Add(this.labelUnpatchedOutputCount, 1, 3);
			this.tableLayoutControllerInfo.Controls.Add(this.label21, 0, 5);
			this.tableLayoutControllerInfo.Controls.Add(this.labelControllerCount, 1, 5);
			this.tableLayoutControllerInfo.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutControllerInfo.Location = new System.Drawing.Point(3, 16);
			this.tableLayoutControllerInfo.Name = "tableLayoutControllerInfo";
			this.tableLayoutControllerInfo.RowCount = 11;
			this.tableLayoutControllerInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.tableLayoutControllerInfo.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutControllerInfo.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutControllerInfo.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutControllerInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15F));
			this.tableLayoutControllerInfo.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutControllerInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15F));
			this.tableLayoutControllerInfo.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutControllerInfo.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutControllerInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutControllerInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.tableLayoutControllerInfo.Size = new System.Drawing.Size(198, 212);
			this.tableLayoutControllerInfo.TabIndex = 29;
			// 
			// tableLayoutElementInfo
			// 
			this.tableLayoutElementInfo.AutoSize = true;
			this.tableLayoutElementInfo.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.tableLayoutElementInfo.ColumnCount = 2;
			this.tableLayoutElementInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutElementInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutElementInfo.Controls.Add(this.buttonUnpatchElements, 0, 9);
			this.tableLayoutElementInfo.Controls.Add(this.label4, 0, 8);
			this.tableLayoutElementInfo.Controls.Add(this.label3, 0, 7);
			this.tableLayoutElementInfo.Controls.Add(this.label2, 0, 6);
			this.tableLayoutElementInfo.Controls.Add(this.label1, 0, 5);
			this.tableLayoutElementInfo.Controls.Add(this.labelFilterCount, 1, 8);
			this.tableLayoutElementInfo.Controls.Add(this.labelElementCount, 1, 7);
			this.tableLayoutElementInfo.Controls.Add(this.labelGroupCount, 1, 6);
			this.tableLayoutElementInfo.Controls.Add(this.labelItemCount, 1, 5);
			this.tableLayoutElementInfo.Controls.Add(this.label7, 0, 3);
			this.tableLayoutElementInfo.Controls.Add(this.labelUnconnectedPatchPointCount, 1, 3);
			this.tableLayoutElementInfo.Controls.Add(this.label6, 0, 2);
			this.tableLayoutElementInfo.Controls.Add(this.labelConnectedPatchPointCount, 1, 2);
			this.tableLayoutElementInfo.Controls.Add(this.label5, 0, 1);
			this.tableLayoutElementInfo.Controls.Add(this.labelPatchPointCount, 1, 1);
			this.tableLayoutElementInfo.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutElementInfo.Location = new System.Drawing.Point(3, 16);
			this.tableLayoutElementInfo.Margin = new System.Windows.Forms.Padding(5, 3, 3, 0);
			this.tableLayoutElementInfo.Name = "tableLayoutElementInfo";
			this.tableLayoutElementInfo.RowCount = 11;
			this.tableLayoutElementInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.tableLayoutElementInfo.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutElementInfo.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutElementInfo.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutElementInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15F));
			this.tableLayoutElementInfo.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutElementInfo.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutElementInfo.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutElementInfo.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutElementInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutElementInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.tableLayoutElementInfo.Size = new System.Drawing.Size(214, 212);
			this.tableLayoutElementInfo.TabIndex = 35;
			// 
			// labelPatchWarning
			// 
			this.labelPatchWarning.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.labelPatchWarning.AutoSize = true;
			this.tableLayoutPanel1.SetColumnSpan(this.labelPatchWarning, 2);
			this.labelPatchWarning.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(255)))));
			this.labelPatchWarning.Location = new System.Drawing.Point(79, 367);
			this.labelPatchWarning.Name = "labelPatchWarning";
			this.labelPatchWarning.Size = new System.Drawing.Size(277, 13);
			this.labelPatchWarning.TabIndex = 4;
			this.labelPatchWarning.Text = "WARNING: too many elements, some will not be patched";
			this.labelPatchWarning.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// SetupPatchingSimple
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.AutoSize = true;
			this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.Controls.Add(this.tableLayoutPanel1);
			this.DoubleBuffered = true;
			this.MinimumSize = new System.Drawing.Size(420, 480);
			this.Name = "SetupPatchingSimple";
			this.Size = new System.Drawing.Size(436, 480);
			this.Load += new System.EventHandler(this.SetupPatchingSimple_Load);
			this.groupBoxElements.ResumeLayout(false);
			this.groupBoxElements.PerformLayout();
			this.groupBoxControllers.ResumeLayout(false);
			this.groupBoxControllers.PerformLayout();
			this.groupBoxElementOptions.ResumeLayout(false);
			this.groupBoxElementOptions.PerformLayout();
			this.groupBoxOutputOptions.ResumeLayout(false);
			this.groupBoxOutputOptions.PerformLayout();
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.tableLayoutControllerInfo.ResumeLayout(false);
			this.tableLayoutControllerInfo.PerformLayout();
			this.tableLayoutElementInfo.ResumeLayout(false);
			this.tableLayoutElementInfo.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private GroupBox groupBoxElements;
		private Label labelUnconnectedPatchPointCount;
		private Label labelConnectedPatchPointCount;
		private Label labelPatchPointCount;
		private Label label7;
		private Label label6;
		private Label label5;
		private GroupBox groupBoxControllers;
		private Label labelUnpatchedOutputCount;
		private Label labelPatchedOutputCount;
		private Label labelOutputCount;
		private Label labelControllerCount;
		private Label label15;
		private Label label16;
		private Label label20;
		private Label label21;
		private Label labelFilterCount;
		private Label labelElementCount;
		private Label labelGroupCount;
		private Label labelItemCount;
		private Label label4;
		private Label label3;
		private Label label2;
		private Label label1;
		private GroupBox groupBoxOutputOptions;
		private RadioButton radioButtonAllOutputs;
		private RadioButton radioButtonUnpatchedOutputsOnly;
		private GroupBox groupBoxElementOptions;
		private RadioButton radioButtonAllAvailablePatchPoints;
		private RadioButton radioButtonUnconnectedPatchPointsOnly;
		private ToolTip toolTip1;
		private Button buttonUnpatchElements;
		private Button buttonUnpatchControllers;
		private CheckBox checkBoxReverseOutputOrder;
		private Label labelLastOutput;
		private Label labelFirstOutput;
		private Label label9;
		private Label label8;
		private TableLayoutPanel tableLayoutPanel1;
		private CheckBox checkBoxReverseElementOrder;
		private Panel panel1;
		private Panel panel2;
		private Button buttonDoPatching;
		private Label labelPatchSummary;
		private TableLayoutPanel tableLayoutElementInfo;
		private TableLayoutPanel tableLayoutControllerInfo;
		private Label labelPatchWarning;
	}
}
