using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class poyoManager : MonoBehaviour
{
    GameObject prefabs;
    Quaternion q = Quaternion.identity;
    Vector3 poyoIniposi = new Vector3(0,2,0);

    int num;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Game start");
        this.prefabs = (GameObject)Resources.Load("Prefabs/poyo");
        Instantiate(this.prefabs,poyoIniposi,q);  
        num++; 
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if ( other.gameObject.name == "poyo(Clone)") {
            num--;
            other.rigidbody.constraints = RigidbodyConstraints2D.FreezeAll;
            if ( num == 0 ) {
                Instantiate(this.prefabs,poyoIniposi,q); 
                num++; 
            }  
        }
    }
}
