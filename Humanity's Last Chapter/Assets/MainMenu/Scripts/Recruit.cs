using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Recruit : MonoBehaviour {
    GameObject characterManagerO, characterO;
    public GameObject character;
    CharacterScript characterS;
    int characterCounter;

    //string info = new DirectoryInfo(Application.persistentDataPath + "/characters/");
    

    void Start() { //Planen här är att den ska hitta alla filer med info i sig o skapa en karaktär av den
        //Tror det behövs instantiate en karaktär men vet inte hur många som kommer behövas

        characterCounter = System.IO.Directory.GetFiles(Application.persistentDataPath + "/Characters/").Length;
        for (int i = 0; i < characterCounter; i++) { //Gör vi såhär så raderar vi inte character utan kanske har en bool som säger om de ska visas eller inte
            characterO = Instantiate(character, new Vector2(0, 0), Quaternion.identity) as GameObject;
            characterO.transform.parent = GameObject.Find("CharacterManager").transform;
            characterO.GetComponent<CharacterScript>().LoadPlayer(i);
        }
        //foreach (string file in System.IO.Directory.GetFiles(Application.persistentDataPath + "/characters/")) {
        //    characterO = Instantiate(character, new Vector2(-5, -5), Quaternion.identity) as GameObject;
        //    characterO.transform.parent = GameObject.Find("CharacterManager").transform;
        //    characterO.
        //}
    }

    public void RecruitCharacter() {//OBS! med en positionen kommer dom aldrig hamna i närheten av skärmen
                                    //OBSOBS! om du försöker använda det här för att skapa karaktärerna i huben när dom kommer tillbaks från ett mission 
                                            //så kan du istället använda CampScript.CreateCharacter (den kanske måste modifieras lite men det är lättare                         så )
        characterO = Instantiate(character, new Vector2(-5, -5), Quaternion.identity) as GameObject;
        characterO.transform.parent = GameObject.Find("CharacterManager").transform; //Lägger in objectet i CharacterManager för att lättar ha koll på de
    }
}
