using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingAbility : MonoBehaviour {
    private HealingItemObject healingItem;
    private GameObject Character;
    public KeyCode BoundKey;
    private bool isActive;

    private float coolDown, timeStamp;

    public void GetData(HealingItemObject healingItem, GameObject Character) {
        if(healingItem != null) {
            isActive = true;
            this.Character = Character;
            this.healingItem = healingItem;

            coolDown = healingItem.cooldownTimer;
            timeStamp = coolDown; //Börjar så att man kan använda den dirr
        } else {
            isActive = false;
        }
        
    }

    void Update() {
        //Debug.Log("healingItem: ");
        if (isActive) {
            //Debug.Log("Does it get here?");
            timeStamp += Time.deltaTime;

            if (Input.GetKeyDown(BoundKey)) {
                Activate();
            }
        }
        
    }

    public void Activate() {
        
        if (isActive) {
            if (timeStamp >= coolDown) {
                timeStamp = 0; //resetar timern
                
                Character.GetComponent<Stats>().HealCharacter(healingItem.healPower);
            }
        }
    }
}
