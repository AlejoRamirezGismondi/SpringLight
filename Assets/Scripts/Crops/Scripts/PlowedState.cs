﻿using Inventory.Scripts;
using Items.Scripts;
using UnityEngine;

namespace Crops.Scripts
{
    [CreateAssetMenu(fileName = "New CropState", menuName = "CropState/Plowed")]
    public class PlowedState : CropState
    {
        public Sprite sprite;
        public override void Interact(CropTile cropTile, InventoryComponent inventoryComponent)
        {
            if (inventoryComponent.GetSelectedSlot().itemObject.type != ItemType.Seed) return;
            cropTile.SetState(nextState);
            inventoryComponent.RemoveSelectedItem(1);
        }

        public override void Initialize(CropTile cropTile)
        {
            cropTile.SetSprite(sprite);
        }
    }
}