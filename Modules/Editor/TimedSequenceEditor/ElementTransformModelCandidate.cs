using System;
using Vixen.Module;

namespace VixenModules.Editor.TimedSequenceEditor
{
	[Serializable]
	public class ElementTransformModelCandidate
	{

		public ElementTransformModelCandidate(Guid typeId, string name, int chainLevel, IModuleDataModel data)
		{
			TypeId = typeId;
			Name = name;
			ChainLevel = chainLevel;
			ModuleDataModel = data;
		}
		public Guid TypeId { get;}

		public string Name { get; }

		public int ChainLevel { get; }

		public IModuleDataModel ModuleDataModel { get; }

	}
}
