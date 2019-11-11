using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class Assets {
    //Items
    public WeaponObject[] weaponTemp;
    public HealingItemObject[] healingTemp;
    public CombatItemObject[] combatTemp;

    //Quest
    public ScriptableQuest[] questTemp; //Har alla quests som mall
    public ScriptableCollection[] coTemp;
    public LocationObject[] loTemp;
    public InteractObject[] ioTemp;

    public QuirkObject[] quirkArray;

    public static Assets assets;

    public void GetAssets() { //Får alla assets
        weaponTemp = GetAtPath<WeaponObject>("WeaponFolder");
        healingTemp = GetAtPath<HealingItemObject>("ItemsFolder/HealingItems");
        combatTemp = GetAtPath<CombatItemObject>("ItemsFolder/CombatItems");

        

        questTemp = GetAtPath<ScriptableQuest>("MissionFolder/Quests");
        loTemp = GetAtPath<LocationObject>("MissionFolder/LocationObjectives");
        coTemp = GetAtPath<ScriptableCollection>("MissionFolder/CollectionObjectives");
        ioTemp = GetAtPath<InteractObject>("MissionFolder/InteractObjectives");

        //Debug.Log("healingTemP Lenght: " + weaponTemp.Length);

        quirkArray = GetAtPath<QuirkObject>("QuirkFolder");
    }

    public static T[] GetAtPath<T>(string path) { //Hittar assets i deras folders
        ArrayList al = new ArrayList();
        string[] fileEntries = Directory.GetFiles(Application.dataPath + "/" + path);
        foreach (string fileName in fileEntries) {

            int index = fileName.LastIndexOf("Assets");
            string localPath = "";

            if (index > 0) {
                localPath += fileName.Substring(index);
            }
            //Debug.Log("localPath: " + localPath);

            Object t = AssetDatabase.LoadAssetAtPath(fileName.Substring(index), typeof(T));

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
}
