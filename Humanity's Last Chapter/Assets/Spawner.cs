using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Spawner : MonoBehaviour {
    public GameObject Enemy, Neutral, QuestGiver, character;
    private GameObject parent, createdObject;
    public Tilemap tilemap;
    private Vector3 place;
    private Vector3Int localPlace;
    private List<Vector3> enemySpawn, questGiverSpawn, neutralSpawn, characterSpawn;
    private int[] missionOrder;
    private int characterCounter;
    private string wpId;

    // Start is called before the first frame update
    void Start() {
        enemySpawn = new List<Vector3>();
        questGiverSpawn = new List<Vector3>();
        neutralSpawn = new List<Vector3>();
        characterSpawn = new List<Vector3>();
        missionOrder = SaveSystem.LoadPartyOrder();
        characterCounter = 0;

        for (int i = tilemap.cellBounds.xMin; i < tilemap.cellBounds.xMax; i++) {
            for (int j = tilemap.cellBounds.yMin; j < tilemap.cellBounds.yMax; j++) {
                localPlace = (new Vector3Int(i, j, (int)tilemap.transform.position.y));
                place = tilemap.CellToWorld(localPlace);
                if(tilemap.HasTile(localPlace)) {
                    switch(tilemap.GetSprite(localPlace).ToString()) {
                        case "BadBoi (UnityEngine.Sprite)":
                            enemySpawn.Add(place);
                            break;
                        case "NeutralBoi (UnityEngine.Sprite)":
                            neutralSpawn.Add(place);
                            break;
                        case "QuestGiver (UnityEngine.Sprite)":
                            questGiverSpawn.Add(place);
                            break;
                        case "HumanityBoi (UnityEngine.Sprite)":
                            if(characterCounter < missionOrder.Length) {
                                characterSpawn.Add(place);
                                characterCounter++;
                            }
                            break;
                    }
                }
            }
        }

        foreach (Vector3 place in enemySpawn) {
            parent = GameObject.Find("EnemyManager");
            CreateTarget(place, Enemy, parent.transform);
        }
        foreach (Vector3 place in neutralSpawn) {
            parent = GameObject.Find("NeutralManager");
            CreateTarget(place, Neutral, parent.transform);
        }
        foreach (Vector3 place in questGiverSpawn) {
            parent = GameObject.Find("QuestGiverManager");
            CreateTarget(place, QuestGiver, parent.transform);
        }
        characterCounter = 0;
        foreach (Vector3 place in characterSpawn) {
            
            if(missionOrder[characterCounter] >= 0) {
                parent = GameObject.FindGameObjectWithTag("CharacterManager");
                CreateTarget(place, character, parent.transform);
                createdObject.transform.localScale = new Vector3(1, 1, 1);
                createdObject.GetComponent<CharacterScript>().LoadPlayer(missionOrder[characterCounter]);
                createdObject.GetComponent<PersonalMovement>().relativePos = new Vector3(characterCounter * 0.5f, characterCounter * 0.5f);
                createdObject.GetComponent<PersonalMovement>().AddRelativeWaypoint(createdObject.transform.parent.position);

                //Weapon Creation
                wpId = createdObject.GetComponent<CharacterScript>().wpId;
                Debug.Log("WpId: " + wpId);
                if (wpId == "") {
                    GetComponent<SpawnWeapon>().Spawn("wp0", createdObject);
                }
                

                characterCounter++;
            }
            
        }
        tilemap.ClearAllTiles();
    }

    private void CreateTarget(Vector3 place, GameObject spawnTarget, Transform parent) {
        createdObject = Instantiate(spawnTarget, place, Quaternion.identity);
        createdObject.transform.SetParent(parent, false);
    }
}
