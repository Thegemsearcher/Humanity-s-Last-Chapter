using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemInfo : MonoBehaviour { //Markus - Används för att enkelt få data från objectet oberoend från vilken sorts object det är

    public string strName, strDesc, id;
    public int cost;
    public Sprite texture;

    public void GetData(Sprite texture, string strName, string strDesc, string id, int cost) {
        this.texture = texture;
        this.strName = strName;
        this.strDesc = strDesc;
        this.id = id;
        this.cost = cost;
        GetComponent<SpriteRenderer>().sprite = texture;
    }
}
