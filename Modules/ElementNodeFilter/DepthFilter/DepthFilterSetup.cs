using System;
using System.Windows.Forms;
using Common.Controls;
using Common.Controls.Theme;
using Common.Resources.Properties;

namespace VixenModules.ElementNodeFilter.DepthFilter
{
	public partial class DepthFilterSetup : BaseForm
	{
		public DepthFilterSetup(int depth)
		{
			InitializeComponent();
			ThemeUpdateControls.UpdateControls(this);
			numericUpDownDepth.Value = depth;
		}

		public int Depth => (int)numericUpDownDepth.Value;

		#region Theme Events

		private void buttonBackground_MouseHover(object sender, EventArgs e)
		{
			var btn = (Button)sender;
			btn.BackgroundImage = Resources.ButtonBackgroundImageHover;
		}

		private void buttonBackground_MouseLeave(object sender, EventArgs e)
		{
			var btn = (Button)sender;
			btn.BackgroundImage = Resources.ButtonBackgroundImage;

		}

		#endregion

	}
}
