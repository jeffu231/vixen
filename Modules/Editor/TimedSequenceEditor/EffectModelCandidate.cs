using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Xml;
using Vixen.Module;
using Vixen.Module.Effect;
using Vixen.Services;
using Vixen.Sys.ElementNodeFilters;

namespace VixenModules.Editor.TimedSequenceEditor
{
	/// <summary>
	/// Class to hold effect data to allow it to be placed on the clipboard and be reconstructed when later pasted
	/// </summary>
	[Serializable]
	public class EffectModelCandidate
	{
		private readonly Type _moduleDataClass;
		private readonly Type[] _filterTypes;
		private readonly MemoryStream _effectData;
		private readonly MemoryStream _effectNodeFilterData;

		public EffectModelCandidate(IEffectModuleInstance effect)
		{
			LayerId = Guid.Empty;
			_moduleDataClass = effect.Descriptor.ModuleDataClass;
			DataContractSerializer ds = new DataContractSerializer(_moduleDataClass);

			TypeId = effect.Descriptor.TypeId;
			_effectData = new MemoryStream();
			using (XmlDictionaryWriter w = XmlDictionaryWriter.CreateBinaryWriter(_effectData))
				ds.WriteObject(w, effect.ModuleData);

			var elementTransforms = new List<ElementTransformModelCandidate>();
			var t = new List<Type>();
			foreach (var filter in effect.ElementNodeFilters)
			{
				elementTransforms.Add(new ElementTransformModelCandidate(filter.FilterTypeId, 
					filter.Name, filter.ChainLevel, filter.ElementNodeFilter.ModuleData.Clone()));
				var type = filter.ElementNodeFilter.Descriptor.ModuleDataClass;
				t.Add(type);
			}

			_filterTypes = t.ToArray();
			ds = new DataContractSerializer(typeof(List<ElementTransformModelCandidate>), t);
			_effectNodeFilterData = new MemoryStream();
			using (XmlDictionaryWriter w = XmlDictionaryWriter.CreateBinaryWriter(_effectNodeFilterData))
				ds.WriteObject(w, elementTransforms);
		}

		public TimeSpan StartTime { get; set; }
		public TimeSpan Duration { get; set; }
		public Guid TypeId { get; private set; }
		public Guid LayerId { get; set; }
		public Guid LayerTypeId { get; set; }
		public string LayerName { get; set; }

		public IModuleDataModel GetEffectData()
		{
			DataContractSerializer ds = new DataContractSerializer(_moduleDataClass);
			MemoryStream effectDataIn = new MemoryStream(_effectData.ToArray());
			using (XmlDictionaryReader r = XmlDictionaryReader.CreateBinaryReader(effectDataIn, XmlDictionaryReaderQuotas.Max))
				return (IModuleDataModel)ds.ReadObject(r);
			
		}

		public List<IChainableElementNodeFilter> GetElementNodeFilters()
		{
			DataContractSerializer ds = new DataContractSerializer(typeof(List<ElementTransformModelCandidate>), _filterTypes);
			MemoryStream filterDataIn = new MemoryStream(_effectNodeFilterData.ToArray());
			using (XmlDictionaryReader r =
				XmlDictionaryReader.CreateBinaryReader(filterDataIn, XmlDictionaryReaderQuotas.Max))
			{

				var filters = (List<ElementTransformModelCandidate>)ds.ReadObject(r);
				List<IChainableElementNodeFilter> nodeFilters = new List<IChainableElementNodeFilter>(filters.Count);
				
				foreach (ElementTransformModelCandidate emc in filters)
				{
					var filter = new StandardElementNodeFilter
					{
						Name = emc.Name,
						ElementNodeFilter = ElementNodeFilterService.Instance.GetInstance(emc.TypeId),
						ChainLevel = emc.ChainLevel
					};

					filter.ElementNodeFilter.ModuleData = emc.ModuleDataModel;
					nodeFilters.Add(filter);

				}

				return nodeFilters;
			}
		}
	}
}