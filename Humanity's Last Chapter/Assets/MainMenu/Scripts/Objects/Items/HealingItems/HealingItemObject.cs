using System.Collections;
using System.Collections.Generic;
using UnityEngine;
<<<<<<< Updated upstream
=======
//using static AbilityScript;
>>>>>>> Stashed changes

[System.Serializable]
public class HealingItemObject : ScriptableObject {

    public Sprite texture;
    public string itemName = "t.ex. Weak Bandage";
    public string description = "t.ex. A bandage to coverup small wounds!!!";
    public int healPower; //Hur mycket extra hp den ger när den används
    public int cost;
<<<<<<< Updated upstream
=======
    public float cooldownTimer;
    //public AbilityType abilityType;
>>>>>>> Stashed changes
}
