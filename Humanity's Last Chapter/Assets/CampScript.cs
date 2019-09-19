using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CampScript : MonoBehaviour
{
    public GameObject character;

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
        Instantiate(character, pos, Quaternion.identity);
    }

    public void CreateRoster()
    {
        int rand = Random.Range(2, 4);
        for (int i = 0; i < rand; i++)
        {

        }
    }

    public void SetRoster(List<GameObject> playerRoster)
    {
        this.playerRoster = playerRoster;
    }
}
