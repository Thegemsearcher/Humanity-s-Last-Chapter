using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CampScript : MonoBehaviour
{
    public GameObject character;
    public GameObject UIscreenthingy;
    public GameObject UIforCamp;

    private List<GameObject> playerRoster = new List<GameObject>();
    private List<GameObject> campRoster = new List<GameObject>();

   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreateCharacter(string name, Vector3 pos)
    {
        GameObject go = Instantiate(character, pos, Quaternion.identity);
        go.transform.SetParent(UIforCamp.transform);
        go.GetComponent<AddToPlayerRoster>().UIParent = UIscreenthingy;
        go.GetComponent<Button>().onClick.AddListener(go.GetComponent<AddToPlayerRoster>().AddToPlayer);
        campRoster.Add(go);
    }

    public void CreateRoster()
    {
        int rand = Random.Range(2, 5);
        for (int i = 0; i < rand; i++)
        {
            CreateCharacter("placeholder " + i, new Vector3(310, 550 - (i * 75), 0));
        }
    }

    public void SetRoster(List<GameObject> playerRoster)
    {
        this.playerRoster = playerRoster;
    }

    static public void addToPlayer(GameObject character)
    {
        //character.transform.SetParent(UIscreenthingy.transform);
    }
}
