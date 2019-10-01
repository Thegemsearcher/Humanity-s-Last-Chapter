using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class roasterScript : MonoBehaviour {

    public GameObject character;
    private GameObject characterO;
    private int rand;
    private float conterverter;
    private Vector3 roasterPos;

    private void Start() {
    }

    public void CreateRoaster(GameObject parent) {
        conterverter = 78.55004f;
        roasterPos = new Vector3(-3.8f, 1.23f, 1); //sjukt fult måste göras snyggare!
        rand = Random.Range(4, 5); //tycker vi senare ska ha denna på ett annat sätt
        for (int i = 0; i < rand; i++) {
            if (i == 3) {
                roasterPos.y = 1.23f;
                roasterPos.x += 250 / conterverter;
            }
            characterO = Instantiate(character, roasterPos, Quaternion.identity);
            characterO.transform.SetParent(parent.transform, false);
            characterO.transform.localScale.Scale(new Vector3(0.01f, 0.01f, 0.01f));
            roasterPos.y -= 120/conterverter;

            
        }
    }
   
}
