using System;
using System.Collections;
using System.IO;
using System.Text;
using UnityEngine;

namespace MyCode.Json {

	public class JsonManager {

		public void SaveConfig(ConfigJsonModel model) {
			using(StreamWriter writer = new StreamWriter(getPath(), false, Encoding.UTF8)) {
				string json = JsonUtility.ToJson(model, true);
				writer.Write(json);
			}
		}

		public ConfigJsonModel LoadConfig() {
			using(StreamReader reader = new StreamReader(getPath(), Encoding.UTF8)) {
				ConfigJsonModel jsonModel = JsonUtility.FromJson<ConfigJsonModel>(reader.ReadToEnd());
				return jsonModel;
			}
		}

		private string getPath() {

			string path = null;

			switch (Application.platform) {

				case RuntimePlatform.Android: {
						path = "/mnt/sdcard/config.json";
						break;
					}
				default: {
						path = Path.Combine(Application.dataPath, "config.json");
						break;
					}
			}

			return path;
		}
	}
	
}
