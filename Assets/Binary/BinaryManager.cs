using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace MyCode.Bin {

	public class BinaryManager {

		public void SaveConfig(ConfigBinaryModel model) {
			BinaryFormatter formatter = new BinaryFormatter();
			using(FileStream fileStream = new FileStream(getPath(), FileMode.OpenOrCreate)) {
				formatter.Serialize(fileStream, model);
			}
		}

		public ConfigBinaryModel LoadConfig() {
			BinaryFormatter formatter = new BinaryFormatter();
			using(FileStream fileStream = new FileStream(getPath(), FileMode.OpenOrCreate)) {
				ConfigBinaryModel binaryModel = formatter.Deserialize(fileStream) as ConfigBinaryModel;
				return binaryModel;
			}
		}

		private string getPath() {

			string path = null;

			switch (Application.platform) {
				
				case RuntimePlatform.Android: {
					path = "/mnt/sdcard/config.dat";
					break;
				}
				default: {
					path = Path.Combine(Application.dataPath, "config.dat");
					break;
				}
			}

			return path;
		}
	}
}

