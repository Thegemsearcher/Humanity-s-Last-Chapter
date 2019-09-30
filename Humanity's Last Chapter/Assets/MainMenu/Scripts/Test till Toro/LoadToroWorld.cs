using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadToroWorld : MonoBehaviour {
    public GameObject character, enemy;
    private GameObject characterO, enemyO, weapon0;
    private Vector3 characterPos, enemyPos;
    private float conterverter;

    void Start() {
        //Ladda Världen
        conterverter = 78.55004f;
        characterPos = new Vector3(-3.8427f, -1.2129f, 0);
        enemyPos = new Vector3(0, 0, 0);
        //enemyPos = new Vector3(-2.144f, -1.204f, 0);

        characterO = Instantiate(character, characterPos, Quaternion.identity);
        characterO.transform.parent = GameObject.Find("CharacterManager").transform;
        characterO.transform.localScale = new Vector3(1, 1, 1);
        enemyO = Instantiate(enemy, enemyPos, Quaternion.identity);
        enemyO.transform.parent = GameObject.Find("EnemyManager").transform;
        enemyO.transform.localScale = new Vector3(1, 1, 1);
    }
}
