using System;
using System.Windows.Forms;
using Common.Controls;
using Common.Controls.Theme;
using Common.Resources.Properties;

namespace VixenModules.ElementNodeFilter.SkipFilter
{
	public partial class SkipFilterSetup : BaseForm
	{
		public SkipFilterSetup(int skip)
		{
			InitializeComponent();
			ThemeUpdateControls.UpdateControls(this);
			numericUpDownSkip.Minimum = 1;
			numericUpDownSkip.Maximum = 100;
			numericUpDownSkip.Increment = 1;
			numericUpDownSkip.DecimalPlaces = 0;
			numericUpDownSkip.Value = skip;
		}

		public int Skip => (int)numericUpDownSkip.Value;

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
