using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // stage
    GameObject stage;
    public Sprite UISprite;
    public Color stageColor;
    public Material stageMaterial;
    public SpriteDrawMode slicedMode;

    private GameObject prefabs;
    private Quaternion q = Quaternion.identity;
    private Vector3 poyoIniposi;
    private int num;

    float poyoWidth = GameObject.Find("poyo(Clone)").gameObject.GetComponent<SpriteRenderer>().bounds.size.x;

    float floorWidth;
    float floorHeight;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Game start");
        this.genStage();
        poyoIniposi = this.transform.position + new Vector3(0, 2, 1);
        this.prefabs = (GameObject)Resources.Load("Prefabs/poyo");
        Instantiate(this.prefabs,poyoIniposi,q);
        this.num = 1; 
    }

    // Update is called once per frame
    void Update()
    {
        if ( this.num > 10 ) {
            Application.Quit();
        }
    }

    void genStage() {
        // make main stage
        this.stage = new GameObject("Field");
        this.stage.transform.position = new Vector3(0, 0.01f, 0);
        this.stage.transform.localScale = new Vector3(12, 24, 1);
        SpriteRenderer sprite = GameObject.Find("Field").AddComponent<SpriteRenderer>();
        sprite.sprite = UISprite;
        sprite.color = stageColor;
        sprite.material = stageMaterial;
        sprite.drawMode = slicedMode;
        sprite.size = new Vector2(0.16f, 0.16f);

        // make left wall
        BoxCollider2D leftWall = GameObject.Find("Field").AddComponent<BoxCollider2D>();
        leftWall.offset = new Vector2(-50.08f, 0);
        leftWall.size = new Vector2(100, 0.2f);

        // make right wall
        BoxCollider2D rightWall = GameObject.Find("Field").AddComponent<BoxCollider2D>();
        rightWall.offset = new Vector2(50.08f, 0);
        rightWall.size = new Vector2(100, 0.2f);
    }

    public void genPoyo(Collision2D other) {
        if ( other.gameObject.name == "poyo(Clone)" || other.gameObject.name == "Floor") {
            this.num--;
            if ( this.num == 0 ) {
                this.num++; 
                Instantiate(this.prefabs, this.poyoIniposi, this.q); 
            }  
        }
    }
}
