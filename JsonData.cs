using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using System.Text;

/// <summary>
/// JsonData is written by Gordon Alexander MacPherson
/// All rights are reserved 2017
/// Copyright 2017 (c) Gordon Alexander MacPherson
/// Provided without warantee, no copying or redistrubution is allowed.
/// </summary>
namespace JsonData
{
	/// <summary>
	/// Data settings are used when writing the file, for version control and encoding control.
	/// This is useful if you change versions of your game and they have an old version of the save file 
	/// as you can write simple wrappers to convert old save data to the new save data format.
	/// </summary>
	public class DataSettings
	{
		public static Encoding DefaultEncoding = Encoding.GetEncoding("utf-8");
		public static string FileVersion = "0.1";

	}

	/// <summary>
	/// Useful Json Utils 
	/// Used to handle path information
	/// </summary>
	public class UsefulJsonUtils
	{
		/// <summary>
		/// Unity resource folder path
		/// </summary>
		private static string resources_folder = Application.dataPath + @"/Resources/";

		/// <summary>
		/// Retrieve the relative path of a resource (using filesystem module)
		/// </summary>
		/// <param name="file"></param>
		/// <returns></returns>
		public static string RelativeResourcePath( string file )
		{
			var fileUri = new System.Uri(file);
			var referenceUri = new System.Uri(resources_folder);
    		return referenceUri.MakeRelativeUri(fileUri).ToString();
		}
	}


	/// <summary>
	/// JsonTest is a test class which shows examples of the framework in action See JsonSpriteLoading.cs for an example.
	/// </summary>
	[Serializable]
	public class JsonTest
	{
		public string jsonfile = "test_file.txt";
		public List<JsonSprite> test_files;
	}

	/// <summary>
	/// Wrapper object for sprite
	/// You MUST HAVE THE FILE IN THE RESOURCES FOLDER (There is no multi-platform solutions which work well)
	/// This allows you to reliably save sprites to JSON files without relying upon the instance ID (which unity fails to transfer to builds)
	/// </summary>
	[Serializable]
	public class JsonSprite
	{	
		/// <summary>
		/// Initialise a JsonSprite
		/// </summary>
		public JsonSprite(){}

		/// <summary>
		/// JsonSprite - initialise with a path
		/// </summary>
		/// <param name="_sprite_path"></param>
		public JsonSprite( string _sprite_path )
		{
			#if UNITY_EDITOR
			//Debug.Log("path debug " + path.Replace("Assets/Resources/",""));
			mSpritePath = _sprite_path.Replace(@"Assets\Resources\","");
			//Debug.LogError("Sprite path: " + mSpritePath);
			// replace("Assets/Resources","")
			#endif
		}

		/// <summary>
		/// Unity Sprite = Loaded when the sprite is retrieved in the get accessor 
		/// </summary>
		[NonSerialized]
		private Sprite mSprite = null;

		/// <summary>
		/// Sprite Accessor - use this when you want to retrieve the JsonSprite
		/// Note: overwriting sprite doesn't update the path
		/// </summary>
		/// <returns></returns>
		public Sprite Sprite {
			get
			{
				if(mSprite == null)
				{
					Debug.Log("Loading: " + mSpritePath);
					mSprite = (Sprite)Resources.Load(mSpritePath,typeof(Sprite));
					Debug.Log("Loaded object (debug-click here) ", mSprite);
				}

				return mSprite;
			}
			set
			{
				mSprite = value;
			}
		}

		/// <summary>
		/// The actual sprite path, this is saved in the JsonObject
		/// </summary>
		public string mSpritePath = "";
	}
}
