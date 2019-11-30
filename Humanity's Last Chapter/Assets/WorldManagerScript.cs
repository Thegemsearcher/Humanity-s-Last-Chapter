using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldManagerScript : MonoBehaviour {

    public GameObject pauseMenu, parent;
    private GameObject holder;
    private bool isMenuUp;

    void Update() {
        if (holder == null) {
            if (Input.GetKeyDown(KeyCode.Escape)) {
                holder = Instantiate(pauseMenu);
                holder.transform.SetParent(parent.transform, false);
            }
        }
    }
}
