using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGrabberScript : MonoBehaviour
{
    bool holding;
    public Vector2 SpriteSize;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (holding)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = mousePos;
        }
    }

    public void NewItem(Sprite newItem)
    {
        this.GetComponent<SpriteRenderer>().sprite = newItem;
        this.GetComponent<SpriteRenderer>().size = SpriteSize;
        holding = true;
    }

    public void Release()
    {
        this.GetComponent<SpriteRenderer>().sprite = null;
        holding = false;
    }
}
