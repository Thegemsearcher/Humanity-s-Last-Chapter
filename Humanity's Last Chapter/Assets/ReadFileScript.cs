using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using UnityEditor.SceneManagement;
using System.IO;
using System;

public static class ReadFileScript
{
    private static string mapPath;
    private static string scenePath;
    public static int mapID;
    private static string[] words;
    public static void ReadString()
    {
        mapID = 1;
        mapPath = "MapFiles/pcgmap" + mapID + ".txt";
        scenePath = "Assets/MainMenu/Scenes/Map" + mapID + ".unity";
        StreamReader sr = new StreamReader(mapPath);
        words = sr.ReadToEnd().Split(' ');
        sr.Close();

        MapLoader();
    }

    public static void MapLoader()
    {
        var newScene = SceneManager.CreateScene("Map" + mapID);
        //SceneManager.LoadScene("Map" + mapID, LoadSceneMode.Additive);

        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        //for (int i = 0; i < words.Length; i++)
        //{
        //    if (words[i] == "b")
        //    {
        //        NewBuilding(Convert.ToInt32(words[i + 1]));
        //    }
        //    else if (words[i] == "w")
        //    {
        //        NewWall(Convert.ToInt32(words[i + 1]), Convert.ToInt32(words[i + 2]), Convert.ToInt32(words[i + 3]), Convert.ToInt32(words[i + 4]));
        //    }
        //    else if (words[i] == "r")
        //    {
        //        NewRoad(Convert.ToInt32(words[i + 1]), Convert.ToInt32(words[i + 2]));
        //    }
        //}
        EditorSceneManager.SaveScene(newScene, scenePath);
    }

    private static void NewBuilding(int ID)
    {

    }

    private static void NewWall(float posX, float posY, float width, float height)
    {

    }

    private static void NewRoad(float posX, float posY)
    {

    }

    private static void EditAsset(string str)
    {

    }
}
