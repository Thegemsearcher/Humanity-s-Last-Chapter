using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Spawner : MonoBehaviour {
    public GameObject Enemy, Neutral, QuestGiver;
    private GameObject parent;
    public Tilemap tilemap;
    private Vector3 place;
    private Vector3Int localPlace;
    private List<Vector3> enemySpawn, questGiverSpawn, neutralSpawn;

    // Start is called before the first frame update
    void Start() {
        enemySpawn = new List<Vector3>();
        questGiverSpawn = new List<Vector3>();
        neutralSpawn = new List<Vector3>();

        for (int i = tilemap.cellBounds.xMin; i < tilemap.cellBounds.xMax; i++) {
            for (int j = tilemap.cellBounds.yMin; j < tilemap.cellBounds.yMax; j++) {
                localPlace = (new Vector3Int(i, j, (int)tilemap.transform.position.y));
                place = tilemap.CellToWorld(localPlace);
                if(tilemap.HasTile(localPlace)) {
                    Debug.Log("GetSprite: " + tilemap.GetSprite(localPlace).ToString());
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
        tilemap.ClearAllTiles();
    }

    private void CreateTarget(Vector3 place, GameObject spawnTarget, Transform parent) {
        Instantiate(spawnTarget, place, Quaternion.identity).transform.SetParent(parent, false);
    }
}
