﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class stats : MonoBehaviour
{
    public int hp, maxHp, str, def, level, exp, nextLevel;
    private int cost;
    public GameObject characterUI;
    public GameObject prefabCharacterUI;
    CharacterStatWriter writer;
    public GameObject ItemPrefab;
    private GameObject itemGrid;
    public List<GameObject> items = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        maxHp = Random.Range(1, 11);//Just for show.
        str = Random.Range(1, 3);   //Just for show.
        def = Random.Range(1, 3);   //Just for show.
        hp = maxHp;
        nextLevel = 10 + (5 * level);

        //Fix CharacterCanvas
        characterUI = Instantiate(prefabCharacterUI, new Vector3(0,0,0), Quaternion.identity);
        characterUI.GetComponent<Canvas>().worldCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
        characterUI.GetComponent<Canvas>().sortingOrder = 1;
        characterUI.GetComponentInChildren<Button>().onClick.AddListener(delegate { characterUI.SetActive(false); });
       
        //Set the script to the instance of the CharacterCanvas object, and then run the method in it.
        writer = prefabCharacterUI.GetComponent<CharacterStatWriter>();
        writer.GetStats(hp, str, def);

        //Create items
        foreach (Transform t in characterUI.transform)
        {
            if (t.tag == "ItemGrid")
            {
                itemGrid = t.gameObject;
            }
        }
        for (int x = 0; x < 6; x++)
            items.Add(Instantiate(ItemPrefab, itemGrid.transform));
        for (int x = 0; x < GetComponent<CharacterScript>().itemID.Length; x++)
        {
            string itemId = GetComponent<CharacterScript>().itemID[x];
            if (itemId != null)
                items[x].GetComponent<ItemScript>().CreateItem(itemId);
        }

        //This is dumb, but CharacterCanvas is a canvas, so it's dumb.
        for (int x = 0; x < characterUI.transform.childCount; x++)
            characterUI.transform.GetChild(x).transform.position += new Vector3(-4f, 1.9f, 0);

        //Configure items
        int i = 0;
        int j = 0;
        foreach (GameObject item in items)
        {
            item.GetComponent<ItemScript>().SetSlot(item.transform.position + new Vector3(0 + i * 0.6f, 0 - j * 0.6f, 0)); // + new Vector3(-2f + i * 0.5f, 2.1f - j * 0.5f, 0));//new Vector3(-2.2f + i*0.5f, 3.9f, 0));
            i++;
            if (i > 2)
            {
                i = 0;
                j++;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    public int GetCost() {
        cost = (maxHp * 10) + (str * 3) + (def * 3);
        return cost;
    }

    public void BringUpStats()
    {
        //GetComponentInParent<AddToPlayerRoster>().controller.GetComponent<HubCharController>().CloseAllWindows();
        characterUI.SetActive(true);
    }
}
