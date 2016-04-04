using System;
using System.Xml.Serialization;

// [XmlElement("Name")]
// [XmlAttribute("Value")]
// [XmlIgnore]
// [XmlArray("Collection"), XmlArrayItem("Item")]
// public List<MyClass> Collection {get; set;}

namespace MyCode.Xml {

	[Serializable]
	public class ConfigXmlModel {

		[XmlElement("Config")]
		public Config Config { get; set; }

		public ConfigXmlModel() {}

		public ConfigXmlModel(Config config) {
			Config = config;
		}
	}

	[Serializable]
	public class Config {

		[XmlAttribute("host")]
		public string Host { get; set; }
		[XmlAttribute("port")]
		public string Port { get; set; }

		public Config() {}

		public Config(string host, string port) {
			Host = host;
			Port = port;
		}
	}
}