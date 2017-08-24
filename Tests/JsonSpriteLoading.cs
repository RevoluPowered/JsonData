using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using System.Text.RegularExpressions;
using System.Linq;
using UIHelper;
using JsonData;
using System;

/// <summary>
/// JsonData is written by Gordon Alexander MacPherson
/// All rights are reserved 2017
/// License: Private / Commercial
/// NOTE: This has been used in commercial products for other companies.
/// Copyright 2017 (c) Gordon Alexander MacPherson
/// Provided without warantee, no copying or redistrubution is allowed.
/// </summary>
namespace JsonData
{

    /// <summary>
    /// JsonSpriteLoading is a quick example of how JsonSprite enables the ability to write Unity Sprites reliably to a file.
    /// Currently unity doesn't allow you to do this easily.
    /// </summary>
    public class JsonSpriteLoading : MonoBehaviour
    {
        void Start()
        {
            
        }
        private string sprite_path = @"Assets\Resources\Sprite.Data\";
        public void Test()
        {
            print("Creating dummy JsonSprite file");
            //JsonSprite sprite = new JsonSprite("testfile.png");
            
            DirectoryInfo _sprite_dir = new DirectoryInfo(sprite_path);
            foreach(FileInfo f in _sprite_dir.GetFiles("*.png"))
            {
                JsonSprite sprite = new JsonSprite(UsefulJsonUtils.RelativeResourcePath(f.FullName.Replace(".png","")));
            }
        }

        void Update()
        {

        }
    }
}