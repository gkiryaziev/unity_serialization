using System;

namespace MyCode.Bin {

	[Serializable]
	public class ConfigBinaryModel {

		public Config Config { get; set; }

		public ConfigBinaryModel() {}

		public ConfigBinaryModel(Config config) {
			Config = config;
		}
	}

	[Serializable]
	public class Config {

		public string Host { get; set; }
		public string Port { get; set; }

		public Config() {}

		public Config(string host, string port) {
			Host = host;
			Port = port;
		}
	}
}