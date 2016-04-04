using UnityEngine;
using System.Collections;
using UnityEngine.UI;

using MyCode.Xml;
using MyCode.Json;
using MyCode.Bin;

public class MainScript : MonoBehaviour {

	[SerializeField]
	private Text txt;

	void Start () {

		txt.text = "";

		ConfigBinaryModel binModel = new ConfigBinaryModel(new MyCode.Bin.Config("localhost", "8000"));
		ConfigXmlModel xmlModel = new ConfigXmlModel(new MyCode.Xml.Config("localhost", "8000"));
		ConfigJsonModel jsonModel = new ConfigJsonModel(new MyCode.Json.Config("localhost", "8000"));

		BinaryManager binaryManager = new BinaryManager();
		binaryManager.SaveConfig(binModel);

		XmlManager xmlManager = new XmlManager();
		xmlManager.SaveConfig(xmlModel);

		JsonManager jsonManager = new JsonManager();
		jsonManager.SaveConfig(jsonModel);

		var m = binaryManager.LoadConfig();
		Debug.Log("Bin" + "  |  " + m.Config.Host + ":" + m.Config.Port);

		var mx = xmlManager.LoadConfig();
		Debug.Log("Xml" + "  |  " + mx.Config.Host + ":" + mx.Config.Port);

		var mj = jsonManager.LoadConfig();
		Debug.Log("Json" + "  |  " + mj.Config.Host + ":" + mj.Config.Port);

		txt.text += "Bin" + "  |  " + m.Config.Host + ":" + m.Config.Port + "\n";
		txt.text += "Xml" + "  |  " + mx.Config.Host + ":" + mx.Config.Port + "\n";
		txt.text += "Json" + "  |  " + mj.Config.Host + ":" + mj.Config.Port + "\n";
	}

	void Update () 
	{
		if (Input.GetKey(KeyCode.Escape)) 
		{
			Application.Quit ();
		}
	}
}
