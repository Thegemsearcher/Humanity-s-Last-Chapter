using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class stats : MonoBehaviour
{
    public int hp, str, def;
    public GameObject characterUI;
    public GameObject prefabCharacterUI;
    // Start is called before the first frame update
    void Start()
    {
        characterUI = Instantiate(prefabCharacterUI, new Vector3(0,0,0), Quaternion.identity);
        characterUI.GetComponentInChildren<Button>().onClick.AddListener(delegate { characterUI.SetActive(false); });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void BringUpStats()
    {
        GetComponentInParent<AddToPlayerRoster>().controller.GetComponent<HubCharController>().CloseAllWindows();
        characterUI.SetActive(true);
    }
}
