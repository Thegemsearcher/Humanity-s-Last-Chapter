using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FormationsScript : MonoBehaviour
{
    public GameObject panelForCharacters;
    public GameObject prefab;
    GameObject[] pcs;
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

    public void OpenFormation()
    {
        if (openedBefore)
            return;
        pcs = GameObject.FindGameObjectsWithTag("Character");
        int j = 0;
        for (int i = 0; i < pcs.Length; i++)
        {
            GameObject go = Instantiate(prefab);
            go.transform.SetParent(GameObject.Find("PanelForCharacters").transform);
            go.transform.position = new Vector3(gameObject.GetComponentInParent<Transform>().transform.position.x + offsetX + 50 * i,
                gameObject.GetComponentInParent<Transform>().transform.position.y + offsetY + 50 * j, 0);
            Debug.Log("" + i);
            j++;
        }
    }
}
