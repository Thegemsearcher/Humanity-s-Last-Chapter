using UnityEngine;
using System.IO;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;

public static class SaveSystem {

    public static List<CharacterData> characterDataList = new List<CharacterData>(); //Serialize all characters
    public static List<QuestData> questDataList = new List<QuestData>(); //Serialize all quests
    public static WorldData worldData; //Serialize world stats
    public static SaveData saveData; //Everything that will be saved should bi added to this one!

    private static string path;

    //Uppdateras vid varje scenbyte
    public static void SaveWorld(WorldScript saveWorld, bool isAuto) {
        int i = 0;
        characterDataList.Clear();
        questDataList.Clear();
        BinaryFormatter formatter = new BinaryFormatter();
        if(isAuto) {
            path = Application.persistentDataPath + "/Saves/AutoSave.save";
        } else {
            path = Application.persistentDataPath + "/Saves/" + saveWorld.saveId + ".save";
        }
         //vi behöver något sätt att se till att de inte sparar över varandra.. tänkte använda id men det blir ju också raderat
        FileStream stream = new FileStream(path, FileMode.Create);
        
        foreach (CharacterScript character in saveWorld.characterList) {
            CharacterData data = new CharacterData(character, saveWorld.statsList[i]);
            characterDataList.Add(data);
            i++;
        }
        foreach (QuestObject questProgression in WorldScript.world.questList) {
            QuestData questData = new QuestData(questProgression.id, questProgression.questStage);
            questDataList.Add(questData);
        }

        worldData = new WorldData(saveWorld);
        saveData = new SaveData(characterDataList, questDataList, worldData);
        formatter.Serialize(stream, saveData);

        stream.Close();
    }

    public static SaveData LoadWorld(string saveId, bool isAuto) {
        if (isAuto) {
            path = Application.persistentDataPath + "/Saves/AutoSave.save";
        } else {
            path = Application.persistentDataPath + "/Saves/"+saveId+".save";
        }

        if (File.Exists(path)) {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            saveData = formatter.Deserialize(stream) as SaveData;
            stream.Close();
            return saveData;
        } else {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }

    //Allt under denna kan inte tas bort riktigt än men snart:

    public static void SaveCharacter(CharacterScript character, Stats Stats) {
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

    public static void DeleteCharacter(CharacterScript character)
    {
        string path = Application.persistentDataPath + "/Characters/character(" + character.id + ").txt"; //vi behöver något sätt att se till att de inte sparar över varandra.. tänkte använda id men det blir ju också raderat
        File.Delete(path);
    }


    //Borde gå att lösas på annat sett...
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
