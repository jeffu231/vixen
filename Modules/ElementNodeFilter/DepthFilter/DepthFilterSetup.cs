using System;
using System.Linq;
using System.Windows.Forms;
using Common.Controls;
using Common.Controls.Theme;
using Common.Resources.Properties;
using Vixen.Sys;

namespace VixenModules.ElementNodeFilter.DepthFilter
{
	public partial class DepthFilterSetup : BaseForm
	{
		public DepthFilterSetup(int depth)
		{
			InitializeComponent();
			ThemeUpdateControls.UpdateControls(this);
			trkDepth.Minimum = 0;
			trkDepth.Maximum = 10;
			trkDepth.Value = depth;
		}

		public int Depth => trkDepth.Value;

		//private int DetermineDepth()
		//{
		//	var depth = 0;
		//	var node = _nodes.FirstOrDefault();
		//	if (node != null)
		//	{
		//		depth = node.GetMaxChildDepth();
		//	}

		//	return depth;
		//}

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
