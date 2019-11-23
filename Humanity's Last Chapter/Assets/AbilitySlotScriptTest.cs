using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilitySlotScriptTest : MonoBehaviour {
    public KeyCode BoundKey;
    public GameObject AttachedAbility;
    private GameObject holder;

    public void GetAbility(GameObject AttachedAbility, Sprite icon) {
        this.AttachedAbility = AttachedAbility;
    }
    
    void Update() {
        if (Input.GetKeyDown(BoundKey)) {
            Activate();
        }
    }

    public void Activate() {
        if (AttachedAbility == null)
            return;
        else {
            holder = Instantiate(AttachedAbility);
            AttachedAbility.transform.SetParent(gameObject.transform, false);
        }


        //AttachedAbility.GetComponent<AbilityScript>().Activate();
    }
}