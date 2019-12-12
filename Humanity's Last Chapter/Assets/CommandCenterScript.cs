using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandCenterScript : MonoBehaviour {

    public GameObject ForMission, ForRoles, ForCharacterChange, MissionBox, CharacterBox, RoleBox, AppointedRole;
    private GameObject holder, CharacterToAlter;
    private GameObject[] characters;
    private List<GameObject> characterList;
    public RoleObject citizenRole;

    private void Start() {
        characterList = new List<GameObject>();
        CreateQuestList();
        CreateCharacterList();
    }

    private void CreateQuestList() {
        foreach (ScriptableQuest quest in WorldScript.world.avalibleQuests) {
            holder = Instantiate(MissionBox);
            holder.GetComponent<MissionBoxScript>().GetQuest(quest);
            holder.transform.SetParent(ForMission.transform, false);
        }
    }

    private void ClearRoleList() {
        foreach (Transform child in ForRoles.transform) {
            Destroy(child.gameObject);
        }
    }

    public void CreateCharacterList() {
        ClearRoleList();

        foreach (Transform child in ForCharacterChange.transform) {
            Destroy(child.gameObject);
        }

        if (characters == null) {
            characters = GameObject.FindGameObjectsWithTag("Character");
        }

        foreach (GameObject character in characters) {
            holder = Instantiate(RoleBox);
            if (character.GetComponent<CharacterScript>().role == null) {
                character.GetComponent<CharacterScript>().role = citizenRole;
            }

            holder.GetComponent<RoleBoxScript>().GetCharacter(character, gameObject);
            holder.transform.SetParent(ForRoles.transform, false);
        }
    }

    public void CreateRoleList() {
        ClearRoleList();
        characterList.Clear();

        if (characters == null) {
            characters = GameObject.FindGameObjectsWithTag("Character");
        }

        foreach (GameObject character in characters) {
            characterList.Add(character);
        }

        foreach (RoleObject role in WorldScript.world.activeRoles) {
            holder = Instantiate(AppointedRole);
            holder.transform.SetParent(ForRoles.transform, false);
            holder.GetComponent<AppointedRoleScript>().GetRole(role, gameObject);

            foreach (GameObject character in characterList) {                           //Förbereder för att kolla om det finns någon karaktär med den rollen
                if (character.GetComponent<CharacterScript>().role == role) {           //Om det finns en karaktär med den rollen kommer den att ge rollen karaktären och ta bort karaktären 
                    holder.GetComponent<AppointedRoleScript>().GetCharacter(character); //från listan så att samma karaktär inte kan få mer än en roll
                    if (character == CharacterToAlter) {
                        Destroy(holder);
                    }
                    characterList.Remove(character);
                    break;
                }
            }
        }
    }
    public void ChangeRole(GameObject Character) {  //När man klickar på knappen BtnChangeRole i RoleBox kommer karaktären att sparas som CharacterToAlter för att sen kunna ändras samt
        CharacterToAlter = Character;               //ändras det så att man ser roller och inte karaktärer
        holder = Instantiate(CharacterBox);
        holder.GetComponent<CharacterToAppoint>().GetCharacter(Character, gameObject);
        holder.transform.SetParent(ForCharacterChange.transform, false);

        CreateRoleList();
    }

    public void SetRole(RoleObject role) {
        //if (oldCharacter != null) {     //Om det fanns en karaktär på rollen man väljer ändras den till citizenRole
        //    oldCharacter.GetComponent<CharacterScript>().role = citizenRole;
        //}
        CharacterToAlter.GetComponent<RoleScript>().ChangeRole(role);   //Ändrar rollen på den man klickade på till den nya rollen

        CreateCharacterList();  //Tar tillbaka så att man ser karaktärena igen
    }

    public void SwitchRole(RoleObject role, GameObject oldCharacter) {  //Om man kilckar på knappen AlterCharacter (Dyker upp om rollen redan används)
        oldCharacter.GetComponent<RoleScript>().ChangeRole(CharacterToAlter.GetComponent<CharacterScript>().role);  //Sätter den som hade rollen redan så att den får den nya rollen
        CharacterToAlter.GetComponent<RoleScript>().ChangeRole(role);   //Ger den man skulle ändra roll på så att den får den nya rollen
        CreateCharacterList();
    }

    public void Regrates() {    //Om man klickar på knappen Return istället för att ändra roll (Ändrar inte roll)
        CharacterToAlter = null;
        CreateCharacterList();
    }

    public void BtnExit() {
        Destroy(gameObject);
    }
}
