using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootScript : MonoBehaviour
{
    public string[] inventory;
    private GameObject[] characters;
    private float distance;
    private int range;
    private int charactersInRange;
    private int inventorySize;
    private bool isActive;

    private CharacterScript cs;

    private void Start()
    {
        range = 20;
    }

    private void OnMouseDown()
    {
        CheckRange();

        if (isActive)
        {
            //Give inventory to character :)

            for (int i = 0; i < inventory.Length; i++)
            {
                if (inventory[i] != "")
                {
                    WorldScript.world.AddItem(inventory[i], 1);
                }
            }
            Destroy(gameObject);
            //cs = character.GetComponent<CharacterScript>();
            //for (int i = 0; i < cs.inventory.Length; i++)
            //{
            //    if (cs.inventory[i] == "")
            //    {
            //        inventorySize--;
            //        for (int j = 0; j < inventory.Length; j++)
            //        {
            //            if (inventory[j] != null)
            //            {
            //                cs.inventory[i] = inventory[j];
            //                break;
            //            }
            //        }
            //    }
            //    if (inventorySize <= 0)
            //    {
            //        Destroy(gameObject);
            //        break;
            //    }
            //}
        }
    }

    public void GetItems(string[] inventory)
    {
        this.inventory = inventory;
        inventorySize = inventory.Length;
        characters = GameObject.FindGameObjectsWithTag("Character");
    }

    #region CheckRange
    private void CheckRange()
    {
        charactersInRange = 0;
        if (!isActive)
        {
            foreach (GameObject character in characters)
            {
                if (character != null)
                {
                    distance = Vector3.Distance(character.transform.position, transform.position);
                    if (distance <= range)
                    {
                        charactersInRange = 1;
                    }
                }
            }
        }
        if (charactersInRange > 0)
        {
            Debug.Log("Active: " + isActive);
            isActive = true;
        }
        else
        {
            isActive = false;
        }
    }
    #endregion
}
