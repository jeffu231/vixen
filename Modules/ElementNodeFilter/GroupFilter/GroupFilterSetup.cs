using System;
using System.Windows.Forms;
using Common.Controls;
using Common.Controls.Theme;
using Common.Resources.Properties;

namespace VixenModules.ElementNodeFilter.GroupFilter
{
	public partial class GroupFilterSetup : BaseForm
	{
		public GroupFilterSetup(bool singleGroup, int elementsPerGroup)
		{
			InitializeComponent();
			ThemeUpdateControls.UpdateControls(this);
			numericUpDownElementsPerGroup.Value = elementsPerGroup>0?elementsPerGroup:1;
			chkSingleGroup.Checked = singleGroup;
		}

		public bool SingleGroup => chkSingleGroup.Checked;

		public int ElementsPerGroup => (int)numericUpDownElementsPerGroup.Value;

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
