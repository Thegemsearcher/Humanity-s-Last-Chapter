using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEditor;
using UnityEngine.UI;

public class LoadWorld : MonoBehaviour { //Heta LoadHub?
    private GameObject holder;
    public GameObject character, CampName, CreationWindow, WindowParent;
    public List<ScriptableQuest> startQuests;
    private Vector2 characterPos;
    private string path;
    private int randomQuirk;


    private Transform transParent;

    private GameObject[] characterArr; //Används som en holder för att hålla alla karaktärer som finns så den kan spara dem  
    private List<CharacterScript> characterScriptList;  //Håller alla characterScripts som finns i sparfilen
    private List<Stats> statsList;  //Håller alla stats som finns i sparfilen
    
    void Start() {

        InstantiateLists(); //Skapar alla listor, kan man ha den som awake?
        if(Assets.assets == null) {
            Assets.assets = new Assets();
            Assets.assets.GetAssets();
        }

        if (WorldScript.world == null) {                                    //Kollar om det finns en world (Om true är det ett nytt sparning)
            WorldScript.world = new WorldScript();
            WorldScript.world.Reset();                                      //Sätter startvärden på spelet (t.ex. hur mycket guld man startar med etc)

            foreach (ScriptableQuest quest in startQuests) {
                WorldScript.world.avalibleQuests.Add(quest);                //De quests man har satt in i startQuests kommer in som valbara quests
            }
        } else {
            LoadCharacters();
        }
        if (WorldScript.world.isNewGame) {
            holder = Instantiate(CreationWindow);                           //Skapar fönstret där man kan skapa de tre första karaktärena
            holder.transform.SetParent(WindowParent.transform, false);
            WorldScript.world.isNewGame = false;
        }
        CampName.GetComponent<CommunityTitle>().title.text = WorldScript.world.saveName;
    }

    public void LoadCharacters() { //Ser till att alla karaktärer ritas ut med rätt världen
        characterScriptList = WorldScript.world.characterList;
        statsList = WorldScript.world.statsList;
        //Debug.Log("Ch script has length: " + characterScriptList.Count + "and statsList have Length: " + statsList.Count);
        transParent = GameObject.FindGameObjectWithTag("CharacterManager").transform;
        int i = 0;
        foreach (CharacterScript characterScript in characterScriptList) {
            holder = Instantiate(character);
            holder.GetComponent<CharacterScript>().LoadPlayer(characterScript);
            holder.GetComponent<Stats>().LoadPlayer(statsList[i]);
            holder.GetComponent<CharacterScript>().isEnlisted = false;
            //randomQuirk = Random.Range(0, 9);   //picks out the quirk.
            //randomQuirk *= 2;
            //characterO.GetComponent<Stats>().AddQuirk(Assets.assets.quirkArray[randomQuirk]);
            //statsList.Remove(statsList[i]);
            holder.transform.SetParent(transParent, false);
            i++;
            
        }
        characterScriptList.Clear(); //Rensar listan
    }

    private void InstantiateLists() {
        characterScriptList = new List<CharacterScript>();
        statsList = new List<Stats>();
    }
}
