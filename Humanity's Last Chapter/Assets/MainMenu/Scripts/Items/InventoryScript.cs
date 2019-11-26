using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryScript : MonoBehaviour
{
    public GameObject lootBox;
    private GameObject holder;
    public string[] inventory;

    public void GetInventory(string[] inventory)
    {
        this.inventory = inventory;
    }

    void OnDestroy()
    {
        holder = Instantiate(lootBox);
        holder.transform.position = transform.position;
        Debug.Log("InventoryScript's inventory: " + inventory.Length);
        holder.GetComponent<LootScript>().GetItems(inventory);
    }
}
