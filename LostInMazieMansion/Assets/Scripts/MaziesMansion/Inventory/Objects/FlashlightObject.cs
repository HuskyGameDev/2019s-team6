using System;
using UnityEngine;

namespace MaziesMansion.InventoryObjects
{
    [CreateAssetMenu(fileName = "Flashlight", menuName = "Mazie/Inventory/Flashlight")]
    [Serializable]
    public sealed class FlashlightObject : InventoryObject
    {
        public override void OnUse()
        {
            var light = Player.Instance?.Flashlight;
            if(null != light)
            {
                // toggle the light when the object is clicked in the inventory
                light.IsOn = !light.IsOn;
            }
        }
    }
}
