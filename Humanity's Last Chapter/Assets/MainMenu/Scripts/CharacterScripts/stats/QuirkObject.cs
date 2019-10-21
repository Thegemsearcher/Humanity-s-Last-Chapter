using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class QuirkObject : ScriptableObject
{
    public string quirkName;
    public string quirkDescription;
    public int hp, str, def, Int, dex, cha, ldr, nrg, snt;
    public QuirkObject quirk;
}
