using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] int velocity;
    float movementHorizontal;
    float movementVertical;
    [SerializeField] int JumpForce;
    bool facingRight;
    [SerializeField] Transform inFloor;
    [SerializeField] LayerMask Floor;

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        movementHorizontal = Input.GetAxisRaw("Horizontal");
        movementVertical = Input.GetAxisRaw("Vertical");

        Flip();
        if (movementVertical > 0f && JumpCheck())
        {
            rb.AddForce(new Vector2 (0, JumpForce));
        }
    }

    private void Flip()
    {

        if (facingRight && movementHorizontal > 0f || !facingRight && movementHorizontal < 0f)
        {
            facingRight = !facingRight;
            Vector2 localScale = transform.localScale;
            localScale.x *= -1;
            transform.localScale = localScale;
        }   
    }
    // Update is called 100 times per second
    private void FixedUpdate()
    {
        rb.AddForce(new Vector2(movementHorizontal * velocity, 0));
    }

    private bool JumpCheck()
    {
        return Physics2D.OverlapCircle(inFloor.position, 0.2f, Floor);
    }
}