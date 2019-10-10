﻿using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;

public static class SaveSystem {

    //Uppdateras vid varje scenbyte
    public static void SaveWorld(List<CharacterScript> characterList, List<stats> statsList, List<ScriptableQuest> questList, WorldScript world) {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/Saves/save"+world.saveSlot+".save"; //vi behöver något sätt att se till att de inte sparar över varandra.. tänkte använda id men det blir ju också raderat
        FileStream stream = new FileStream(path, FileMode.Create);

        SaveData data = new SaveData(characterList, statsList, questList, world);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static SaveData LoadWorld(int SaveSlot) {
        string path = Application.persistentDataPath + "/Saves/save"+SaveSlot+".save";

        if (File.Exists(path)) {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            SaveData data = formatter.Deserialize(stream) as SaveData;
            stream.Close();
            return data;
        } else {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }

    //Behöver bara uppdateras engång per installation/När något i dessa blir uppdaterade
    public static void SaveAssets(List<WeaponObject> weaponList, List<ScriptableCollection> COList, List<LocationObject> LOList, List<InteractObject> IOList) {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/Objects.save"; //vi behöver något sätt att se till att de inte sparar över varandra.. tänkte använda id men det blir ju också raderat
        FileStream stream = new FileStream(path, FileMode.Create);

        AssetsData data = new AssetsData(weaponList, COList, LOList, IOList);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static AssetsData LoadAssets() {
        string path = Application.persistentDataPath + "/Objects.save";

        if (File.Exists(path)) {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            AssetsData data = formatter.Deserialize(stream) as AssetsData;
            stream.Close();
            return data;
        } else {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }

    //Allt under denna kan inte tas bort riktigt än men snart:

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
