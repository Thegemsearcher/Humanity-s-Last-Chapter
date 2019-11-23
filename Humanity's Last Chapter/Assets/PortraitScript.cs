using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortraitScript : MonoBehaviour {

    public GameObject Cloth;
    private CharacterScript characterScript;

    private void Start() {
        characterScript = GetComponent<CharacterScript>();

        //Kod för att ändra kläder från characterScript;


    }
}
