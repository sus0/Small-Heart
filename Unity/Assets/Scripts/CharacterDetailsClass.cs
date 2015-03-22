using UnityEngine;
using System.Collections;
using System.Xml;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.IO;


namespace SmallHeart
{
	public class CharacterDetails{
		// Use this as a key
		[XmlAttribute("path")]
		public string SpritePath 	 { get; set; }
		
		// Set from xml
		[XmlAttribute("classInfo")]
		public string ClassInfo      { get; set; }
		[XmlAttribute("className")]
		public string CharacterClass { get; set; }
		[XmlAttribute("speechBox")]
		public string SpeechBoxString		 { get; set; }
	}

	[XmlRoot("InfoCollection")]
	public class CharacterDetailsContainer
	{
		[XmlArray("Route0aInfos")]
		[XmlArrayItem("Info")]
		public List<CharacterDetails> Route0aDetails = new List<CharacterDetails>();
		
		[XmlArray("Route0bInfos")]
		[XmlArrayItem("Info")]
		public List<CharacterDetails> Route0bDetails = new List<CharacterDetails>();
		
		[XmlArray("Route1aInfos")]
		[XmlArrayItem("Info")]
		public List<CharacterDetails> Route1aDetails = new List<CharacterDetails>();
		
		[XmlArray("Route1bInfos")]
		[XmlArrayItem("Info")]
		public List<CharacterDetails> Route1bDetails = new List<CharacterDetails>();
		
		[XmlArray("Route2aInfos")]
		[XmlArrayItem("Info")]
		public List<CharacterDetails> Route2aDetails = new List<CharacterDetails>();
		
		[XmlArray("Route2bInfos")]
		[XmlArrayItem("Info")]
		public List<CharacterDetails> Route2bDetails = new List<CharacterDetails>();
		
		
		public static CharacterDetailsContainer Load(string xmlPath)
		{
			var    serializer = new XmlSerializer(typeof(CharacterDetailsContainer));
			using( var stream = new FileStream(xmlPath, FileMode.Open) )
			{
				return serializer.Deserialize(stream) as CharacterDetailsContainer;
			}
		}
	}

}