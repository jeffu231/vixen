using System;
using System.Collections.Generic;
using System.Linq;

namespace Vixen.Sys
{
	public class VirtualElementNode : GroupNode<Element>, IElementNode, IEqualityComparer<VirtualElementNode>
	{

		internal VirtualElementNode(Guid id, string name, Element element, IEnumerable<VirtualElementNode> content)
			: base(name, content)
		{
			
			Id = id;
			if (element != null)
			{
				//Ensure the element name matches the ElementNode name as there is some code that expects that.
				element.Name = name;
			}
			Element = element;
			Properties = new PropertyManager(this);
		}

		internal VirtualElementNode(string name, Element element, IEnumerable<VirtualElementNode> content)
			: this(Guid.NewGuid(), name, element, content)
		{
		}

		internal VirtualElementNode(string name, IEnumerable<VirtualElementNode> content)
			: this(name, null, content)
		{
		}

		#region Implementation of IElementNode

		/// <inheritdoc />
		public Element Element { get; set; }

		/// <inheritdoc />
		public Guid Id { get; }

		public new IEnumerable<VirtualElementNode> Children => base.Children.Cast<VirtualElementNode>();

		/// <inheritdoc />
		IEnumerable<IElementNode> IElementNode.Children => Children;

		public new IEnumerable<VirtualElementNode> Parents => base.Parents.Cast<VirtualElementNode>();

		/// <inheritdoc />
		IEnumerable<IElementNode> IElementNode.Parents => Parents;

		/// <inheritdoc />
		public bool IsLeaf => !base.Children.Any();

		/// <inheritdoc />
		public int GetMaxChildDepth()
		{
			return GetDepth(this);
		}

		/// <inheritdoc />
		public IEnumerable<IElementNode> GetLeafEnumerator()
		{
			if (IsLeaf)
			{
				// Element is already an enumerable, so AsEnumerable<> won't work.
				return (new[] { this });
			}

			return Children.SelectMany(x => x.GetLeafEnumerator());
		}

		/// <inheritdoc />
		public IEnumerable<Element> GetElementEnumerator()
		{
			if (IsLeaf)
			{
				// Element is already an enumerable, so AsEnumerable<> won't work.
				return (new[] { Element });
			}

			return Children.SelectMany(x => x.GetElementEnumerator());
		}

		/// <inheritdoc />
		public IEnumerable<IElementNode> GetNodeEnumerator()
		{
			// "this" is already an enumerable, so AsEnumerable<> won't work.
			return (new[] { this }).Concat(Children.SelectMany(x => x.GetNodeEnumerator()));
		}

		/// <inheritdoc />
		public IEnumerable<IElementNode> GetNonLeafEnumerator()
		{
			if (IsLeaf)
			{
				return Enumerable.Empty<VirtualElementNode>();
			}

			// "this" is already an enumerable, so AsEnumerable<> won't work.
			return (new[] { this }).Concat(Children.SelectMany(x => x.GetNonLeafEnumerator()));
		}

		/// <inheritdoc />
		public PropertyManager Properties { get; }

		#endregion

		#region Implementation of IEqualityComparer<in VirtualElementNode>

		/// <inheritdoc />
		public bool Equals(VirtualElementNode x, VirtualElementNode y)
		{
			return x.Id == y.Id;
		}

		/// <inheritdoc />
		public int GetHashCode(VirtualElementNode obj)
		{
			return Id.GetHashCode();
		}

		#endregion

		private int GetDepth(IElementNode node)
		{
			if (node.IsLeaf)
			{
				return 1;
			}
			var subLevel = node.Children.Select(GetDepth);
			return !subLevel.Any() ? 1 : subLevel.Max() + 1;
		}
	}
}
