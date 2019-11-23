using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatAbility : MonoBehaviour {
    private CombatItemObject combatItem;
    public GameObject ForMouse, Projectile, Turret;
    private GameObject Character;
    public KeyCode BoundKey;
    
    private CombatType abilityType;
    private bool active;
    GameObject drawUnderMouse;
    Vector3 mousePos;
    float grenadeRange = 6;

    private float coolDown, timeStamp;

    public enum CombatType {
        turret,
        grenade
    }

    public void GetData(CombatItemObject combatItem) {
        this.combatItem = combatItem;
        
        if(combatItem != null) {
            drawUnderMouse = Instantiate(ForMouse);
            drawUnderMouse.SetActive(false);
            coolDown = combatItem.cooldownTimer;
            abilityType = combatItem.abilityType; //Varför vill den kopplas till AbilityScript?
            active = false;
        }
        
    }

    void Update() {
        //Debug.Log("CombatItem: " + combatItem.name);
        if (combatItem != null) {
            timeStamp += Time.deltaTime;

            if (Input.GetKeyDown(BoundKey)) {
                Activate();
            }

            if (active) {
                switch (abilityType) {
                    case CombatType.turret:
                        TurretActivate();
                        break;
                    case CombatType.grenade:
                        GrenadeActivate();
                        break;
                    default:
                        break;
                }
            }
        }
        
    }

    public void Activate() {
        if (combatItem != null) {
            if (timeStamp >= coolDown) {
                timeStamp = 0; //resetar timern

                switch (abilityType) {
                    case CombatType.turret: //Förutom skalan hur skiljer sig turret från grenade här?
                        active = true;
                        drawUnderMouse.SetActive(true);
                        mousePos = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0);
                        drawUnderMouse.transform.localScale = new Vector3(1, 1, 1);
                        break;

                    case CombatType.grenade:
                        active = true;
                        drawUnderMouse.SetActive(true);
                        mousePos = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0);
                        drawUnderMouse.transform.localScale = new Vector3(15, 15, 1);
                        break;
                    default:
                        break;
                }
            }
        }
    }

    

    // Update is called once per frame
    //void Update() {
    //    if (active) {
    //        switch (abilityType) {
    //            case AbilityType.turret:
    //                TurretActivate();
    //                break;
    //            case AbilityType.grenade:
    //                GrenadeActivate();
    //                break;
    //            default:
    //                break;
    //        }
    //    }
    //}

    //public void Activate() {
    //    if (!canBeActivated)
    //        return;
    //    switch (abilityType) {
    //        case AbilityType.turret:
    //            active = true;
    //            drawUnderMouse.SetActive(true);
    //            mousePos = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0);
    //            drawUnderMouse.transform.localScale = new Vector3(1, 1, 1);
    //            break;
    //        case AbilityType.grenade:
    //            active = true;
    //            drawUnderMouse.SetActive(true);
    //            mousePos = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0);
    //            drawUnderMouse.transform.localScale = new Vector3(15, 15, 1);
    //            break;
    //        default:
    //            break;
    //    }
    //}

    public void GrenadeActivate() { //Mycket av koden här likar TurretActivate, kan vi inte flytta den delen så att det bara skrivs på ett ställe?
        mousePos.x = Camera.main.ScreenToWorldPoint(Input.mousePosition).x;
        mousePos.y = Camera.main.ScreenToWorldPoint(Input.mousePosition).y;
        drawUnderMouse.transform.position = mousePos;
        if (Input.GetKeyDown(KeyCode.Mouse0)) {
            active = false;
            drawUnderMouse.SetActive(false);
            GrenadeThrow();
        }
    }
    public void GrenadeThrow() {
        GameObject go = Instantiate(Projectile);
        go.GetComponent<GrenadeScript>().TargetPos = mousePos;
    }

    public void TurretActivate() {
        mousePos.x = Camera.main.ScreenToWorldPoint(Input.mousePosition).x;
        mousePos.y = Camera.main.ScreenToWorldPoint(Input.mousePosition).y;
        drawUnderMouse.transform.position = mousePos;
        if (Input.GetKeyDown(KeyCode.Mouse0)) {
            active = false;
            drawUnderMouse.SetActive(false);
            SpawnTurret();
        }
    }
    public void SpawnTurret() {
        GameObject go = Instantiate(Turret);
        go.transform.position = mousePos;
    }
}
