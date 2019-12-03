using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour {

    public void GoToHub() {
        WorldScript.world.date++;
        WorldScript.world.FillShop();
        WorldScript.world.Save(true);
        SceneManager.LoadScene("Hub");
    }
    public void GoToMission() {
        WorldScript.world.Save(true);
        SceneManager.LoadScene("MissionMap");
    }
}
