using UnityEngine;
using System.Collections;
using System.Xml;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.IO;

namespace SmallHeart
{
	public class Info {

		// Use this as a key
		[XmlAttribute("path")]
		public string SpritePath 	 { get; set; }

		// Set from xml
		[XmlAttribute("classInfo")]
		public string ClassInfo      { get; set; }
		[XmlAttribute("className")]
		public string CharacterClass { get; set; }


		// Set from constructing the dictionary 
		public int 	  CurrStage  	 { get; set; }
		public int    TrainingTime 	 { get; set; }
		public int    HealthTotal    { get; set; }


		public Info()
		{}
		
		public Info (string path, int currStage)
		{
			SpritePath     = path;
			CurrStage  	   = currStage;
			CharacterClass = "";
			ClassInfo	   = "";
		}
		public bool SetStats (int training, int healthTotal)
		{
			TrainingTime = training;
			HealthTotal  = healthTotal;
			return true;
		}
	}

	[XmlRoot("InfoCollection")]
	public class InfoContainer
	{
		[XmlArray("Route0aInfos")]
		[XmlArrayItem("Info")]
		public List<Info> Route0aInfos = new List<Info>();

		[XmlArray("Route0bInfos")]
		[XmlArrayItem("Info")]
		public List<Info> Route0bInfos = new List<Info>();

		[XmlArray("Route1aInfos")]
		[XmlArrayItem("Info")]
		public List<Info> Route1aInfos = new List<Info>();
		
		[XmlArray("Route1bInfos")]
		[XmlArrayItem("Info")]
		public List<Info> Route1bInfos = new List<Info>();

		[XmlArray("Route2aInfos")]
		[XmlArrayItem("Info")]
		public List<Info> Route2aInfos = new List<Info>();
		
		[XmlArray("Route2bInfos")]
		[XmlArrayItem("Info")]
		public List<Info> Route2bInfos = new List<Info>();


		public static InfoContainer Load(string xmlPath)
		{
			var    serializer = new XmlSerializer(typeof(InfoContainer));
			using( var stream = new FileStream(xmlPath, FileMode.Open) )
			{
				return serializer.Deserialize(stream) as InfoContainer;
			}
		}
	}
	

}