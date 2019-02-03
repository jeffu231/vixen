using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Vixen.Module.Effect;
using Vixen.Sys;
using Vixen.Sys.ElementNodeFilters;

namespace Vixen.Module.SequenceType.Surrogate
{
	[DataContract(Namespace = "")]
	internal class EffectNodeSurrogate : NodeSurrogate
	{
		public EffectNodeSurrogate(IEffectNode effectNode, ModuleLocalDataSet transformsDataSet)
		{
			StartTime = effectNode.StartTime;
			TypeId = effectNode.Effect.Descriptor.TypeId;
			InstanceId = effectNode.Effect.InstanceId;
			TimeSpan = effectNode.Effect.TimeSpan;
			TargetNodes = effectNode.Effect.UnFilteredTargetNodes.Select(x => new ChannelNodeReferenceSurrogate(x)).ToArray();
			ElementTransforms = effectNode.Effect.ElementNodeFilters.Select(x => new ElementNodeTransformSurrogate(x, transformsDataSet)).ToArray();
		}

		public IEffectNode CreateEffectNode(Dictionary<Guid,ElementNode> elementNodes, ModuleLocalDataSet transformDataSet)
		{
			// Create a element node lookup of elements that are currently valid.
			
			//Currently we only have one TargetNode per effect, so removing all the extra junk that sorts though
			//Multiples. If it changes in the future, we can change this around.

			//IEnumerable<Guid> targetNodeIds = TargetNodes.Select(x => x.NodeId);
			//IEnumerable<Guid> validElementIds = targetNodeIds.Intersect(elementNodes.Keys);

			IEffectModuleInstance effect = Modules.ModuleManagement.GetEffect(TypeId);
			effect.InstanceId = InstanceId;
			effect.TimeSpan = TimeSpan;
			effect.StartTime = StartTime;
			//effect.TargetNodes = validElementIds.Select(x => elementNodes[x]).ToArray();
			ElementNode node;
			if (elementNodes.TryGetValue(TargetNodes.First().NodeId, out node))
			{
				effect.UnFilteredTargetNodes = new[] {node};
			}
			else
			{
				effect.UnFilteredTargetNodes = new ElementNode[]{};
			}

			effect.ElementNodeFilters = ElementTransforms==null?new List<IChainableElementNodeFilter>() : ElementTransforms.Select(x => x.CreateTransform(transformDataSet)).ToList();

			return new EffectNode(effect, StartTime);
		}
	}
}