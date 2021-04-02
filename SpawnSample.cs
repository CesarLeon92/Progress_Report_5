using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSample : MonoBehaviour




{
    Vector2 direction;
    private Animator animation;
    private Collider2D col;
    private SpiritRenderer speedRend;

    public float speed;


    // Start is called before the first frame update
    void Start()
    {
        animation = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(diresction * speed * Time.deltaTime);
    }
    
    public void OnMouseDown()
    {
        GetBlock();
    }

    public void NextFlip()
    {
        speedRend.flipX = !speedRend.flipX;
        direction.x = -1 * direction.x;
    }

    private void OnTrigger(Collider collision)
    {
        if(collision.tag == "Portal")
        {
            GameManager.Score++;
            Destroy(gameObject);

        }
    }

    private void OnCollissionEnter(COllision2D col)
    {
        if(col.gameObject.tag == "Object")
        {
            Physics2D.IgnoreCollision(col.collider);
        }
        if (col.gameObjet.tag == "Block")
            NextFlip(); 
    }

    public void GetBlock()
    {
        gameObjectBlock = tag = "Object";
        animation.SetTrigger("Object");
        speed = 0;

    }
}
