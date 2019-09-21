using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem {

    public static void SaveCharacter(CharacterScript character) {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/character("+character.id+").txt"; //vi behöver något sätt att se till att de inte sparar över varandra.. tänkte använda id men det blir ju också raderat
        FileStream stream = new FileStream(path, FileMode.Create);

        CharacterData data = new CharacterData(character);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static CharacterData LoadCharacter(int id) {
        string path = Application.persistentDataPath + "/character("+id+".txt";

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
}
