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
        holder = Instantiate(lootBox);
        holder.transform.position = transform.position;
        holder.GetComponent<LootScript>().GetItems(inventory);
    }

    void OnDestroy() //Den kommer hit när man stänger av...
    {
        
    }

}
