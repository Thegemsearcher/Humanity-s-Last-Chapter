using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterStatWriter : MonoBehaviour
{
    public GameObject text;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GetStats(int hp, int str, int def, int Int, int dex, int cha, string name)
    {
        text.GetComponent<Text>().text = "Health: " + hp + "\nStrength: " + str + "\nDefence: " + def + "\nIntelligence: " + Int + "\nDexterity: " + dex + "\nCharisma: " + cha + "\nQuirk: " + name;
<<<<<<< HEAD
        //Debug.Log("strnght: " + str);
=======
>>>>>>> 66240be52f7737904f290499d2e0122d69382638
    }
}
