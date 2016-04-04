using System;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using UnityEngine;

namespace MyCode.Xml {

	public class XmlManager {

		public void SaveConfig(ConfigXmlModel model) {
			XmlSerializer serializer = new XmlSerializer(typeof(ConfigXmlModel));
			using(StreamWriter writer = new StreamWriter(getPath(), false, Encoding.UTF8)) {
				serializer.Serialize(writer, model);
			}
		}

		public ConfigXmlModel LoadConfig() {
			XmlSerializer serializer = new XmlSerializer(typeof(ConfigXmlModel));
			using(StreamReader reader = new StreamReader(getPath(), Encoding.UTF8)) {
				ConfigXmlModel xmlModel = serializer.Deserialize(reader) as ConfigXmlModel;
				return xmlModel;
			}
		}

		private string getPath() {

			string path = null;

			switch (Application.platform) {

				case RuntimePlatform.Android: {
					path = "/mnt/sdcard/config.xml";
					break;
				}
				default: {
					path = Path.Combine(Application.dataPath, "config.xml");
					break;
				}
			}

			return path;
		}
	}
}

