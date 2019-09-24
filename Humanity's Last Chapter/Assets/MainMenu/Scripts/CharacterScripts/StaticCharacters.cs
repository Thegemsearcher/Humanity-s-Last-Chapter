using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class StaticCharacters
{
    static List<GameObject> playerCharacters = new List<GameObject>();

    public static void AddPC(GameObject pc)
    {
        playerCharacters.Add(pc);
    }
    public static List<GameObject> GetAllPCs()
    {
        return playerCharacters;
    }
}
