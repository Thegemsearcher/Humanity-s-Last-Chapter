using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealingAbility : MonoBehaviour {

    public KeyCode BoundKey;
    public Sprite defultSprite;
    private HealingItemObject healingItem;
    private GameObject Character;
    private bool isReady;

    private void Start() {
        healingItem = null;
    }

    public void GetItem(GameObject Character) {
        this.Character = Character;
        healingItem = Character.GetComponent<Abilities>().healingItem;
        if (healingItem != null) {
            GetComponent<Image>().sprite = healingItem.sprite;
        } else {
            GetComponent<Image>().sprite = defultSprite;
        }
        
    }

    private void Update() {
        if(Character != null) {
            isReady = Character.GetComponent<Abilities>().healingReady;
            if (!isReady) {
                GetComponent<Image>().color = Color.gray;
            } else {
                GetComponent<Image>().color = Color.white;
                if (Input.GetKeyDown(BoundKey)) {
                    Activate();
                }
            }
            
        }
    }

    public void Activate() {
        if(isReady) {
            Debug.Log("Character name: " + Character.GetComponent<CharacterScript>().strName);
            Character.GetComponent<Abilities>().healingReady = false; //Ska flyttas till mer passande plats
            Character.GetComponent<Stats>().HealCharacter(healingItem.healPower);
        }
    }
}
