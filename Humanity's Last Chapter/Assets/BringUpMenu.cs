using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BringUpMenu : MonoBehaviour {

    public GameObject Menu, hub;
    private GameObject holder;

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            holder = Instantiate(Menu, gameObject.transform);
            holder.GetComponent<PauseMenuScript>().GetHub(hub);
            hub.SetActive(false);
        }
    }
}
