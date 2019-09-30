using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StorageLoader : MonoBehaviour
{
    public GameObject StoragePrefab;
    public GameObject ItemPrefab;
    List<GameObject> items = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        GetComponentInChildren<Button>().onClick.AddListener(delegate { StoragePrefab.SetActive(false); });
        //Instantiate(ItemPrefab, new Vector3(0, 0, 0), Quaternion.identity, gameObject.transform);
        //items.Add(ItemPrefab.GetComponent<ItemScript>().CreateItem());
        items.Add(Instantiate(ItemPrefab, new Vector3(0, 0, 0), Quaternion.identity, gameObject.transform));
        items.Add(Instantiate(ItemPrefab, new Vector3(0, 0, 0), Quaternion.identity, gameObject.transform));
        items.Add(Instantiate(ItemPrefab, new Vector3(0, 0, 0), Quaternion.identity, gameObject.transform));
        int i = 0;
        foreach(GameObject item in items)
        {
            item.GetComponent<ItemScript>().SetSlot(new Vector3(-2.2f + i*0.5f, 3.9f, 0));
            item.GetComponent<ItemScript>().SetColor(new Color(0.8f, 0.8f, 0.3f * i, 255));
            i++;           
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (GetComponent<Collider2D>().OverlapPoint(mousePosition))
            {
                if(MouseData.GetItem() != null)
                {
                    foreach (GameObject item in items)
                    {
                        if (item != MouseData.GetItem() && item.GetComponent<Collider2D>().OverlapPoint(mousePosition))
                        {
                            SwitchPositions(MouseData.GetItem(), item);
                            Debug.Log("Items switched");
                            break;
                        }
                    }
                    Debug.Log("Dropped item in storage");
                }
            }
        }
    }

    public void AddItem(GameObject go)
    {
        
    }

    public void SwitchPositions(GameObject droppedItem, GameObject onItem)
    {
        int foundItems = 0;
        foreach (GameObject item in items)
        {
            if(item == onItem || item == droppedItem)
            {
                foundItems++;
            }
        }
        if(foundItems == 2)
        {
            GameObject temp = droppedItem;
            Vector3 onItemPosition = onItem.GetComponent<ItemScript>().SlotPositon();
            int droppedItemIndex = items.IndexOf(droppedItem);
            int onItemIndex = items.IndexOf(onItem);
            onItem.GetComponent<ItemScript>().SetSlot(temp.GetComponent<ItemScript>().SlotPositon());
            temp.GetComponent<ItemScript>().SetSlot(onItemPosition);
            items[droppedItemIndex] = onItem;
            items[onItemIndex] = temp;
        }
    }
}
