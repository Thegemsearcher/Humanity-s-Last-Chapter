using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopScript : MonoBehaviour {

    private HealingItemObject[] hio;
    private CombatItemObject[] cio;
    private WeaponObject[] wpo;

    public Text txtDescName, txtDescDesc; //Info rutornas text i StorageWindow

    private GameObject[] shopSlots, itemSlots, shopArr;
    private GameObject LoadManager, ItemO, ShopParent, InventoryParent, slotO;
    public Text txtGold, txtName, txtDesc, txtCost;
    private string strGold, strName, strDesc, strCost;
    private string[] strShopArr, strInventoryArr;
    private List<Object> itemIDO;

    private ShopSlotScript sss;
    private ItemInfo itemInfo;
    public GameObject ItemSlot, shopItem;
    public int slotsCounter;

    private void Start() {

        AddToID();

        ShopParent = GameObject.FindGameObjectWithTag("ForStoreStorage");
        for (int i = 0; i < slotsCounter; i++) {
            slotO = Instantiate(ItemSlot, ShopParent.transform);
            slotO.tag = "StoreSlot";
        }

        InventoryParent = GameObject.FindGameObjectWithTag("ForItemStorage");
        for (int i = 0; i < WorldScript.world.storageSize; i++) {
            slotO = Instantiate(ItemSlot, InventoryParent.transform);
            slotO.tag = "ItemSlot";
        }

        shopSlots = GameObject.FindGameObjectsWithTag("StoreSlot");
        itemSlots = GameObject.FindGameObjectsWithTag("ItemSlot");
        LoadManager = GameObject.FindGameObjectWithTag("LoadManager");
        //LoadManager.GetComponent<CreateItems>().FillSlots(WorldScript.world.shopArr, shopSlots);

        txtName.text = "";
        txtDesc.text = "";
        txtCost.text = "";
        txtGold.text = "Gold: " + WorldScript.world.gold;

        strShopArr = WorldScript.world.shopArr;
        strInventoryArr = WorldScript.world.storageArr;
        FillShop(strShopArr, shopSlots);
        FillShop(strInventoryArr, itemSlots);
    }

    private void Update() {
        strGold = "Gold: " + WorldScript.world.gold;
        txtGold.text = strGold;

    }
    public void UpdateList() {
        strShopArr = WorldScript.world.shopArr;
        strInventoryArr = WorldScript.world.storageArr;
        FillShop(strShopArr, shopSlots);
        FillShop(strInventoryArr, itemSlots);
    }

    public void GetInfo(string strName, string strDesc, int cost) {
        txtName.text = strName;
        txtDesc.text = strDesc;
        txtCost.text = "Cost: " + cost;
    }

    public void ResetInfo() {
        txtName.text = "";
        txtDesc.text = "";
        txtCost.text = "Cost: ";
    }

    private void AddToID() {
        itemIDO = new List<Object>();
        hio = Assets.assets.healingTemp;
        cio = Assets.assets.combatTemp;
        wpo = Assets.assets.weaponTemp;

        for (int i = 0; i < hio.Length; i++) {
            itemIDO.Add(hio[i]);
        }
        for (int i = 0; i < cio.Length; i++) {
            itemIDO.Add(cio[i]);
        }
        for (int i = 0; i < wpo.Length; i++) {
            itemIDO.Add(wpo[i]);
        }
    }

    private void FillShop(string[] inventory, GameObject[] shopSlots) {
        for (int i = 0; i < inventory.Length; i++) {
            if(inventory[i] != "") {
                sss = shopSlots[i].GetComponent<ShopSlotScript>();
                switch (inventory[i][0]) {
                    case 'h':
                        foreach (HealingItemObject healingItem in hio) {
                            if (healingItem.name == inventory[i]) {
                                ItemO = Instantiate(shopItem, shopSlots[i].transform);
                                itemInfo = ItemO.GetComponent<ItemInfo>();
                                itemInfo.GetData(healingItem.texture, healingItem.itemName, healingItem.description, healingItem.name, healingItem.cost, txtDescName, txtDescDesc);
                                sss.GetItem(itemInfo.strName, itemInfo.strDesc, inventory[i], itemInfo.cost, i, gameObject);
                                break;
                            }
                        }
                        break;
                    case 'c':
                        foreach (CombatItemObject combatItem in cio) {
                            if (combatItem.name == inventory[i]) {
                                ItemO = Instantiate(shopItem, shopSlots[i].transform);
                                itemInfo = ItemO.GetComponent<ItemInfo>();
                                itemInfo.GetData(combatItem.icon, combatItem.itemName, combatItem.description, combatItem.name, combatItem.cost, txtDescName, txtDescDesc);
                                sss.GetItem(itemInfo.strName, itemInfo.strDesc, inventory[i], itemInfo.cost, i, gameObject);
                                break;
                            }
                        }
                        break;
                    case 'w':
                        foreach (WeaponObject weapon in wpo) {
                            if (weapon.name == inventory[i]) {
                                ItemO = Instantiate(shopItem, shopSlots[i].transform);
                                itemInfo = ItemO.GetComponent<ItemInfo>();
                                itemInfo.GetData(weapon.sprite, weapon.weaponName, weapon.description, weapon.name, weapon.cost, txtDescName, txtDescDesc);
                                sss.GetItem(itemInfo.strName, itemInfo.strDesc, inventory[i], itemInfo.cost, i, gameObject);
                                break;
                            }
                        }
                        break;
                }
                
            }
        }
    }
}
