using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using System.Text;

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
	/// Inventory Item
	/// Used for the player inventory to track all the available items the player can build.
	/// </summary>
	[Serializable]
	public class InventoryItem
	{
		/// <summary>
		/// Create empty inventory item
		/// </summary>
		public InventoryItem(){}

		/// <summary>
		/// Create a inventory item
		/// </summary>
		/// <param name="_name"></param>
		/// <param name="_type"></param>
		public InventoryItem( string _name, ItemType _type)
		{	
			mItemName = _name;
			mItemType = _type;
		}

		/// <summary>
		/// Item name
		/// Purely for the UI.
		/// </summary>
		public string mItemName;

		/// <summary>
		/// The icon path for the item
		/// </summary>
		public JsonSprite mItemIcon;

		// Entity allows you to select it in the toolbar,
		// Resource shows you the quantity below the icon e.g. scrap metal\n quantity: x
		public enum ItemType { Entity=0, Resource=1};
		public ItemType mItemType;
	}
}