using System;

namespace MyCode.Json {

	[Serializable] 
	public class ConfigJsonModel {
		
		public Config Config;
		
		public ConfigJsonModel() {}
		
		public ConfigJsonModel(Config config) {
			Config = config;
		}
	}

	[Serializable] 
	public class Config {

		public string Host;
		public string Port;

		public Config() {}

		public Config(string host, string port) {
			Host = host;
			Port = port;
		}
	}

}