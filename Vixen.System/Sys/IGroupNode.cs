using System.Collections.Generic;

namespace Vixen.Sys
{
	public interface IGroupNode<T> : IEnumerable<T>
	{
		string Name { get; set; }

		void AddChild(IGroupNode<T> node);

		bool RemoveChild(IGroupNode<T> node);

		void AddParent(IGroupNode<T> parent);

		bool RemoveParent(IGroupNode<T> parent);

		bool RemoveFromParent(IGroupNode<T> parent, bool cleanupIfFloating);

		bool ContainsNode(IGroupNode<T> node);
	}
}
