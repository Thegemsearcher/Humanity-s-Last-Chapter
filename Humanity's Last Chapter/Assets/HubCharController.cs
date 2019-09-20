using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HubCharController : MonoBehaviour
{


    private List<GameObject> playerRoster = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void AddToRoster(GameObject go)
    {
        int i = 0;
        playerRoster.Add(go);
        go.GetComponent<Button>().onClick.AddListener(go.GetComponent<stats>().BringUpStats);
        foreach (GameObject character in playerRoster)
        {
            i++;
            character.GetComponent<RectTransform>().position = new Vector3(character.transform.parent.position.x - 50,
                (character.transform.parent.position.y + 275) - (i * 85), 0);
            
        }
    }

    public void CloseAllWindows()
    {
        foreach (GameObject character in playerRoster)
        {
            character.GetComponent<stats>().characterUI.SetActive(false);
        }
    }
}
