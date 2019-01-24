using System;
using System.Collections.Generic;

namespace Vixen.Module.ElementNodeFilter
{
	public abstract class ElementNodeFilterModuleDescriptorBase : ModuleDescriptorBase, IElementNodeFilterModuleDescriptor,
															 IEqualityComparer<IElementNodeFilterModuleDescriptor>,
															 IEquatable<IElementNodeFilterModuleDescriptor>,
															 IEqualityComparer<ElementNodeFilterModuleDescriptorBase>,
															 IEquatable<ElementNodeFilterModuleDescriptorBase>
	{
		public abstract override string TypeName { get; }

		public abstract override Guid TypeId { get; }

		public abstract override Type ModuleClass { get; }

		public abstract override string Author { get; }

		public abstract override string Description { get; }

		public abstract override string Version { get; }

		public bool Equals(IElementNodeFilterModuleDescriptor x, IElementNodeFilterModuleDescriptor y)
		{
			return base.Equals(x, y);
		}

		public int GetHashCode(IElementNodeFilterModuleDescriptor obj)
		{
			return base.GetHashCode();
		}

		public bool Equals(IElementNodeFilterModuleDescriptor other)
		{
			return base.Equals(other);
		}

		public bool Equals(ElementNodeFilterModuleDescriptorBase x, ElementNodeFilterModuleDescriptorBase y)
		{
			return Equals(x, y as IElementNodeFilterModuleDescriptor);
		}

		public int GetHashCode(ElementNodeFilterModuleDescriptorBase obj)
		{
			return GetHashCode(obj as IElementNodeFilterModuleDescriptor);
		}

		public bool Equals(ElementNodeFilterModuleDescriptorBase other)
		{
			return Equals(other as IElementNodeFilterModuleDescriptor);
		}
	}

}
