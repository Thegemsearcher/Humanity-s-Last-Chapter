using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem {

    public static void SaveCharacter(CharacterScript character, stats Stats) {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/Characters/character("+character.id+").txt"; //vi behöver något sätt att se till att de inte sparar över varandra.. tänkte använda id men det blir ju också raderat
        FileStream stream = new FileStream(path, FileMode.Create);

        CharacterData data = new CharacterData(character, Stats);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static CharacterData LoadCharacter(int id) {
        string path = Application.persistentDataPath + "/Characters/character("+id+").txt";

        if(File.Exists(path)) {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            CharacterData data = formatter.Deserialize(stream) as CharacterData;
            stream.Close();
            return data;
        }
        else {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }

    public static void ActiveSave(int slot) {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/ActiveSave.txt";
        FileStream stream = new FileStream(path, FileMode.Create);

        //CharacterData data = new CharacterData(character);

        formatter.Serialize(stream, slot);
        stream.Close();
    }

    public static void SavePartyOrder(int[] missionParty) {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/Party/partyOrder.txt";
        FileStream stream = new FileStream(path, FileMode.Create);
        formatter.Serialize(stream, missionParty);
        stream.Close();

    }

    public static int[] LoadPartyOrder() {
        string path = Application.persistentDataPath + "/Party/partyOrder.txt";

        if(File.Exists(path)) {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            int[] missionParty = formatter.Deserialize(stream) as int[];
            stream.Close();
            return missionParty;
        } else {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }
}
