using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionStatusScript : MonoBehaviour {

    public GameObject PostMissionWindow, WindowParent;
    private GameObject[] CharacterArr;
    private GameObject holder;
    private bool allBoizDead, gameRunning;
    private float timeStamp, delayTimer; //delayTimer finns för att det ska ta några sekunder så att spelare själv förstår att alla karaktärer är döda

    private void Start() {
        delayTimer = 2; //Tar tre sek innan spelet går vidare
        gameRunning = true;
        allBoizDead = false;
        Time.timeScale = 1;
    }

    public void CheckBoiz() {
        CharacterArr = GameObject.FindGameObjectsWithTag("Character");
        Debug.Log("Characters: " + CharacterArr.Length);
        if (CharacterArr.Length <= 1) { //1 eftersom den räknar med karaktären som dog
            allBoizDead = true;
            Time.timeScale = 0.3f; //Saker rör sig långsammare
        }
    }

    private void Update() {
        if (allBoizDead && gameRunning) { //Om spelet spelas och alla karaktärer är döda kommer spelet att 
            timeStamp += Time.deltaTime;
            Debug.Log("TimeStame: " + timeStamp);
            if (timeStamp >= delayTimer) {
                Time.timeScale = 0;
                holder = Instantiate(PostMissionWindow);
                holder.GetComponent<PostMissionScript>().isSuccess = false;
                holder.transform.SetParent(WindowParent.transform, false);
                gameRunning = false; //ser till att den inte skapar massor med PostMissionWindows
            }
        }
    }

    public void BtnReturnToHub() {
        Time.timeScale = 0; //pausar spelet så att saker inte rör sig bakom skärmen
        holder = Instantiate(PostMissionWindow); //Skapar fönstret som visar ifall man klara det eller ej
        holder.transform.SetParent(WindowParent.transform, false);
        if (WorldScript.world.activeQuest.completed && !allBoizDead) { //Om uppdraget är avklarat och alla karaktärer lever blir det success
            holder.GetComponent<PostMissionScript>().isSuccess = true;
        } else {
            holder.GetComponent<PostMissionScript>().isSuccess = false;
        }
    }
}
