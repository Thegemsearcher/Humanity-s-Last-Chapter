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
        Instantiate(ItemPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        items.Add(ItemPrefab.GetComponent<ItemScript>().CreateItem());
        int i = 0;
        foreach(GameObject item in items)
        {
            item.GetComponent<ItemScript>().SetSlot(new Vector3(GetComponent<RectTransform>().position.x + i * 15, GetComponent<RectTransform>().position.y, 0));
            i++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddItem(GameObject go)
    {
        
    }
}
