using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class btnAppointScript : MonoBehaviour { //Borde heta RoleManager

    public GameObject partyView, btnAppointO, btnRemoveO;
    public int role;
    private bool isAppointed;

    private void Start() {
        isAppointed = false;
    }

    public void btnAppoint() {
        partyView.GetComponent<partySelectorScript>().AppointCharacter(role);
        isAppointed = true;
        ShowBtn();
    }

    public void btnRemove() {
        partyView.GetComponent<partySelectorScript>().RemoveCharacter(role);
        isAppointed = false;
        ShowBtn();
    }

    public void ShowBtn() {
        if(isAppointed) {
            btnAppointO.SetActive(false);
            btnRemoveO.SetActive(true);
        }
        else {
            btnAppointO.SetActive(true);
            btnRemoveO.SetActive(false);
        }
    }
}
