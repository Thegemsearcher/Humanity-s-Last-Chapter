using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveSlotManager : MonoBehaviour {
    public int activeSave;

    void Start() {
        if (!Directory.Exists(Application.persistentDataPath + "/SaveSlot1")) {
            BinaryFormatter formatter = new BinaryFormatter();
            string path = Application.persistentDataPath; //vi behöver något sätt att se till att de inte sparar över varandra.. tänkte använda id men det blir ju också raderat
            for (int i = 1; i <= 9; i++) {
                Directory.CreateDirectory(path + "/SaveSlot" + i);
                Directory.CreateDirectory(path + "/SaveSlot" + i + "/Party");
                Directory.CreateDirectory(path + "/SaveSlot" + i + "/Characters");
            }
        }
    }

    public void SetSlot(int save) {
        activeSave = save;
    }
}
