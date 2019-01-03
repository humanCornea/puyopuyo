using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class poyoManager : MonoBehaviour
{
    GameObject prefabs;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Game start");
        this.prefabs = (GameObject)Resources.Load("Prefabs/poyo");
        Instantiate(this.prefabs);   
    }

    // Update is called once per frame
    void Update()
    {
        // Instantiate(this.prefabs);   
    }
}
