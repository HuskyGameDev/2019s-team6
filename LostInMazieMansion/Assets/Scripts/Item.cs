/*
 * All interactable items will have certain things in common:
 *    they all have a name
 *    they all have a sprite/picutre/icon
 *    they may or may not be collectable
 *    a message will appear when the player interacts with the item
 *    a message will appear when the player uses the item
 *    a message will appear when the player discards the item
 *    a sound will play when the player picks up a collectable item
 *    a sound will play when a player uses an item
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "GameObject/Item")]
public class Item : ScriptableObject
{
    // the name of the item
    public string itemName;

    // the item's picture/icon
    public Sprite picture;

    // true if the item can be collected, false if only interacted with
    public bool collect;

    // a message that appears when the player interacts with the object
    public string messageOnInteract;

    // a message that appears when the player uses the item
    public string messageOnUse;

    // a message that appears when the player discards an item
    public string messageOnDiscard;

    // a sound that sounds when the player picks up a collectable item
    public AudioClip pickUpSound;

    // a sound that sounds when the player uses an item
    public AudioClip useSound;
}
