using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour {
    GameObject[] charactersO;

    public void GoToHub() {
        SceneManager.LoadScene("Main");
    }
    public void GoToMission() {
        charactersO = GameObject.FindGameObjectsWithTag("Character");
        foreach(GameObject go in charactersO) {
            go.GetComponent<CharacterScript>().SavePlayer();
        }
        SceneManager.LoadScene("MissionMap");
    }
}
