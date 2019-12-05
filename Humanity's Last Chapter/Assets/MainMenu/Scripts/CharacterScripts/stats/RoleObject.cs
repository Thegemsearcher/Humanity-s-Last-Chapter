using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static RoleScript;

public class RoleObject : ScriptableObject {

    public RoleCategory roleCategory;
    public Sprite portraitBackground;
    public string roleName = "Commander";
    public string title = "Cmd";
    public int roleRank = 1;

    public int maxHp = 0;
    public int str = 0;
    public int def = 0;
    public int Int = 0;
    public int dex = 0;
    public int cha = 0;
    public int ldr = 0;
    public int nrg = 0;
    public int snt = 0;

}
