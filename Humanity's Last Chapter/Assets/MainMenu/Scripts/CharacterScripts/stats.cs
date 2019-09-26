using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class stats : MonoBehaviour
{
    public int hp, str, def;
    public GameObject characterUI;
    public GameObject prefabCharacterUI;
    public CharacterStatWriter writer;
    // Start is called before the first frame update
    void Start()
    {
        hp = Random.Range(1, 11); //Just for show.
        characterUI = Instantiate(prefabCharacterUI, new Vector3(0,0,0), Quaternion.identity);
        characterUI.GetComponentInChildren<Button>().onClick.AddListener(delegate { characterUI.SetActive(false); });
        //Set the script to the instance of the CharacterCanvas object, and then run the method in it.
        writer = prefabCharacterUI.GetComponent<CharacterStatWriter>();
        writer.GetStats(hp, str, def);
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
