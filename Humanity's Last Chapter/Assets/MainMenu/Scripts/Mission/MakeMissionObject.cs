using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

public class MakeMissionObject {
    
    [MenuItem("Assets/Create/Mission Object")]
    public static void CreateMissionObject() {
        MissionObject asset = ScriptableObject.CreateInstance<MissionObject>();
        int missionCounter = Directory.GetFiles("Assets/MissionFolder/").Length;

        if(!(missionCounter == 0)) { 
            missionCounter /= 2; //Vet inte varför den räknar dubbelt så fixade detta... om någon vet vad man kan göra så fixa det snyggare
        }
        Debug.Log("MissionCounter: " + missionCounter);
        AssetDatabase.CreateAsset(asset, "Assets/MissionFolder/mi"+missionCounter+".asset");
        AssetDatabase.SaveAssets();
        EditorUtility.FocusProjectWindow();
        Selection.activeObject = asset;
    }
}
