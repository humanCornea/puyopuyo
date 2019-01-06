using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Constant;

public class poyoManager : MonoBehaviour
{
    GameObject prefabs;
    Quaternion q = Quaternion.identity;

    public GameObject poyo1;
    public GameObject poyo2;
    // Start is called before the first frame update
    private float poyoSize;

    void Start()
    {
        
        Debug.Log("Game start");
        this.prefabs = (GameObject)Resources.Load("Prefabs/poyo");
        this.wPoyoSet();
        this.poyoSize = GameObject.Find("poyo(Clone)").gameObject.GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void wPoyoSet()
    {
        Vector3 poyoIniposi = new Vector3(0, 2, 0);
        Vector3 poyo2Iniposi = new Vector3(0, 1.7f, 0);
        this.poyo1 = Instantiate(this.prefabs, poyoIniposi, q);
        this.poyo2 = Instantiate(this.prefabs, poyo2Iniposi, q);
        int poyoPosi = (int)Constant.Direction.DOWN;
    }

    // Update is called once per frame
    void Update()
    {
        this.ChangePoyoPosi();
        Debug.Log(this.poyoSize);
    }

    void ChangePoyoPosi()
    {
        float x = poyo1.transform.position.x;
        float y = poyo1.transform.position.y;
 
        if (Input.GetKeyDown(KeyCode.A))
        {
            poyoPosi++;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            poyoPosi = poyoPosi + 3;
        }

        switch(poyoPosi % 4)
        {
            case (int)Constant.Direction.DOWN:
                y = y - this.poyoSize;
                break;
            case (int)Constant.Direction.LEFT:
                x = x - this.poyoSize;
                break;
            case (int)Constant.Direction.UP:
                y = y + this.poyoSize;
                break;
            case (int)Constant.Direction.RIGHT:
                x = x + this.poyoSize;
                break;
            
        }
        poyo2.transform.position = new Vector3(x, y, 0);

    }

}
