using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public void GoToHub() {
        SceneManager.LoadScene("Main");
    }
    public void GoToMission() {
        SceneManager.LoadScene("MissionMap");
    }
}
