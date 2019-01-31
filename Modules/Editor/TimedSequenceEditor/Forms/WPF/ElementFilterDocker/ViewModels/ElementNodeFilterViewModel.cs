using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Catel.Data;
using Catel.MVVM;
using Vixen.Sys.ElementNodeFilters;

namespace VixenModules.Editor.TimedSequenceEditor.Forms.WPF.ElementFilterDocker.ViewModels
{
	public class ElementNodeFilterViewModel : ViewModelBase
	{
		#region Filter model property

		/// <summary>
		/// Gets or sets the Filter value.
		/// </summary>
		[Model]
		public IChainableElementNodeFilter Filter
		{
			get { return GetValue<IChainableElementNodeFilter>(FilterProperty); }
			private set { SetValue(FilterProperty, value); }
		}

		/// <summary>
		/// Filter property data.
		/// </summary>
		public static readonly PropertyData FilterProperty = RegisterProperty("Filter", typeof(IChainableElementNodeFilter));

		#endregion
	}
}
