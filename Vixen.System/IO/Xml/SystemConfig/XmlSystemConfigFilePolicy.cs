﻿using System;
using System.Xml.Linq;
using Vixen.IO.Policy;
using Vixen.IO.Xml.Serializer;

namespace Vixen.IO.Xml.SystemConfig {
	using Vixen.Sys;

	class XmlSystemConfigFilePolicy : SystemConfigFilePolicy {
		private SystemConfig _systemConfig;
		private XElement _content;

		private const string ELEMENT_IDENTITY = "Identity";
		private const string ELEMENT_EVAL_FILTERS = "AllowFilterEvaluation";
		private const string ATTR_IS_CONTEXT = "isContext";

		public XmlSystemConfigFilePolicy(SystemConfig systemConfig, XElement content) {
			_systemConfig = systemConfig;
			_content = content;
		}

		protected override void WriteContextFlag() {
			// If not a context, don't include the flag.
			if(_systemConfig.IsContext) {
				_content.Add(new XAttribute(ATTR_IS_CONTEXT, true));
			}
		}

		protected override void WriteIdentity() {
			_content.Add(new XElement(ELEMENT_IDENTITY, _systemConfig.Identity));
		}

		protected override void WriteFilterEvaluationAllowance() {
			_content.Add(new XElement(ELEMENT_EVAL_FILTERS, _systemConfig.AllowFilterEvaluation));
		}

		protected override void WriteChannels() {
			XmlChannelCollectionSerializer serializer = new XmlChannelCollectionSerializer();
			XElement element = serializer.WriteObject(_systemConfig.Channels);
			_content.Add(element);
		}

		protected override void WriteNodes() {
			XmlChannelNodeCollectionSerializer serializer = new XmlChannelNodeCollectionSerializer(_systemConfig.Channels);
			XElement element = serializer.WriteObject(_systemConfig.Nodes);
			_content.Add(element);
		}

		protected override void WriteControllers() {
			XmlControllerCollectionSerializer serializer = new XmlControllerCollectionSerializer();
			XElement element = serializer.WriteObject(_systemConfig.OutputControllers);
			_content.Add(element);
		}

		protected override void WriteControllerLinks() {
			XmlControllerLinkCollectionSerializer serializer = new XmlControllerLinkCollectionSerializer();
			XElement element = serializer.WriteObject(_systemConfig.ControllerLinking);
			_content.Add(element);
		}

		protected override void WriteSmartControllers() {
			XmlSmartControllerCollectionSerializer serializer = new XmlSmartControllerCollectionSerializer();
			XElement element = serializer.WriteObject(_systemConfig.SmartOutputControllers);
			_content.Add(element);
		}

		protected override void WriteDisabledDevices() {
			XmlDisabledControllerCollectionSerializer serializer = new XmlDisabledControllerCollectionSerializer();
			XElement element = serializer.WriteObject(_systemConfig.DisabledDeviceIds);
			_content.Add(element);
		}

		protected override void WritePreviews() {
			XmlPreviewCollectionSerializer serializer = new XmlPreviewCollectionSerializer();
			XElement element = serializer.WriteObject(_systemConfig.Previews);
			_content.Add(element);
		}

		protected override void WriteFilters() {
			XmlOutputFilterCollectionSerializer serializer = new XmlOutputFilterCollectionSerializer();
			XElement element = serializer.WriteObject(_systemConfig.Filters);
			_content.Add(element);
		}

		protected override void WriteDataFlowPatching() {
			XmlDataFlowPatchCollectionSerializer serializer = new XmlDataFlowPatchCollectionSerializer();
			XElement element = serializer.WriteObject(_systemConfig.DataFlow);
			_content.Add(element);
		}

		protected override void ReadContextFlag() {
			// The presence of the flag is enough.  The value is immaterial.
			_systemConfig.IsContext = _content.Attribute(ATTR_IS_CONTEXT) != null;
		}

		protected override void ReadIdentity() {
			XElement identityElement = _content.Element(ELEMENT_IDENTITY);
			if(identityElement != null) {
				_systemConfig.Identity = Guid.Parse(identityElement.Value);
			} else {
				VixenSystem.Logging.Warning("System config does not have an identity value.");
			}
		}

		protected override void ReadFilterEvaluationAllowance() {
			// If it can't be determined, default to true.
			_systemConfig.AllowFilterEvaluation = XmlHelper.GetElementValue(_content, ELEMENT_EVAL_FILTERS, true);
		}

		protected override void ReadChannels() {
			XmlChannelCollectionSerializer serializer = new XmlChannelCollectionSerializer();
			_systemConfig.Channels = serializer.ReadObject(_content);
		}

		protected override void ReadNodes() {
			XmlChannelNodeCollectionSerializer serializer = new XmlChannelNodeCollectionSerializer(_systemConfig.Channels);
			_systemConfig.Nodes = serializer.ReadObject(_content);
		}

		protected override void ReadControllers() {
			XmlControllerCollectionSerializer serializer = new XmlControllerCollectionSerializer();
			_systemConfig.OutputControllers = serializer.ReadObject(_content);
		}

		protected override void ReadControllerLinks() {
			XmlControllerLinkCollectionSerializer serializer = new XmlControllerLinkCollectionSerializer();
			_systemConfig.ControllerLinking = serializer.ReadObject(_content);
		}

		protected override void ReadSmartControllers() {
			XmlSmartControllerCollectionSerializer serializer = new XmlSmartControllerCollectionSerializer();
			_systemConfig.SmartOutputControllers = serializer.ReadObject(_content);
		}

		protected override void ReadDisabledDevices() {
			XmlDisabledControllerCollectionSerializer serializer = new XmlDisabledControllerCollectionSerializer();
			_systemConfig.DisabledDeviceIds = serializer.ReadObject(_content);
		}

		protected override void ReadPreviews() {
			XmlPreviewCollectionSerializer serializer = new XmlPreviewCollectionSerializer();
			_systemConfig.Previews = serializer.ReadObject(_content);
		}

		protected override void ReadFilters() {
			XmlOutputFilterCollectionSerializer serializer = new XmlOutputFilterCollectionSerializer();
			_systemConfig.Filters = serializer.ReadObject(_content);
		}

		protected override void ReadDataFlowPatching() {
			XmlDataFlowPatchCollectionSerializer serializer = new XmlDataFlowPatchCollectionSerializer();
			_systemConfig.DataFlow = serializer.ReadObject(_content);
		}
	}
}