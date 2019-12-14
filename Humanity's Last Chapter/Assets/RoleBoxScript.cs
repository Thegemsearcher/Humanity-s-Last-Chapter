using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoleBoxScript : MonoBehaviour {

    public Text txtName,txtRole, txtHp;
    public Scrollbar healthBar;
    public GameObject AppointBtn, Portrait;
    private GameObject Manager, Character;
    private GameObject[] characters;
    private RoleObject role;
    private CharacterScript characterScript;
    private Stats stats;
    private bool isAppointed, roleTaken;

    public void GetRole(RoleObject role, GameObject Manager) {
        this.role = role;
        this.Manager = Manager;

        roleTaken = false;
        characters = GameObject.FindGameObjectsWithTag("Character");
        foreach (GameObject character in characters) {
            characterScript = character.GetComponent<CharacterScript>();
            if (characterScript.role == role) {
                stats = character.GetComponent<Stats>();

                Portrait.GetComponent<CharacterScript>().LoadPlayer(characterScript);
                Portrait.GetComponent<Stats>().LoadPlayer(stats);

                SetStats();
                characterScript.isEnlisted = false;
                roleTaken = true;
                break;
            }
        }
        if (!roleTaken) {
            //Destroy(Portrait);
            EmptyRole();
        }
    }

    public void GetCharacter(GameObject Character, GameObject Manager) {
        this.Character = Character;
        this.Manager = Manager;

        characterScript = Character.GetComponent<CharacterScript>();
        stats = Character.GetComponent<Stats>();

        Portrait.GetComponent<CharacterScript>().LoadPlayer(characterScript);
        Portrait.GetComponent<Stats>().LoadPlayer(stats);

        role = characterScript.role;
        if (role != null) {
            txtRole.text = role.roleName;
        } else {
            txtRole.text = "-No Role-";
        }

        txtName.text = characterScript.title + characterScript.strName;

        SetStats();
        characterScript.isEnlisted = false;
    }

    private void EmptyRole() {
        txtName.text = "Role: " + role.roleName;
        txtHp.text = "";

        float barSize = 0;
        healthBar.size = barSize;
    }

    private void SetStats() {
        txtName.text = characterScript.title + characterScript.strName;
        txtHp.text = "Hp: " + stats.hp + "/" + stats.maxHp;

        float barSize = stats.maxHp / stats.hp;
        healthBar.size = barSize;
    }

    public void BtnAppoint() {
        if (stats != null) {
            if (isAppointed) {
                AppointBtn.GetComponent<Image>().color = Color.red;
                characterScript.isEnlisted = false;
                isAppointed = false;
                Manager.GetComponent<CommandCenterScript>().appointedCharacters--;
                //Göra karaktären notEnlisted
            } else {
                AppointBtn.GetComponent<Image>().color = Color.green;
                characterScript.isEnlisted = true;
                isAppointed = true;
                Manager.GetComponent<CommandCenterScript>().appointedCharacters++;
                //Göra karaktären enlisted
            }
            Manager.GetComponent<CommandCenterScript>().CheckMissionReady();
        }
    }

    public void BtnChangeRole() {
        Manager.GetComponent<CommandCenterScript>().ChangeRole(Character);
    }
}
 /* ToDo:
  * Klickar man på start ska det endast gå om karatärer som är appointed <= partySize
  * Endast de som är appointed kan gå på mission
  */
