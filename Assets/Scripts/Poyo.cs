using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poyo : MonoBehaviour
{
    float speed;
    float width;

    // Start is called before the first frame update
    void Start()
    {
        this.speed = -2.0f * Time.deltaTime;
        this.width = GameObject.Find("poyo(Clone)").gameObject.GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(0, this.speed, 0);
        if(this.speed != 0f)
        {
            this.KeyOperation();
        }
    }

    void KeyOperation()
    {
        if ( Time.frameCount % 10 == 9 ) {
            if (Input.GetKey("left")) {
                this.transform.Translate(-this.width, 0, 0);
            }
            if (Input.GetKey("right")) {
                this.transform.Translate(this.width, 0, 0);
            }
        }
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if ( this.GetComponent<Rigidbody2D>().constraints != RigidbodyConstraints2D.FreezeAll ) {
            if ( other.gameObject.name == "Floor" || other.gameObject.name == "poyo(Clone)"  ) {
                this.speed = 0;
                this.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
                GameObject.Find("Main Camera").GetComponent<GameManager>().genPoyo(other);
            }
        }
    }
}
