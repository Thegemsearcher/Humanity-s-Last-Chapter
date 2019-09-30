using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FormationsScript : MonoBehaviour
{
    public GameObject panelForCharacters;
    public GameObject prefab;
    GameObject[] pcs, UIelements;
    bool openedBefore = false;
    float offsetX = 0, offsetY = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void CloseFormations()
    {
        GameObject parentUI = GameObject.Find("ImageForCharacters");
        for (int i = 0; i < pcs.Length; i++)
        {
            Vector3 relativePos = UIelements[i].transform.position - UIelements[i].transform.parent.position;

            //Debug.Log("pc pos  " + UIelements[i].transform.position.x + ", " + UIelements[i].transform.position.y);
            //Debug.Log("parent pos  " + UIelements[i].transform.parent.position.x + ", " + UIelements[i].transform.parent.position.y);
            //Debug.Log("relative pos  " + relativePos.x + ", " + relativePos.y);
            pcs[i].GetComponent<PersonalMovement>().relativePos = relativePos;
        }
    }

    public void OpenFormation()
    {
        if (openedBefore)
            return;
        pcs = GameObject.FindGameObjectsWithTag("Character");
        UIelements = new GameObject[pcs.Length];
        int j = 0;
        GameObject parent = GameObject.Find("ImageForCharacters");
        //if (parent != null)
        //    Debug.Log("finns parent?");
        for (int i = 0; i < pcs.Length; i++)
        {
            //Debug.Log("humanityBoi nr " + i + "finns parent?");
            GameObject go = Instantiate(prefab);

            go.transform.SetParent(parent.transform);
            go.transform.position = new Vector3(gameObject.GetComponentInParent<Transform>().transform.position.x + offsetX + 50 * i,
                gameObject.GetComponentInParent<Transform>().transform.position.y + offsetY + 50 * j, 0);
            UIelements[i] = go;
            j++;
        }
        openedBefore = true;
    }
}
