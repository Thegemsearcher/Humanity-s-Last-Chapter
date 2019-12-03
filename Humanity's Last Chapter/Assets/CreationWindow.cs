using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreationWindow : MonoBehaviour {

    public InputField inputWorld;
    public GameObject[] Characters;
    public GameObject UICharacter;
    private GameObject holder, parent;

    private CharacterScript characterScript;
    private Stats stats;

    private void Start() {
        parent = GameObject.FindGameObjectWithTag("CharacterManager");
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            CloseWindow();
        }
    }

    public void CloseWindow() {
        WorldScript.world.saveName = inputWorld.text;
        foreach (GameObject character in Characters) {
            characterScript = character.GetComponent<CharacterScript>();
            stats = character.GetComponent<Stats>();
            stats.hp = stats.maxHp;
            holder = Instantiate(UICharacter);
            holder.GetComponent<CharacterScript>().NewCharacter(characterScript.strName, characterScript.clothId, characterScript.headId);
            holder.GetComponent<Stats>().NewCharacter(stats);
            holder.transform.SetParent(parent.transform, false);
        }

        Destroy(gameObject);
    }
}
