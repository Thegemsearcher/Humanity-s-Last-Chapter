using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityScript : MonoBehaviour
{
    public GameObject Turret;
    public GameObject AttachedSlot;
    public AbilityType abilityType;
    bool active = false;
    public enum AbilityType
    {
        turret
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (active)
        //{
        //    switch (abilityType)
        //    {
        //        case AbilityType.turret:

        //            TurretActivate();
        //            break;
        //        default:
        //            break;
        //    }
        //}
    }

    public void Activate()
    {
        switch (abilityType)
        {
            case AbilityType.turret:

                SpawnTurret();
                break;
            default:
                break;
        }
    }

    public void TurretActivate()
    {

    }
    public void SpawnTurret()
    {
        GameObject go = Instantiate(Turret);
        go.transform.position = (new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0));
    }
}
