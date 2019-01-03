using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fall : MonoBehaviour
{
    float speed;
    // Start is called before the first frame update
    void Start()
    {
        this.speed = -2.0f * Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(0, this.speed, 0);
        this.KeyOperation();
    }

    void KeyOperation()
    {
        if (Input.GetKey("left")) {
            this.transform.Translate(-0.1f, 0, 0);
        }
        if (Input.GetKey("right")) {
            this.transform.Translate(0.1f, 0, 0);
        }
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        this.speed = 0;
    }
}
