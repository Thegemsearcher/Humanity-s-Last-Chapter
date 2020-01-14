using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrackWindow : MonoBehaviour {

    private GameObject holder;

    private void Start() {
        foreach (GameObject character in WorldScript.world.BarrackPepList) {
            holder = Instantiate(character);
            holder.GetComponent<HireCharacter>().WorldObject = character;
            holder.transform.SetParent(gameObject.transform, false);
        }
    }

    public void BtnExit() {
        Destroy(gameObject);
    }
}
