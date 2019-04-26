using System;

namespace Vixen.Attributes
{
	/// <summary>
	///     Controls Ignorable state of the property without having access to property declaration or inherited property.
	///     Supports a "*" (All) wildcard determining whether all the properties within the given class should be Ignored.
	/// </summary>
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Interface, AllowMultiple = true)]
	public sealed class IgnorePropertyAttribute : Attribute
	{
		/// <summary>
		///     Determines a wildcard for all properties to be affected.
		/// </summary>
		public const string All = "*";

		/// <summary>
		///     Initializes a new instance of the <see cref="IgnorePropertyAttribute" /> class.
		/// </summary>
		/// <param name="propertyName">Name of the property.</param>
		/// <param name="ignore">if set to <c>true</c> the property is browsable.</param>
		public IgnorePropertyAttribute(string propertyName, bool ignore)
		{
			PropertyName = string.IsNullOrEmpty(propertyName) ? All : propertyName;
			Ignore = ignore;
		}

		/// <summary>
		///     Initializes a new instance of the <see cref="IgnorePropertyAttribute" /> class.
		/// </summary>
		/// <param name="propertyName">Name of the property.</param>
		public IgnorePropertyAttribute(string propertyName) : this(propertyName, true)
		{
		}

		/// <summary>
		///     Initializes a new instance of the <see cref="IgnorePropertyAttribute" /> class.
		/// </summary>
		/// <param name="ignore">if set to <c>true</c> all public properties are ignored; otherwise available.</param>
		public IgnorePropertyAttribute(bool ignore) : this(All, ignore)
		{
		}

		/// <summary>
		///     Gets the name of the property.
		/// </summary>
		/// <value>The name of the property.</value>
		public string PropertyName { get; private set; }

		/// <summary>
		///     Gets or sets a value indicating whether property is ignored.
		/// </summary>
		/// <value><c>true</c> if property should be ignored at run time; otherwise, <c>false</c>.</value>
		public bool Ignore { get; private set; }
	}
}