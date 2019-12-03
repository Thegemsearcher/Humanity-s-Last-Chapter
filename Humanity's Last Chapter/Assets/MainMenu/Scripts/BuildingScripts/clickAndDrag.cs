using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class clickAndDrag : MonoBehaviour
{
    Vector3 mousePos, lastMousePos;
    // Start is called before the first frame update
    void Start()
    {
        
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

            if (Input.GetKey(KeyCode.Mouse0))
            {
                transform.position = mousePos;
            }

        } else
        {
            gameObject.GetComponent<Image>().color = Color.white;
        }
    }
}
