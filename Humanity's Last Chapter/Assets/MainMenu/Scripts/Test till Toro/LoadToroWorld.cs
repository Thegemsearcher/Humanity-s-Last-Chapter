using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadToroWorld : MonoBehaviour {
    public GameObject character, enemy;
    private GameObject characterO, enemyO, weapon0;
    private List<GameObject> enemies;
    private Vector3 characterPos, enemyPos;
    private float conterverter;

    void Start() {
        //Ladda Världen
        conterverter = 78.55004f;
        characterPos = new Vector3(-3.8427f, -1.2129f, 0);
        enemyPos = new Vector3(Random.Range(-3, 3), Random.Range(-3, 3), 0);
        //enemyPos = new Vector3(0, 0, 0);

        characterO = Instantiate(character, characterPos, Quaternion.identity);
        characterO.transform.parent = GameObject.Find("CharacterManager").transform;
        characterO.transform.localScale = new Vector3(1, 1, 1);
        //enemyO = Instantiate(enemy, enemyPos, Quaternion.identity);
        //enemyO.transform.parent = GameObject.Find("EnemyManager").transform;
        //enemyO.transform.localScale = new Vector3(1, 1, 1);

        enemies = new List<GameObject>();
        GameObject nme = GameObject.FindWithTag("Enemy");
        enemies.Add(nme);
        nme = Instantiate(enemy, new Vector3(Random.Range(-3, 3), Random.Range(-3, 3), 0), Quaternion.identity);
        nme.transform.parent = GameObject.Find("EnemyManager").transform;
        nme.transform.localScale = new Vector3(1, 1, 1);
        enemies.Add(nme);
        nme = Instantiate(enemy, new Vector3(Random.Range(-3, 3), Random.Range(-3, 3), 0), Quaternion.identity);
        nme.transform.parent = GameObject.Find("EnemyManager").transform;
        nme.transform.localScale = new Vector3(1, 1, 1);
        enemies.Add(nme);
        nme = Instantiate(enemy, new Vector3(Random.Range(-3, 3), Random.Range(-3, 3), 0), Quaternion.identity);
        nme.transform.parent = GameObject.Find("EnemyManager").transform;
        nme.transform.localScale = new Vector3(1, 1, 1);
    }
}
