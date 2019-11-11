using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIControls : MonoBehaviour
{
    Vector3 hpBarOffset = new Vector3(-0.255f,0.3f,0);
    public GameObject HealthBar;
    GameObject currentHPBar;

    Vector3 namePlateOffset = new Vector3(-0.255f, 0.45f,0);
    public GameObject namePlate;
    GameObject currentNamePlate;

    GameObject ParentForUiRepresentation;
    public GameObject UiRepresentation;
    GameObject currentUiRepresentation;
    // Start is called before the first frame update
    void Start()
    {
        currentHPBar = Instantiate(HealthBar);
        currentHPBar.GetComponent<HPinCombat>().attachedToPlayer = gameObject;

        currentNamePlate = Instantiate(namePlate);
        currentNamePlate.GetComponent<TextMesh>().text = GetComponent<CharacterScript>().name;
        currentNamePlate.GetComponent<MeshRenderer>().sortingOrder = 1;

        //ParentForUiRepresentation = GameObject.Find("CharacterHolder");
        //currentUiRepresentation = Instantiate(UiRepresentation);
        //currentUiRepresentation.transform.SetParent(ParentForUiRepresentation.transform);
        //currentUiRepresentation.transform.localPosition = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        currentHPBar.transform.position = transform.position + hpBarOffset;
        currentNamePlate.transform.position = transform.position + namePlateOffset;
    }
    private void OnDestroy()
    {
        Destroy(currentHPBar);
        Destroy(currentNamePlate);
    }
}
