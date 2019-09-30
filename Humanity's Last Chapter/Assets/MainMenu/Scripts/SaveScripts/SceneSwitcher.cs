using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour {
    private GameObject[] charactersO;
    private GameObject selectPartyView;

    public void GoToHub() {
        charactersO = GameObject.FindGameObjectsWithTag("Character");
        foreach (GameObject go in charactersO) {
            go.GetComponent<CharacterScript>().SavePlayer();
        }
        SceneManager.LoadScene("Main");
    }
    public void GoToMission() {
        Debug.Log("Does it get here?");
        //Sparar alla karaktärer
        charactersO = GameObject.FindGameObjectsWithTag("Character");
        foreach(GameObject go in charactersO) {
            go.GetComponent<CharacterScript>().SavePlayer();
        }

        //sparar vilka som ska gå på mission
        selectPartyView = GameObject.FindGameObjectWithTag("PartyView");
        SaveSystem.SavePartyOrder(selectPartyView.GetComponent<partySelectorScript>().missionParty);

        SceneManager.LoadScene("MissionMap");
    }
}
