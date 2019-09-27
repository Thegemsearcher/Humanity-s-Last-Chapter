using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    public GameObject humanityBoi;
    public List<GameObject> PCs = new List<GameObject>();

    private Vector3 forChar = new Vector3(0,0,0);
    // Start is called before the first frame update
    void Start()
    {
        //foreach(GameObject pc in StaticCharacters.GetAllPCs())
        //{
        //    GameObject newPC = Instantiate(humanityBoi);
        //    //newPC.GetComponent<RectTransform>().localScale = new Vector3(170, 170, 1);
        //    newPC.transform.localScale = new Vector3(170, 170, 1);
        //    PCs.Add(newPC);
        //}
    }

    // Update is called once per frame
    void Update() //ligger nu mera i personal movement
    {
        //GameObject[] pcs = GameObject.FindGameObjectsWithTag("Character");
        //int i = 0, j = 0;
        //foreach (GameObject pc in pcs)
        //{
        //    i++;
        //    j++;
        //    forChar.x = transform.position.x + i * 50;
        //    forChar.y = transform.position.y + j * 50;
        //    pc.transform.position = forChar;
        //}
    }
}
