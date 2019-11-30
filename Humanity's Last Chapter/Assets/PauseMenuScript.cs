using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuScript : MonoBehaviour {

    public GameObject saveWindow;
    private GameObject holder;
    private Transform parent;

    private void Start() {
        parent = transform.parent;
    }

    public void BtnSave() {
        holder = Instantiate(saveWindow);
        holder.transform.SetParent(parent, false);
        Destroy(gameObject);
    }

    public void BtnResume() {
        Destroy(gameObject);
    }

    public void BtnQuit() {
        WorldScript.world.Save(true);
        Application.Quit();
    }

    public void BtnMainMenu() {
        SceneManager.LoadScene("SaveScreen");
    }
}
