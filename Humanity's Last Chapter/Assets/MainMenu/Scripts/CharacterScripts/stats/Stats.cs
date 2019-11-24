using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Stats : MonoBehaviour {
    public int hp, maxHp, str, def, Int, dex, cha, ldr, nrg, snt, level, exp, nextLevel;
    private int cost;
    public GameObject characterUI;
    public GameObject prefabCharacterUI;
    CharacterStatWriter writer;
    public GameObject ItemPrefab;
    private GameObject itemGrid;
    public List<GameObject> items = new List<GameObject>();
    List<QuirkObject> quirkList;

    // Start is called before the first frame update
    void Start() {
        if (maxHp == 0) {
            maxHp = Random.Range(6, 11);//Just for show.
            hp = maxHp;
        }

        str = Random.Range(1, 3);   //Just for show.
        def = Random.Range(1, 3);   //Just for show.
        Int = Random.Range(1, 3);   //Just for show.
        dex = Random.Range(1, 3);   //Just for show.
        cha = Random.Range(1, 3);   //Just for show.
        ldr = Random.Range(1, 3);   //Just for show.
        nrg = Random.Range(1, 3);   //Just for show.
        snt = Random.Range(1, 3);   //Just for show.

        nextLevel = 10 + (5 * level);

        //Fix CharacterCanvas
        characterUI = Instantiate(prefabCharacterUI, new Vector3(0, 0, 0), Quaternion.identity);
        characterUI.GetComponent<Canvas>().worldCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
        characterUI.GetComponent<Canvas>().sortingOrder = 1;
        characterUI.GetComponentInChildren<Button>().onClick.AddListener(delegate { characterUI.SetActive(false); });

        //Set the script to the instance of the CharacterCanvas object, and then run the method in it.
        writer = prefabCharacterUI.GetComponent<CharacterStatWriter>();
        writer.GetStats(hp, str, def);

        //Create items
        foreach (Transform t in characterUI.transform) {
            if (t.tag == "ItemGrid") {
                itemGrid = t.gameObject;
            }
        }
        for (int x = 0; x < 6; x++)
            items.Add(Instantiate(ItemPrefab, itemGrid.transform));
        //GetComponent<CharacterScript>().LoadPlayer(GetComponent<CharacterScript>().id);
        for (int x = 0; x < GetComponent<CharacterScript>().itemID.Length; x++) {
            string itemId = GetComponent<CharacterScript>().itemID[x];
            if (itemId != null)
                items[x].GetComponent<ItemScript>().CreateItem(itemId);
        }
    }
    //Debug.Log("Str is " + str);
    //characterUI = Instantiate(prefabCharacterUI, new Vector3(0, 0, 0), Quaternion.identity);
    //characterUI.GetComponent<Canvas>().worldCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
    //characterUI.GetComponent<Canvas>().sortingOrder = 1;
    //characterUI.GetComponentInChildren<Button>().onClick.AddListener(delegate { characterUI.SetActive(false); });

    //Set the script to the instance of the CharacterCanvas object, and then run the method in it.
    //writer = prefabCharacterUI.GetComponent<CharacterStatWriter>();
    //foreach(string quirkId in quirkIDList)
    //{
    //    foreach(QuirkObject quirk in Assets.assets.quirkArray)
    //    {
    //        if(quirk.name == quirkId)
    //        {
    //            writer.GetStats(hp, str, def, Int, dex, cha, quirk.quirkName);
    //            break;
    //        }
    //    }


    //}
    //Configure items
    //int i = 0;
    //int j = 0;
    //    foreach (GameObject item in items) {
    //        item.GetComponent<ItemScript>().SetSlot(item.transform.position + new Vector3(0 + i* 0.6f, 0 - j* 0.6f, 0)); // + new Vector3(-2f + i * 0.5f, 2.1f - j * 0.5f, 0));//new Vector3(-2.2f + i*0.5f, 3.9f, 0));
    //        i++;
    //        if (i > 2) {
    //            i = 0;
    //            j++;
    //        }
    //    }
    //Create items
    //    foreach (Transform t in characterUI.transform)
    //    {
    //        if (t.tag == "ItemGrid")
    //        {
    //            itemGrid = t.gameObject;
    //        }
    //    }
    //    for (int x = 0; x < 6; x++)
    //        items.Add(Instantiate(ItemPrefab, itemGrid.transform));
    //    //GetComponent<CharacterScript>().LoadPlayer(GetComponent<CharacterScript>().id);
    //    for (int x = 0; x < GetComponent<CharacterScript>().itemID.Length; x++)
    //    {
    //        string itemId = GetComponent<CharacterScript>().itemID[x];
    //        if (itemId != null)
    //            items[x].GetComponent<ItemScript>().CreateItem(itemId);
    //    }

    //    //This is dumb, but CharacterCanvas is a canvas, so it's dumb.
    //    for (int x = 0; x < characterUI.transform.childCount; x++)
    //        characterUI.transform.GetChild(x).transform.position += new Vector3(-4f, 1.9f, 0);

    //    //Configure items
    //    int i = 0;
    //    int j = 0;
    //    foreach (GameObject item in items)
    //    {
    //        item.GetComponent<ItemScript>().SetSlot(item.transform.position + new Vector3(0 + i * 0.6f, 0 - j * 0.6f, 0)); // + new Vector3(-2f + i * 0.5f, 2.1f - j * 0.5f, 0));//new Vector3(-2.2f + i*0.5f, 3.9f, 0));
    //        i++;
    //        if (i > 2)
    //        {
    //            i = 0;
    //            j++;
    //        }
    //    }
    //}

    public int GetCost() {
        cost = (maxHp * 10) + (str * 3) + (def * 3);
        return cost;
    }

    public void BringUpStats() {
        //GetComponentInParent<AddToPlayerRoster>().controller.GetComponent<HubCharController>().CloseAllWindows();
        //characterUI.SetActive(true);
    }

    public void GetStats(int maxHp, int hp) { //Orkar inte skriva över alla stats... Senare kommer character scripts och stats vara samma script så detta steg kommer inte behövas!
        this.maxHp = maxHp;
        this.hp = hp;
    }

    public void AddQuirk(QuirkObject quirk) {
        if (quirkList == null) {
            InitiateList();
        }

        quirkList.Add(quirk);

        maxHp += quirk.hp;
        str += quirk.str;
        def += quirk.def;
        Int += quirk.Int;
        dex += quirk.dex;
        cha += quirk.cha;
        ldr += quirk.ldr;
    }

    void InitiateList() {

        quirkList = new List<QuirkObject>();
    }

    public void TakeDamage(int damage) {
        Instantiate(bloodEffect, transform.position, Quaternion.identity);
        int procentage = 100;
        int randomChance = 0;

        damage -= def;
        if (damage < 1) {
            damage = 1;
        }
        procentage -= dex;
        randomChance = Random.Range(0, 101);
        if (randomChance > procentage) {
            damage = 0;
            Debug.Log("success");
        }
        hp -= damage;
        if (hp < 0) {
            gameObject.SetActive(false);
        }
    }

    public void HealCharacter(int healAmount) {
        hp += healAmount;

        if (hp > maxHp) {
            hp = maxHp;
        }
    }

    public void LoadPlayer(Stats data) { //Vill ersätta detta med något som typ "this.stats = data" men vet inte hur...
        quirkIDList = data.quirkIDList;
        shit = data.shit;
        hp = data.hp;
        maxHp = data.maxHp;
        str = data.str;
        def = data.def;
        Int = data.Int;
        dex = data.dex;
        cha = data.cha;
        ldr = data.ldr;
        nrg = data.nrg;
        snt = data.snt;
        level = data.level;
        exp = data.exp;
        nextLevel = data.nextLevel;
    }
}
