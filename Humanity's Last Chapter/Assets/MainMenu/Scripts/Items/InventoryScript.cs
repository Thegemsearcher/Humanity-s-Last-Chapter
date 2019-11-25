using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryScript : MonoBehaviour
{
    public GameObject lootBox;
    private GameObject holder;
    public string[] inventory;

    void OnDestroy()
    {
        holder = Instantiate(lootBox);
        holder.transform.position = transform.position;
        holder.GetComponent<LootScript>().GetItems(inventory);
    }
}
