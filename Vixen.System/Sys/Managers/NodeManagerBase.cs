using System;
using System.Collections.Generic;
using System.Linq;

namespace Vixen.Sys.Managers
{
	public abstract class NodeManagerBase<T> where T : IElementNode
	{
		// a mapping of element node GUIDs to element node instances. Used for initial creation, to easily find nodes we have already created.
		// once they've been created, they're in the dictionary. The only way to 'delete' elementNodes is to make a new NodeManager,
		// which reinitializes this mapping and we can start fresh.
		protected Dictionary<Guid, T> _instances;
		protected T _rootNode;

		protected NodeManagerBase()
		{
			_instances = new Dictionary<Guid, T>();
		}

		public T RootNode
		{
			get
			{
				if (_rootNode == null)
					_rootNode = CreateNode("Root");

				return _rootNode;
			}
		}

		protected abstract T CreateNode(string name);

		protected string _Uniquify(string name)
		{
			if (_instances.Values.Any(x => x.Name == name))
			{
				string originalName = name;
				bool unique;
				int counter = 2;
				do
				{
					name = $"{originalName} - {counter++}";
					unique = _instances.Values.All(x => x.Name != name);
				} while (!unique);
			}

			return name;
		}

		public void AddNode(T node, T parent = default(T))
		{
			AddChildToParent(node, parent);
		}

		public void AddNodes(IEnumerable<T> nodes, T parent = default(T))
		{
			foreach (var node in nodes)
			{
				AddNode(node, parent);
			}
		}

		public T AddNode(string name, T parent = default(T), bool uniquifyName = true)
		{
			if (uniquifyName)
			{
				name = _Uniquify(name);
			}

			var newNode = CreateNode(name);
			AddNode(newNode, parent);
			return newNode;
		}

		public abstract void AddChildToParent(T node, T parent, int index = -1);

		public bool SetElementNode(Guid id, T node)
		{
			bool rv = _instances.ContainsKey(id);

			_instances[id] = node;
			return rv;
		}

		public bool ClearElementNode(Guid id)
		{
			return _instances.Remove(id);
		}

		public T GetElementNode(Guid id)
		{
			if (_instances.ContainsKey(id))
			{
				return _instances[id];
			}

			return default(T);
		}

		public bool ElementNodeExists(Guid id)
		{
			return _instances.ContainsKey(id);
		}
	}
}