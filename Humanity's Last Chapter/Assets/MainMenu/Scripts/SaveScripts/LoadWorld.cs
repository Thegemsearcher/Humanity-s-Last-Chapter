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

    void Start() {
        characterPos = new Vector2(0, 210);
        if(!Directory.Exists(Application.persistentDataPath + "/Characters") || !Directory.Exists(Application.persistentDataPath + "/Party")) {
            BinaryFormatter formatter = new BinaryFormatter();
            string path = Application.persistentDataPath; //vi behöver något sätt att se till att de inte sparar över varandra.. tänkte använda id men det blir ju också raderat
            Directory.CreateDirectory(path + "/Party");
            Directory.CreateDirectory(path + "/Characters");
        }
        else {
            characterCounter = Directory.GetFiles(Application.persistentDataPath + "/Characters/").Length;
            for (int i = 0; i < characterCounter; i++) { //Gör vi såhär så raderar vi inte character utan kanske har en bool som säger om de ska visas eller inte
                characterO = Instantiate(character, characterPos, Quaternion.identity) as GameObject;
                characterO.transform.SetParent(GameObject.FindGameObjectWithTag("CharacterManager").transform, false);
                characterO.GetComponent<UIBoiScript>().isOwned = true;
                characterO.GetComponent<CharacterScript>().LoadPlayer(i);

                characterPos.y -= 105;




                //if (character.GetComponent<AddToPlayerRoster>() != null)
                //{
                //    characterO = Instantiate(character);
                //    characterO.GetComponent<Button>().onClick.AddListener(characterO.GetComponent<AddToPlayerRoster>().AddToPlayer);
                //    characterO.GetComponentInChildren<Text>().text = characterO.GetComponent<CharacterScript>().name;
                //    GameObject go = GameObject.Find("forCharacters");
                //    GameObject actualParent = GameObject.Find("forCamp");
                //    characterO.transform.SetParent(go.transform, false);
                //    characterO.GetComponent<AddToPlayerRoster>().UIParent = go;
                //    GameObject[] controllers = GameObject.FindGameObjectsWithTag("Controller");
                //    for (int j = 0; j < controllers.Length; j++)
                //    {
                //        controllers[j].GetComponent<HubCharController>().AddToRoster(characterO);
                //    }
                //    characterO.GetComponent<AddToPlayerRoster>().owned = true;
                //    characterO.GetComponent<AddToPlayerRoster>().controller = controllers[0];

                //    //TODO: snälla fixa bättre, den ville bara inte för oss
                //    //Vad är det som inte fungerar?

                //    characterO.transform.localScale = new Vector3(1, 1, 1);
                //    characterO.GetComponent<CharacterScript>().LoadPlayer(i);
                //} else
                //{
                //characterO = Instantiate(character, new Vector2(0, 0), Quaternion.identity) as GameObject;
                //characterO.transform.SetParent(GameObject.FindGameObjectWithTag("CharacterManager").transform, false);
                //characterO.GetComponent<CharacterScript>().LoadPlayer(i);
                //}
            }
        }
    }
    
}
