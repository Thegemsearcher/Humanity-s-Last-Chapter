using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoleBoxScript : MonoBehaviour {

    public Text txtName, txtStr, txtDef, txtDex, txtLdr, txtHp;
    public Scrollbar healthBar;
    public GameObject AppointBtn, Portrait;
    private GameObject[] characters;
    private RoleObject role;
    private CharacterScript characterScript;
    private Stats stats;
    private bool isAppointed, roleTaken;

    public void GetRole(RoleObject role) {
        this.role = role;
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

    private void EmptyRole() {
        txtName.text = "Role: " + role.roleName;
        txtStr.text = "";
        txtDef.text = "";
        txtDex.text = "";
        txtLdr.text = "";
        txtHp.text = "";

        float barSize = 0;
        healthBar.size = barSize;
    }

    private void SetStats() {
        txtName.text = characterScript.title + characterScript.strName;
        txtStr.text = "Str: " + stats.str;
        txtDef.text = "Def: " + stats.def;
        txtDex.text = "Dex: " + stats.dex;
        txtLdr.text = "Ldr: " + stats.ldr;
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
                //Göra karaktären notEnlisted
            } else {
                AppointBtn.GetComponent<Image>().color = Color.green;
                characterScript.isEnlisted = true;
                isAppointed = true;
                //Göra karaktären enlisted
            }
        }
        

    }
}
 /* ToDo:
  * Klickar man på start ska det endast gå om karatärer som är appointed <= partySize
  * Endast de som är appointed kan gå på mission
  */
