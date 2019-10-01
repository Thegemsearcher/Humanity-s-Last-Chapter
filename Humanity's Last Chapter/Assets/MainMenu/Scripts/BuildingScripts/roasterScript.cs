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
        roasterPos = new Vector3(-280, 100, 1); //sjukt fult måste göras snyggare!
        rand = Random.Range(4, 5); //tycker vi senare ska ha denna på ett annat sätt
        for (int i = 0; i < rand; i++) {
            if (i == 4) {
                roasterPos.y = 100;
                roasterPos.x += 250;
            }
            characterO = Instantiate(character, roasterPos, Quaternion.identity);
            characterO.transform.SetParent(parent.transform, false);
            characterO.transform.localScale.Scale(new Vector3(1, 1, 1));
            roasterPos.y -= 100;

            
        }
    }
   
}
