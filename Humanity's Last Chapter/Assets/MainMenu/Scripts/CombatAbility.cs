using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CombatAbility : MonoBehaviour {

    public KeyCode BoundKey;
    public Sprite defultSprite;
    private GameObject Character;
    private CombatItemObject combatItem;
    private bool isReady;

    public void GetItem(GameObject Character) {
        this.Character = Character;
        combatItem = Character.GetComponent<Abilities>().combatItem;
        if (combatItem != null) {
            GetComponent<Image>().sprite = combatItem.sprite;
        } else {
            GetComponent<Image>().sprite = defultSprite;
        }
    }

    private void Update() {
        if (Character != null) {
            if (!isReady) {
                isReady = Character.GetComponent<Abilities>().healingReady;
                GetComponent<Image>().color = Color.gray;
            } else {
                GetComponent<Image>().color = Color.white;
                if(Input.GetKeyDown(BoundKey)) {
                    Activate();
                }
            }
        }
    }

    private void Activate() {

    }
}
