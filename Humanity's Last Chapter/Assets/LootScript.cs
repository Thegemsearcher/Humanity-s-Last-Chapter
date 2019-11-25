using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LootScript : MonoBehaviour, IPointerClickHandler
{
    public string[] inventory;
    private GameObject[] characters;
    private float distance;
    private int range;
    private int charactersInRange;
    private bool isActive;

    private void Start()
    {
        range = 20;
    }

    public void OnPointerClick(PointerEventData pointerEventData)
    {
        Debug.Log("does it get here?");
        CheckRange();
        if (isActive)
        {
            //Give inventory to character :)
        }
    }

    public void GetItems(string[] inventory)
    {
        this.inventory = inventory;
        characters = GameObject.FindGameObjectsWithTag("Character");
    }

    #region CheckRange
    private void CheckRange()
    {
        charactersInRange = 0;
        foreach (GameObject character in characters)
        {
            if (character != null)
            {
                distance = Vector3.Distance(character.transform.position, transform.position);
                if (distance <= range)
                {
                    charactersInRange++;
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
