using System;
using System.Collections.Generic;
using System.Linq;

namespace Vixen.Sys
{
	public class GroupingElementNode : GroupNode<Element>, IElementNode, IEqualityComparer<IElementNode>
	{
		/// <inheritdoc />
		public GroupingElementNode(string name, IEnumerable<IGroupNode<Element>> content) : base(name, content)
		{
			Id = Guid.NewGuid();
			Properties = new PropertyManager(this);
		}

		/// <inheritdoc />
		public GroupingElementNode(string name, params IGroupNode<Element>[] content) : this(name, content as IEnumerable<IElementNode>)
		{
		}

		#region Implementation of IElementNode

		/// <inheritdoc />
		public Element Element { get; set; }

		/// <inheritdoc />
		public Guid Id { get; }

		/// <inheritdoc />
		public new IEnumerable<IElementNode> Children => base.Children.Cast<IElementNode>();

		/// <inheritdoc />
		public new IEnumerable<IElementNode> Parents => base.Parents.Cast<IElementNode>();

		/// <inheritdoc />
		public bool IsLeaf => false;

		/// <inheritdoc />
		public int GetMaxChildDepth()
		{
			return GetDepth(this);
		}

		/// <inheritdoc />
		public IEnumerable<IElementNode> GetLeafEnumerator()
		{
			return Children.SelectMany(x => x.GetLeafEnumerator());
		}

		/// <inheritdoc />
		public IEnumerable<Element> GetElementEnumerator()
		{
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
			// "this" is already an enumerable, so AsEnumerable<> won't work.
			return (new[] { this }).Concat(Children.SelectMany(x => x.GetNonLeafEnumerator()));
		}

		/// <inheritdoc />
		public PropertyManager Properties { get; }

		#endregion

		#region Implementation of IEqualityComparer<in IElementNode>

		/// <inheritdoc />
		public bool Equals(IElementNode x, IElementNode y)
		{
			return x.Id == y.Id;
		}

		/// <inheritdoc />
		public int GetHashCode(IElementNode obj)
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
