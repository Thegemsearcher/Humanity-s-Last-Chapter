using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class roasterScript : MonoBehaviour {

    public GameObject character, barrackWindow;
    private GameObject characterO;
    private int rand;
    private Vector3 roasterPos;

    private void Start() {
        roasterPos = new Vector3(-310, 120, 1); //sjukt fult måste göras snyggare!
        rand = Random.Range(4, 6); //tycker vi senare ska ha denna på ett annat sätt
        for (int i = 0; i < rand; i++) {
            if (i == 4) {
                roasterPos.y = 120;
                roasterPos.x += 370;
            }
            characterO = Instantiate(character, roasterPos, Quaternion.identity);
            characterO.transform.SetParent(barrackWindow.transform, false);
            characterO.transform.localScale.Scale(new Vector3(1, 1, 1));
            characterO.GetComponent<HireCharacter>().cost = 20;
            characterO.GetComponent<HireCharacter>().ShowBTN();
            characterO.GetComponent<UIBoiScript>().isOwned = false;
            roasterPos.y -= 105;
        }
    }
   
}
