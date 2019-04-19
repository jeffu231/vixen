using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.IO;
using System.Xml;
using Vixen.Services;
using Vixen.Sys.ElementNodeFilters;

namespace VixenModules.Editor.TimedSequenceEditor
{
	[Serializable]
	internal class TimelineElementTransformsClipboardData
	{
		private readonly MemoryStream _transforms;
		private readonly Type[] _knownTypes;
		public TimelineElementTransformsClipboardData(List<IChainableElementNodeFilter> transforms)
		{
			List<ElementTransformModelCandidate> candidates = new List<ElementTransformModelCandidate>();
			var knownTypes = new List<Type>();
			foreach (var filter in transforms)
			{
				candidates.Add(new ElementTransformModelCandidate(filter.FilterTypeId,
					filter.Name, filter.ChainLevel, filter.ElementNodeFilter.ModuleData.Clone()));
				knownTypes.Add(filter.ElementNodeFilter.ModuleData.GetType());
			}
			_knownTypes = knownTypes.ToArray();

			var ds = new DataContractSerializer(typeof(List<ElementTransformModelCandidate>), knownTypes);
			_transforms = new MemoryStream();
			using (XmlDictionaryWriter w = XmlDictionaryWriter.CreateBinaryWriter(_transforms))
				ds.WriteObject(w, candidates);
		}

		/// <summary>
		/// Creates a distinct set of transforms from the stored representation each time it is called.
		/// </summary>
		/// <returns></returns>
		public List<IChainableElementNodeFilter> CreateElementNodeFilters()
		{
			DataContractSerializer ds = new DataContractSerializer(typeof(List<ElementTransformModelCandidate>), _knownTypes);
			MemoryStream filterDataIn = new MemoryStream(_transforms.ToArray());
			using (XmlDictionaryReader r =
				XmlDictionaryReader.CreateBinaryReader(filterDataIn, XmlDictionaryReaderQuotas.Max))
			{

				var filters = (List<ElementTransformModelCandidate>)ds.ReadObject(r);
				List<IChainableElementNodeFilter> elementNodeFilters = new List<IChainableElementNodeFilter>(filters.Count);

				foreach (ElementTransformModelCandidate emc in filters)
				{
					var filter = new StandardElementNodeFilter
					{
						Name = emc.Name,
						ElementNodeFilter = ElementNodeFilterService.Instance.GetInstance(emc.TypeId),
						ChainLevel = emc.ChainLevel
					};

					filter.ElementNodeFilter.ModuleData = emc.ModuleDataModel.Clone();
					elementNodeFilters.Add(filter);

				}

				return elementNodeFilters;
			}
		}
	}
}
