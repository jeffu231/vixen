using System;
using System.Collections.Generic;
using System.Linq;

namespace Vixen.Sys.Managers
{
	public class VirtualNodeManager : NodeManagerBase<VirtualElementNode>, IEnumerable<VirtualElementNode>
	{
		public static event EventHandler NodesChanged;

		public VirtualNodeManager(IEnumerable<VirtualElementNode> nodes)
		{
			AddNodes(nodes);
		}

		/// <inheritdoc />
		protected override VirtualElementNode CreateNode(string name)
		{
			return new VirtualElementNode("Root");
		}

		public void MoveNode(VirtualElementNode movingNode, VirtualElementNode newParent, VirtualElementNode oldParent, int index = -1)
		{
			// if null nodes, default to the root node.
			newParent = newParent ?? RootNode;
			oldParent = oldParent ?? RootNode;

			// if we are going to be moving a node within its same group, but to a later position, we need to offset
			// the destination index by 1: once we remove a node, everything shuffles up one, and we need to account for it
			if (oldParent == newParent && index >= 0 && index > newParent.IndexOfChild(movingNode))
			{
				index--;
			}

			// remove the node from its old parent, not culling any floating children (since it's about to be added
			// again somewhere else) and then move it to the new parent, in the desired position if set
			RemoveNode(movingNode, oldParent, false);
			AddChildToParent(movingNode, newParent, index);
		}

		public void RemoveNode(VirtualElementNode node, VirtualElementNode parent, bool cleanup)
		{
			// if the given parent is null, it's most likely a root node (ie. with
			// a parent of our private RootNode). Try to remove it from that instead.
			if (parent == null)
			{
				node.RemoveFromParent(RootNode, cleanup);
			}
			else
			{
				node.RemoveFromParent(parent, cleanup);
				//If the parent no longer has children, add a element back to it.
				if (parent.IsLeaf && parent.Element == null)
				{
					parent.Element = new Element(parent.Name);
					//VixenSystem.Elements.AddElement(parent.Element);
				}
			}

		}

		public void RenameNode(VirtualElementNode node, string newName)
		{
			node.Name = _Uniquify(newName);
			if (node.Element != null)
				node.Element.Name = node.Name;
		}

		public override void AddChildToParent(VirtualElementNode child, VirtualElementNode parent, int index = -1)
		{
			// if no parent was specified, add to the root node.
			if (parent == null)
				parent = RootNode;

			// if an item is a group (or is becoming one), it can't have an output
			// element anymore. Remove it.
			if (parent.Element != null)
			{
				//VixenSystem.Elements.RemoveElement(parent.Element);
				parent.Element = null;
			}

			// if an index was specified, insert it in that position, otherwise just add it at the end
			if (index < 0)
				parent.AddChild(child);
			else
				parent.InsertChild(index, child);
		}

		//public IEnumerable<VirtualElementNode> InvalidRootNodes
		//{
		//	get { return RootNode.InvalidChildren(); }
		//}

		protected virtual void OnNodesChanged()
		{
			if (NodesChanged != null)
			{
				NodesChanged(this, EventArgs.Empty);
			}
		}

		public IEnumerable<IElementNode> GetLeafNodes()
		{
			// Don't want to return the root node.
			// note: this may very well return duplicate nodes, if they are part of different groups.
			return RootNode.Children.SelectMany(x => x.GetLeafEnumerator());
		}

		public IEnumerable<IElementNode> GetNonLeafNodes()
		{
			// Don't want to return the root node.
			// note: this may very well return duplicate nodes, if they are part of different groups.
			return RootNode.Children.SelectMany(x => x.GetNonLeafEnumerator());
		}

		public IEnumerable<VirtualElementNode> GetRootNodes()
		{
			return RootNode.Children;
		}

		public IEnumerable<VirtualElementNode> GetAllNodes()
		{
			//return RootNode.Children.SelectMany(x => x.GetNodeEnumerator());
			return _instances.Values;
		}

		public IEnumerator<VirtualElementNode> GetEnumerator()
		{
			// Don't want to return the root node.
			return GetAllNodes().GetEnumerator();
		}

		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}
}