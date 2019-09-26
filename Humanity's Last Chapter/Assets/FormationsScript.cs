using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FormationsScript : MonoBehaviour
{
    public GameObject panelForCharacters;
    GameObject[] pcs;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenFormation()
    {
        pcs = GameObject.FindGameObjectsWithTag("Character");
        for (int i = 0; i < pcs.Length; i++)
        {

        }
    }
}
