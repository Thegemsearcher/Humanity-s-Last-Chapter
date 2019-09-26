using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class clickAndDrag : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (gameObject.GetComponent<CircleCollider2D>().OverlapPoint(Camera.main.ScreenToWorldPoint(Input.mousePosition)))
        {
            gameObject.GetComponent<Image>().color = Color.yellow;

            if (Input.GetKey(KeyCode.Mouse0))
            {
                gameObject.transform.position = new Vector3(Input.mousePosition.x/ gameObject.GetComponentInParent<Transform>().position.x, 
                    Input.mousePosition.y / gameObject.GetComponentInParent<Transform>().position.y, 0);//Camera.main.ScreenToWorldPoint(Input.mousePosition);
            }

        } else
        {
            gameObject.GetComponent<Image>().color = Color.red;
        }
    }
}
