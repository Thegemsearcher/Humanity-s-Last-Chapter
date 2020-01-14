using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeShop : MonoBehaviour {

    public Text txtLevel;
    public int upgradeCost;
    public int shopLevel;

    void Start() {
        shopLevel = WorldScript.world.shopLevel;
        txtLevel.text = "Shop Level: " + shopLevel;
    }

    public void BtnUpgrade() {
        if (upgradeCost * shopLevel <= WorldScript.world.gold) {
            WorldScript.world.gold -= upgradeCost * shopLevel;
            WorldScript.world.shopSize += 3;
            WorldScript.world.shopLevel += 1;

            shopLevel = WorldScript.world.shopLevel;
            txtLevel.text = "Shop Level: " + shopLevel;
        }
        
    }
}
