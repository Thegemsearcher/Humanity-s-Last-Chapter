using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AppointedRoleScript : MonoBehaviour {

    public Text txtCharacterName, txtRoleName;
    public GameObject Portrait, btnAppoint, btnRemove;

    private bool isAppointed;

    private RoleObject role;
    private CharacterScript characterScript;
    private Stats stats;
    private GameObject Manager;
    private GameObject[] characters;

    public void GetRole(RoleObject role, GameObject Manager) {
        this.role = role;
        this.Manager = Manager;

        txtRoleName.text = role.roleName;

        //Kollar alla karaktärer ifall de har denna roll och ger portrait värden om det finns
        characters = GameObject.FindGameObjectsWithTag("Character");
        foreach (GameObject character in characters) {
            characterScript = character.GetComponent<CharacterScript>();
            if (characterScript.role == role) {
                stats = character.GetComponent<Stats>();
                isAppointed = true; //Håller koll på om knappen Appoint eller Remove ska visas
                Portrait.GetComponent<CharacterScript>().LoadPlayer(characterScript);
                Portrait.GetComponent<Stats>().LoadPlayer(stats);

                txtCharacterName.text = characterScript.strName;
            }
        }
        SetBtn(); //Ändrar så att rätt knapp visas (Appoint/Remove)
    }

    private void SetBtn() {
        if (isAppointed) {
            btnAppoint.SetActive(false);
            btnRemove.SetActive(true);
        } else {
            btnAppoint.SetActive(true);
            btnRemove.SetActive(false);
        }
    }

    public void BtnAppoint() {
        Manager.GetComponent<RoleManagerScript>().GetCharacters(gameObject);
    }

    public void BtnRemove() {
        characterScript.role = null;
        txtCharacterName.text = "";
        isAppointed = true;

        Portrait.transform.GetChild(0).gameObject.SetActive(false);
    }

    public void GetCharacter(GameObject character) {
        characterScript = character.GetComponent<CharacterScript>();
        stats = character.GetComponent<Stats>();

        characterScript.role = role;
        isAppointed = true;

        Portrait.GetComponent<CharacterScript>().LoadPlayer(characterScript);
        Portrait.GetComponent<Stats>().LoadPlayer(stats);
        Portrait.transform.GetChild(0).gameObject.SetActive(true);
        txtCharacterName.text = characterScript.strName;
        SetBtn();
    }
}
