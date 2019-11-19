using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilitySlotScript : MonoBehaviour
{
    public KeyCode BoundKey;
    public GameObject AttachedAbility;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (AttachedAbility == null)
        //    return;
        if (Input.GetKeyDown(BoundKey))
        {
            Activate();
        }
    }

    public void Activate()
    {
        Debug.Log(BoundKey + " Activated");
        if (AttachedAbility == null)
            return;
        AttachedAbility.GetComponent<AbilityScript>().Activate();
    }
}
