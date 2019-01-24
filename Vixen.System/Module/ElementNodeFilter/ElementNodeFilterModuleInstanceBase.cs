using System;
using System.Collections.Generic;
using Vixen.Sys;

namespace Vixen.Module.ElementNodeFilter
{
	public abstract class ElementNodeFilterModuleInstanceBase : ModuleInstanceBase,
														   IElementNodeFilterInstance,
														   IEqualityComparer<IElementNodeFilterInstance>,
														   IEquatable<IElementNodeFilterInstance>,
														   IEqualityComparer<ElementNodeFilterModuleInstanceBase>,
														   IEquatable<ElementNodeFilterModuleInstanceBase>
	{

		public virtual bool HasSetup => false;

		public virtual bool Setup()
		{
			return false;
		}

		public virtual ElementNode[] Filter(ElementNode[] nodes)
		{
			return nodes;
		}

		
		#region Equality

		public bool Equals(IElementNodeFilterInstance x, IElementNodeFilterInstance y)
		{
			return x.InstanceId == y.InstanceId;
		}

		public int GetHashCode(IElementNodeFilterInstance obj)
		{
			return obj.InstanceId.GetHashCode();
		}

		public bool Equals(IElementNodeFilterInstance other)
		{
			return Equals(this, other);
		}

		public bool Equals(ElementNodeFilterModuleInstanceBase x, ElementNodeFilterModuleInstanceBase y)
		{
			return Equals(x, y as IElementNodeFilterInstance);
		}

		public int GetHashCode(ElementNodeFilterModuleInstanceBase obj)
		{
			return GetHashCode(obj as IElementNodeFilterInstance);
		}

		public bool Equals(ElementNodeFilterModuleInstanceBase other)
		{
			return Equals(other as IElementNodeFilterInstance);
		}
		
		#endregion

	}
}
