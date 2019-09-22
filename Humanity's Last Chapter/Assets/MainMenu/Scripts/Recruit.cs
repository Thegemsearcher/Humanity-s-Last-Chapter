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

    public void RecruitCharacter() {//OBS! med en positionen kommer dom aldrig hamna i närheten av skärmen
                                    //OBSOBS! om du försöker använda det här för att skapa karaktärerna i huben när dom kommer tillbaks från ett mission 
                                            //så kan du istället använda CampScript.CreateCharacter (den kanske måste modifieras lite men det är lättare så )
        characterO = Instantiate(character, new Vector2(100, 200), Quaternion.identity) as GameObject;
        characterO.transform.parent = GameObject.Find("CharacterManager").transform; //Lägger in objectet i CharacterManager för att lättar ha koll på de
    }
}
