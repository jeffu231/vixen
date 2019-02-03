using System;
using System.Runtime.Serialization;

namespace Vixen.Module.SequenceType.Surrogate
{
	[DataContract(Namespace = "")]
	internal abstract class NodeSurrogate
	{
		[DataMember]
		public Guid TypeId { get; protected set; }

		[DataMember]
		public Guid InstanceId { get; protected set; }

		[DataMember]
		public TimeSpan StartTime { get; protected set; }

		[DataMember]
		public TimeSpan TimeSpan { get; protected set; }

		[DataMember]
		public ChannelNodeReferenceSurrogate[] TargetNodes { get; protected set; }

		[DataMember(EmitDefaultValue = false)]
		public ElementNodeTransformSurrogate[] ElementTransforms { get; protected set; }

		[OnDeserialized]
		private void OnDeserialized(StreamingContext c)
		{
			if (ElementTransforms == null)
			{
				ElementTransforms = new ElementNodeTransformSurrogate[]{};
			}
		}

		[OnSerializing]
		private void OnSerializing(StreamingContext c)
		{
			if (ElementTransforms.Length == 0)
			{
				ElementTransforms = null;
			}
		}
	}
}