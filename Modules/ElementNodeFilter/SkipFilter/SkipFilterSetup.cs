using System;
using System.Windows.Forms;
using Common.Controls;
using Common.Controls.Theme;
using Common.Resources.Properties;

namespace VixenModules.ElementNodeFilter.SkipFilter
{
	public partial class SkipFilterSetup : BaseForm
	{
		public SkipFilterSetup(int first, int skip, int take, bool takeBeforeSkip)
		{
			InitializeComponent();
			ThemeUpdateControls.UpdateControls(this);
			numericUpDownFirstN.Value = first;
			numericUpDownSkipN.Value = skip;
			numericUpDownTakeN.Value = take;
			radioButtonUseFirst.Checked = takeBeforeSkip;
		}

		public int First => (int)numericUpDownFirstN.Value;

		public int Skip => (int)numericUpDownSkipN.Value;

		public int Take => (int) numericUpDownTakeN.Value;

		public bool TakeBeforeSkip => radioButtonUseFirst.Checked;

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
