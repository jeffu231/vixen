using System;
using System.Runtime.Serialization;
using Vixen.Services;
using Vixen.Sys.ElementNodeFilters;

namespace Vixen.Module.SequenceType.Surrogate
{
	[DataContract(Namespace = "")]
	public class ElementNodeTransformSurrogate
	{
		public ElementNodeTransformSurrogate(IChainableElementNodeFilter instance, ModuleLocalDataSet transformsDataSet)
		{
			Id = instance.Id;
			InstanceId = instance.ElementNodeFilter.InstanceId;
			TypeId = instance.FilterTypeId;
			Name = instance.Name;
			transformsDataSet.AssignModuleInstanceData(instance.ElementNodeFilter);
		}

		public IChainableElementNodeFilter CreateTransform(ModuleLocalDataSet transformDataSet)
		{
			var transform = new StandardElementNodeFilter {Name = Name, Id = Id};
			var transformModule = ElementNodeFilterService.Instance.GetInstance(TypeId);
			transformModule.InstanceId = InstanceId;
			transformDataSet.AssignModuleInstanceData(transformModule);
			transform.ElementNodeFilter = transformModule;
			return transform;
		}

		[DataMember]
		public Guid Id { get; protected set; }

		[DataMember]
		public Guid InstanceId { get; protected set; }

		[DataMember]
		public Guid TypeId { get; protected set; }

		[DataMember]
		public string Name { get; protected set; }
		
	}
}
