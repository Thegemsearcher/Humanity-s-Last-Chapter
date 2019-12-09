using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AppointCharacterScript : MonoBehaviour {

    public Text characterName;
    public GameObject Portrait;
    private GameObject Character, Manager;
    private CharacterScript characterScript;
    private Stats stats;

    public void GetCharacter(GameObject Character, GameObject Manager) {
        this.Character = Character;
        this.Manager = Manager;

        characterScript = Character.GetComponent<CharacterScript>();
        stats = Character.GetComponent<Stats>();

        characterName.text = characterScript.strName;

        Portrait.GetComponent<CharacterScript>().LoadPlayer(characterScript);
        Portrait.GetComponent<Stats>().LoadPlayer(stats);
    }

    public void BtnAppoint() {
        Manager.GetComponent<RoleManagerScript>().SetRole(Character);
    }
}
