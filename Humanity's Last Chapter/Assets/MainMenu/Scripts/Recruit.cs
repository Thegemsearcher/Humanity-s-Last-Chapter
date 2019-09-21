using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recruit : MonoBehaviour {
    GameObject characterManagerO, characterO;
    public GameObject character;

    void Start() { //Planen här är att den ska hitta alla filer med info i sig o skapa en karaktär av den
        //Tror det behövs instantiate en karaktär men vet inte hur många som kommer behövas

        //for (int i = 0; i <= 20; i++) { //20 ska sen ändras till antalet filer som finns i /character
        //    characterO.GetComponent<CharacterScript>().LoadPlayer(i);
        //}
    }

    public void RecruitCharacter() {
        characterO = Instantiate(character, new Vector2(100, 200), Quaternion.identity) as GameObject;
        characterO.transform.parent = GameObject.Find("CharacterManager").transform; //Lägger in objectet i CharacterManager för att lättar ha koll på de
    }
}
