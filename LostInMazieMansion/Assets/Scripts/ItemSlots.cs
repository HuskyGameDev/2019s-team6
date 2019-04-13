using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlots : MonoBehaviour
{
    // the item in the item slot
    InventoryItems itemInSlot;

    // the use button
    GameObject useButton;

    // the discard button
    GameObject discardButton;

    /*
     * If the player clicks on the inventory slot, then the
     * "use" and "discard" buttons appear.  If the player
     * clicks the item again, these buttons disappear.
     */
    public void OnItemClicked()
    {
        itemInSlot = GetComponentInChildren<InventoryItems>();

        if (!useButton.activeInHierarchy)
        {
            if (itemInSlot.icon != null)
            {
                useButton.SetActive(true);
                discardButton.SetActive(true);
            }
        }

        else
        {
            useButton.SetActive(false);
            discardButton.SetActive(false);
        }

    }

    /*
     * Start with both the "use" and "discard" buttons off
     */
    private void Start()
    {
        useButton = GetComponentInChildren<UseButton>().gameObject;
        useButton.SetActive(false);

        discardButton = GetComponentInChildren<DiscardButton>().gameObject;
        discardButton.SetActive(false);
    }
}
