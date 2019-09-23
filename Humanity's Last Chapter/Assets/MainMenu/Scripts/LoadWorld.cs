using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class LoadWorld : MonoBehaviour {
    GameObject characterO;
    public GameObject character;
    int characterCounter;

    void Start() {
        Debug.Log("LW: Start");
        if(!Directory.Exists(Application.persistentDataPath + "/Characters")) {
            Debug.Log("It got here");
            BinaryFormatter formatter = new BinaryFormatter();
            string path = Application.persistentDataPath; //vi behöver något sätt att se till att de inte sparar över varandra.. tänkte använda id men det blir ju också raderat
            Directory.CreateDirectory(path + "/Party");
            Directory.CreateDirectory(path + "/Characters");
        }
        else {
            characterCounter = Directory.GetFiles(Application.persistentDataPath + "/Characters/").Length;
            for (int i = 0; i < characterCounter; i++) { //Gör vi såhär så raderar vi inte character utan kanske har en bool som säger om de ska visas eller inte
                characterO = Instantiate(character, new Vector2(0, 0), Quaternion.identity) as GameObject;
                characterO.transform.parent = GameObject.Find("CharacterManager").transform;
                characterO.GetComponent<CharacterScript>().LoadPlayer(i);
            }
        }
    }
    
}
