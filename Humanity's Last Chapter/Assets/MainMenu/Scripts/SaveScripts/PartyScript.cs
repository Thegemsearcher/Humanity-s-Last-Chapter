using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

public class PartyScript : MonoBehaviour {
    private GameObject characterO;
    public GameObject character, UIHealth;
    private int partyMember;                //Används för att bestämma vilken position karaktären spawnar på
    private UIHealthBoi uiHealth;
    private List<CharacterScript> characterScriptList;
    private List<Stats> statsList;
    //private WorldScript worldScript;
    private Transform transParent;
    private GameObject[] characterArr; //Används som en holder för att hålla alla karaktärer som finns så den kan spara dem  

    public ScriptableQuest[] questTemp; //Har alla quests som mall
    public WeaponObject[] weaponTemp;
    public ScriptableCollection[] coTemp;
    public LocationObject[] loTemp;
    public InteractObject[] ioTemp;

    void Start() {
        InstantiateLists();
        LoadAssets();
        LoadWorld();
    }

    public void SpawnCharacters() {
        characterScriptList = WorldScript.world.characterList;
        statsList = WorldScript.world.statsList;


        partyMember = 0;
        transParent = GameObject.FindGameObjectWithTag("CharacterManager").transform;
        foreach (CharacterScript characterScript in characterScriptList) {

           

            characterO = Instantiate(character);
            Debug.Log("statsLenght: " + statsList.Count);
            Debug.Log("CharacterLenght: " + characterScriptList.Count);

            characterO.GetComponent<CharacterScript>().LoadPlayer(characterScript);
            characterO.GetComponent<Stats>().LoadPlayer(statsList[partyMember]);

            

            //Annan kod
            characterO.GetComponent<PersonalMovement>().relativePos = new Vector3(partyMember, partyMember);
            characterO.GetComponent<PersonalMovement>().AddRelativeWaypoint(transform.position);
            gameObject.GetComponent<CharacterMovement>().AddPc(characterO);

            CreateUI(characterScript, statsList[partyMember]);
            
            characterO.transform.SetParent(transParent, false);
            partyMember++;

            
        }
        characterScriptList.Clear(); //Rensar listan



        //characterO = Instantiate(character) as GameObject;
        ////characterO.transform.parent = GameObject.FindGameObjectWithTag("CharacterManager").transform;
        //characterO.transform.localScale = new Vector3(1, 1, 1);
        //characterO.transform.position = new Vector3(1, 1);
        //characterO.GetComponent<CharacterScript>().LoadPlayer(missionOrder[i]);
        
        //characterO.GetComponent<PersonalMovement>().relativePos = new Vector3(i, i);
        //characterO.GetComponent<PersonalMovement>().AddRelativeWaypoint(transform.position);
        ////rollen karaktären har borde gå att bestämmas med i
        //gameObject.GetComponent<CharacterMovement>().AddPc(characterO);

        //characterStats = characterO.GetComponent<stats>();
        //characterScript = characterO.GetComponent<CharacterScript>();
        //CreateUI(characterScript, characterStats);
    }
    private void LoadAssets() {
        weaponTemp = GetAtPath<WeaponObject>("WeaponFolder");
        loTemp = GetAtPath<LocationObject>("MissionFolder/LocationObjectives");
        coTemp = GetAtPath<ScriptableCollection>("MissionFolder/CollectionObjectives");
        ioTemp = GetAtPath<InteractObject>("MissionFolder/InteractObjectives");
    }

    private void LoadWorld() {
        //SaveData data = SaveSystem.LoadWorld(0); //Den behöver få saveSlot tidigare... tror man bara rakt ut kan skicka den från den tidigare scenen
        //characterScriptList = data.characterList;
        //statsList = data.statsList;
        ////worldScript = data.world;

        SpawnCharacters();
    }

    public void SaveData() {
        //    characterArr = GameObject.FindGameObjectsWithTag("Character");

        //    foreach (GameObject character in characterArr) {
        //        characterScriptList.Add(character.GetComponent<CharacterScript>());
        //        statsList.Add(character.GetComponent<stats>());
        //    }

        //    //worldScript = GameObject.Find("WorldManager").GetComponent<WorldScript>();
        //    SaveSystem.SaveWorld(characterScriptList, statsList);
    }

    public void CreateUI(CharacterScript characterScript, Stats characterStats) {
        characterO = Instantiate(UIHealth);
        uiHealth = characterO.GetComponent<UIHealthBoi>();
        uiHealth.GetData(characterScript.strName, characterScript.id, characterStats.hp, characterStats.maxHp); //Måste gå att kunna göra snyggare!
        characterO.transform.SetParent(GameObject.Find("forCharacter").transform, false);
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
}
