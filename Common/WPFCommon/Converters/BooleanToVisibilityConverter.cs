using System.Windows;

namespace Common.WPFCommon.Converters
{
	public sealed class BooleanToVisibilityConverter : BooleanConverter<Visibility>
	{
		public BooleanToVisibilityConverter() :
			base(Visibility.Visible, Visibility.Collapsed)
		{ }
	}
}
