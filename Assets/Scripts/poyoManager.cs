using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class poyoManager : MonoBehaviour
{
    GameObject prefabs;
    Quaternion q = Quaternion.identity;
    Vector3 poyoIniposi = new Vector3(0,2,0);
    Vector3 poyo2Iniposi = new Vector3(0,1.7f,0);

    public GameObject poyo1;
    public GameObject poyo2;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Game start");
        this.prefabs = (GameObject)Resources.Load("Prefabs/poyo");
        poyo1 = Instantiate(this.prefabs,poyoIniposi,q);
        poyo2 = Instantiate(this.prefabs,poyo2Iniposi,q);   
    }

    // Update is called once per frame
    void Update()
    {    
        ChangePoyo();
    }

    int poyoPosi =0;
    public float poyoSize;
    void ChangePoyo()
    {

        float x = poyo1.transform.position.x;
        float y = poyo1.transform.position.y;
        float x2;
        float y2;
        

        if(Input.GetKeyDown(KeyCode.A))
        {
            poyoPosi++;
        }
        if(Input.GetKeyDown(KeyCode.S))
        {
            poyoPosi =poyoPosi+3;
        }

        if(poyoPosi%4==0){
            x=x;
            y=y-poyoSize;
        }
        else if(poyoPosi%4==1)
        {
            x=x-poyoSize;
            y=y;
        }
        else if(poyoPosi%4==2)
        {
            x=x;
            y=y+poyoSize;
        }
        else if(poyoPosi%4==3)
        {
            x=x+poyoSize;
            y=y;
        }
        poyo2.transform.position = new Vector3(x,y,0);

    }
}
