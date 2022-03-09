using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessMeteorShipController : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer spriteRenderer;
    [SerializeField]
    private Sprite idle;
    [SerializeField]
    private Sprite active;


    Rigidbody2D rb;
    float speed = 4.0f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            rb.velocity = new Vector2(-speed, 0);
            spriteRenderer.sprite = active;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            rb.velocity = new Vector2(speed, 0);
            spriteRenderer.sprite = active;
        }
        else
        {
            rb.velocity = Vector2.zero;
            spriteRenderer.sprite = idle;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Meteor")
        {
            print("Game Over");
        }
    }
}
