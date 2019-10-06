using System.Collections;
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
    GameObject item;
    // Start is called before the first frame update
    void Start()
    {
        maxHp = Random.Range(1, 11);//Just for show.
        str = Random.Range(1, 3);   //Just for show.
        def = Random.Range(1, 3);   //Just for show.
        hp = maxHp;
        nextLevel = 10 + (5 * level);
        characterUI = Instantiate(prefabCharacterUI, new Vector3(0,0,0), Quaternion.identity);
        characterUI.GetComponent<Canvas>().worldCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
        characterUI.GetComponent<Canvas>().sortingOrder = 1;
        characterUI.GetComponentInChildren<Button>().onClick.AddListener(delegate { characterUI.SetActive(false); });
        //Set the script to the instance of the CharacterCanvas object, and then run the method in it.
        writer = prefabCharacterUI.GetComponent<CharacterStatWriter>();
        writer.GetStats(hp, str, def);

        item = Instantiate(ItemPrefab, new Vector3(0, 0, 0), Quaternion.identity, characterUI.transform);
        item.GetComponent<SpriteRenderer>().sortingOrder = 2;
        item.GetComponent<ItemScript>().SetSlot(new Vector3(0, 0, 0)); // + new Vector3(-2f + i * 0.5f, 2.1f - j * 0.5f, 0));//new Vector3(-2.2f + i*0.5f, 3.9f, 0));
        item.GetComponent<ItemScript>().SetColor(new Color(1f, 0.8f, 0.8f, 255));
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
