using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] LayerMask Floor;

    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(facingRight())
        {
            rb.velocity = new Vector2(moveSpeed, 0f);
        }
        else
        {
            rb.velocity = new Vector2(-moveSpeed, 0f);
        }
    }
    void FixedUpdate()
    {
        rb.AddForce(new Vector2(moveSpeed, 0));
    }
    bool facingRight()
    {
        return transform.localScale.x > 0f;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if ((Floor.value & (1 << other.gameObject.layer)) > 0)
        {
            transform.localScale = new Vector2((transform.localScale.x) * -1f, transform.localScale.y);
        }

        if (other.gameObject.CompareTag("player"))
        {
            Destroy(gameObject);
        }
    }

}
