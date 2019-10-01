using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shopScript : MonoBehaviour {

    public GameObject ShopWindow;
    public int level;

    void Start() {

    }
    
    void Update() {

    }

    public void btnShop() {
        ShopWindow.SetActive(true);
    }

    //behöver ha ett sätt att läsa av vad saker kostar och hur mycket pengar man har
}
