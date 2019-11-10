using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEditor;
using UnityEngine.UI;

public class LoadWorld : MonoBehaviour { //Heta LoadHub?
    private GameObject characterO;
    public GameObject character;
    private Vector2 characterPos;
    private string path;
    private int randomQuirk;

    private Transform transParent;

    private GameObject[] characterArr; //Används som en holder för att hålla alla karaktärer som finns så den kan spara dem  
    private List<CharacterScript> characterScriptList;  //Håller alla characterScripts som finns i sparfilen
    private List<Stats> statsList;  //Håller alla stats som finns i sparfilen
    //private WorldScript worldScript;    //Håller questProgression och pengar som finns i sparfilen

    //Assets
    public ScriptableQuest[] questTemp; //Har alla quests som mall
    public WeaponObject[] weaponTemp;
    public ScriptableCollection[] coTemp;
    public LocationObject[] loTemp;
    public InteractObject[] ioTemp;

    public QuirkObject[] quirkArray;

    void Start() {
        GetAssets(); //Får alla assets

        InstantiateLists(); //Skapar alla listor, kan man ha den som awake?

        if (WorldScript.world == null) { //Kollar om det finns en world (Borde bara vara falsk om man startar nytt game eller startar från hubben dirr)
            WorldScript.world = new WorldScript();
            WorldScript.world.Reset();
        } else {
            LoadCharacters();
        }
        randomQuirk = Random.Range(0, 10);   //Just for show.

        //path = Application.persistentDataPath;
        //if (!Directory.Exists(path + "/Saves")) { //Kollar om foldern Saves finns
        //    Directory.CreateDirectory(path + "/Saves");
        //}

        //if (Directory.Exists(path + "/Saves/save" + 0 + ".txt")) { //Om sparfilen finns laddar den sparfilen
        //    //LoadData();
        //}

    }
    public void LoadCharacters() { //Ser till att alla karaktärer ritas ut med rätt världen
        characterScriptList = WorldScript.world.characterList;
        statsList = WorldScript.world.statsList;

        Debug.Log("CharacterLenght(Load World): " + characterScriptList.Count);

        transParent = GameObject.FindGameObjectWithTag("CharacterManager").transform;
        foreach (CharacterScript characterScript in characterScriptList) {
            characterO = Instantiate(character);
            characterO.GetComponent<CharacterScript>().LoadPlayer(characterScript);
            characterO.GetComponent<Stats>().LoadPlayer(statsList[0]);
            statsList.Remove(statsList[0]);
            characterO.transform.SetParent(transParent, false);
        }
        characterScriptList.Clear(); //Rensar listan
    }

    public void GetAssets() { //Får alla assets
        weaponTemp = GetAtPath<WeaponObject>("WeaponFolder");
        loTemp = GetAtPath<LocationObject>("MissionFolder/LocationObjectives");
        coTemp = GetAtPath<ScriptableCollection>("MissionFolder/CollectionObjectives");
        ioTemp = GetAtPath<InteractObject>("MissionFolder/InteractObjectives");
        quirkArray = GetAtPath<QuirkObject>("QuirkFolder");
    }

    public static T[] GetAtPath<T>(string path) { //Hittar assets i deras folders
        ArrayList al = new ArrayList();
        string[] fileEntries = Directory.GetFiles(Application.dataPath + "/" + path);

        foreach (string fileName in fileEntries) {

            int index = fileName.LastIndexOf("/");
            string localPath = "Assets";

            if (index > 0) {
                localPath += fileName.Substring(index);
            }

            Object t = AssetDatabase.LoadAssetAtPath(localPath, typeof(T));

            if (t != null) {
                al.Add(t);
            }
        }

        T[] result = new T[al.Count];
        for (int i = 0; i < al.Count; i++) {
            result[i] = (T)al[i];
        }
        return result;
    }

    private void InstantiateLists() {
        characterScriptList = new List<CharacterScript>();
        statsList = new List<Stats>();
    }

    //CharacterList och statsList ska sen vara samma List
    //QuestList ska innehålla status på alla quest, active, complete etc etc
    //WorldScript innehåller alla resurser man har, itemStorage?

}
