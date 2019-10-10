using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.UI;

public class LoadWorld : MonoBehaviour {
    GameObject characterO;
    public GameObject character;
    int characterCounter;
    private Vector2 characterPos;

    public List<ScriptableQuest> questList; //Har alla quests som mall

    private List<CharacterScript> characterList;
    private List<stats> statsList;
    private List<ScriptableQuest> progressList; //Ändrar bools i quest som t.ex. isActive eller isComplete
    private WorldScript worldScript;

    void Start() {


        characterPos = new Vector2(0, 210);
        if (!Directory.Exists(Application.persistentDataPath + "/Characters") || !Directory.Exists(Application.persistentDataPath + "/Party")) {
            BinaryFormatter formatter = new BinaryFormatter();
            string path = Application.persistentDataPath; //vi behöver något sätt att se till att de inte sparar över varandra.. tänkte använda id men det blir ju också raderat
            Directory.CreateDirectory(path + "/Party");
            Directory.CreateDirectory(path + "/Characters");
        } else {
            characterCounter = Directory.GetFiles(Application.persistentDataPath + "/Characters/").Length;
            for (int i = 0; i < characterCounter; i++) { //Gör vi såhär så raderar vi inte character utan kanske har en bool som säger om de ska visas eller inte
                characterO = Instantiate(character, characterPos, Quaternion.identity) as GameObject;
                characterO.transform.SetParent(GameObject.FindGameObjectWithTag("CharacterManager").transform, false);
                characterO.GetComponent<UIBoiScript>().isOwned = true;
                characterO.GetComponent<CharacterScript>().LoadPlayer(i);

                characterPos.y -= 105;
            }
        }
        
        //LoadData();
        //foreach(CharacterScript characterScript in characterList) {
        //    characterO = Instantiate(character);
        //    characterO.GetComponent<CharacterScript>().
        //}


    }
    public void LoadData() {
        SaveData data = SaveSystem.LoadWorld(worldScript.saveSlot); //Den behöver få saveSlot tidigare... tror man bara rakt ut kan skicka den från den tidigare scenen
        characterList = data.characterList;
        statsList = data.statsList;
        progressList = data.questList;
        worldScript = data.world;
    }

    public void SaveData() {
        SaveSystem.SaveWorld(characterList, statsList, progressList, worldScript);
    }

    //CharacterList och statsList ska sen vara samma List
    //QuestList ska innehålla status på alla quest, active, complete etc etc
    //WorldScript innehåller alla resurser man har, itemStorage?

}
