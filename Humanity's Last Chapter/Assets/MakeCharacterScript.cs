using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MakeCharacterScript : MonoBehaviour {

    public InputField characterName;
    private CharacterScript characterScript;

    private void Start() {
        characterScript = GetComponent<CharacterScript>();
        characterName.text = characterScript.strName;
    }

    public void BtnNextCloth() {

    }
}
