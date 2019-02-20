﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Vixen.Sys.Managers
{
	public class NodeManager : NodeManagerBase<ElementNode>, IEnumerable<ElementNode>
	{
		// a mapping of element node GUIDs to element node instances. Used for initial creation, to easily find nodes we have already created.
		// once they've been created, they're in the dictionary. The only way to 'delete' elementNodes is to make a new NodeManager,
		// which reinitializes this mapping and we can start fresh.
		private Dictionary<Guid, ElementNode> _instances;

		public static event EventHandler NodesChanged;

		public NodeManager()
		{
			_instances = new Dictionary<Guid, ElementNode>();
			ElementNode.Changed += ElementNode_Changed;
		}

		public NodeManager(IEnumerable<ElementNode> nodes)
			: this()
		{
			AddNodes(nodes);
		}

		private void ElementNode_Changed(object sender, EventArgs e)
		{
			OnNodesChanged();
		}

		public void MoveNode(ElementNode movingNode, ElementNode newParent, ElementNode oldParent, int index = -1)
		{
			// if null nodes, default to the root node.
			newParent = newParent ?? RootNode;
			oldParent = oldParent ?? RootNode;

			// if we are going to be moving a node within its same group, but to a later position, we need to offset
			// the destination index by 1: once we remove a node, everything shuffles up one, and we need to account for it
			if (oldParent == newParent && index >= 0 && index > newParent.IndexOfChild(movingNode)) {
				index--;
			}

			// remove the node from its old parent, not culling any floating children (since it's about to be added
			// again somewhere else) and then move it to the new parent, in the desired position if set
			RemoveNode(movingNode, oldParent, false);
			AddChildToParent(movingNode, newParent, index);
		}

		public void RemoveNode(ElementNode node, ElementNode parent, bool cleanup)
		{
			// if the given parent is null, it's most likely a root node (ie. with
			// a parent of our private RootNode). Try to remove it from that instead.
			if (parent == null) {
				node.RemoveFromParent(RootNode, cleanup);
			}
			else {
				node.RemoveFromParent(parent, cleanup);
				//If the parent no longer has children, add a element back to it.
				if (parent.IsLeaf && parent.Element == null)
				{
					parent.Element = new Element(parent.Name);
					VixenSystem.Elements.AddElement(parent.Element);
				}
			}

		}

		public void RenameNode(ElementNode node, string newName)
		{
			node.Name = _Uniquify(newName);
			if (node.Element != null)
				node.Element.Name = node.Name;
		}

		public override void AddChildToParent(ElementNode child, ElementNode parent, int index = -1)
		{
			// if no parent was specified, add to the root node.
			if (parent == null)
				parent = RootNode;

			// if an item is a group (or is becoming one), it can't have an output
			// element anymore. Remove it.
			if (parent.Element != null) {
				VixenSystem.Elements.RemoveElement(parent.Element);
				parent.Element = null;
			}

			// if an index was specified, insert it in that position, otherwise just add it at the end
			if (index < 0)
				parent.AddChild(child);
			else
				parent.InsertChild(index, child);
		}

		/// <inheritdoc />
		protected override ElementNode CreateNode(string name)
		{
			return new ElementNode(name);
		}

		public IEnumerable<ElementNode> InvalidRootNodes
		{
			get { return RootNode.InvalidChildren(); }
		}

		protected virtual void OnNodesChanged()
		{
			if (NodesChanged != null) {
				NodesChanged(this, EventArgs.Empty);
			}
		}

		public IEnumerable<ElementNode> GetLeafNodes()
		{
			// Don't want to return the root node.
			// note: this may very well return duplicate nodes, if they are part of different groups.
			return RootNode.Children.SelectMany(x => x.GetLeafEnumerator());
		}

		public IEnumerable<ElementNode> GetNonLeafNodes()
		{
			// Don't want to return the root node.
			// note: this may very well return duplicate nodes, if they are part of different groups.
			return RootNode.Children.SelectMany(x => x.GetNonLeafEnumerator());
		}

		public IEnumerable<ElementNode> GetRootNodes()
		{
			return RootNode.Children;
		}

		public IEnumerable<ElementNode> GetAllNodes()
		{
			//return RootNode.Children.SelectMany(x => x.GetNodeEnumerator());
			return _instances.Values;
		}

		public IEnumerator<ElementNode> GetEnumerator()
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