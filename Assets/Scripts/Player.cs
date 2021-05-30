using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rbody;
    private BoxCollider2D col2D;
    public float jumpForce = 10.0f;
    public float distToGroundOffset = 0.0f;
    public LayerMask groundLayer;
    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        col2D = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        IsGrounded();
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            rbody.velocity = Vector2.up * jumpForce;
        }
    }

    bool IsGrounded()
    {
        var raycastHit = Physics2D.Raycast(col2D.bounds.center, Vector2.down, col2D.bounds.extents.y + distToGroundOffset, groundLayer);
        Color rayColour;
        var hit = raycastHit.collider != null;

        if (hit)
        {
            rayColour = Color.green;
        }
        else
        {
            rayColour = Color.red;
        }

        Debug.DrawRay(col2D.bounds.center, Vector2.down * (col2D.bounds.extents.y + distToGroundOffset), rayColour);

        return hit;
    }
}
