using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class clickAndDrag : MonoBehaviour
{
    Vector3 mousePos, lastMousePos;
    bool held = false;
    GameObject[] UIElementList;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void Awake()
    {
        UIElementList = GameObject.FindGameObjectsWithTag("FormationUiItem");
    }
    // Update is called once per frame
    void Update()
    {
        lastMousePos = mousePos;
        mousePos = Input.mousePosition;

        //när man hoverar över en karaktärs cirkel så blir den gul, när man klickar, håller inne och flyttra musen så följer den efter
        if (gameObject.GetComponent<CircleCollider2D>().OverlapPoint(mousePos) || gameObject.GetComponent<CircleCollider2D>().OverlapPoint(lastMousePos))
        {
            gameObject.GetComponent<Image>().color = Color.gray;
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                bool anyheld = false;
                foreach(GameObject go in UIElementList)
                {
                    if (go.GetComponent<clickAndDrag>().held)
                    {
                        anyheld = true;
                    }
                }
                if (!anyheld)
                    held = true;
            }
            if (Input.GetKey(KeyCode.Mouse0) && held)
            {
                transform.position = mousePos;
            }
            if (Input.GetKeyUp(KeyCode.Mouse0))
            {
                held = false;
            }

        } else
        {
            gameObject.GetComponent<Image>().color = Color.white;
        }
    }
}
