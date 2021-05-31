using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rbody;
    private BoxCollider2D col2D;
    [Header("Jump")]
    public bool enableDoubleJump = true;
    public bool canDoubleJump = true;
    public float jumpForce = 10.0f;
    public float doubleJumpForce = 10.0f;
    public float distToGroundOffset = 0.0f;
    public LayerMask groundLayer;
    public LevelManager levelManager;
    [Header("Buffs")]
    public bool invulnerable = false;
    public float invulnerableTime = 5.0f;
    public float invulnerableRechargeTime = 5.0f;
    public float invulnerableCooldown = 0.0f;
    public float timer = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        col2D = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (IsGrounded() && !canDoubleJump)
        {
            canDoubleJump = true;
        }
        if (Input.GetKeyDown(KeyCode.Space) && (IsGrounded() || (canDoubleJump && enableDoubleJump)))
        {
            if (!IsGrounded() && canDoubleJump)
            {
                rbody.velocity = Vector2.up * doubleJumpForce;
                canDoubleJump = false;
            }
            else
            {
                rbody.velocity = Vector2.up * jumpForce;
            }
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

    void Death()
    {
        Destroy(gameObject);
        levelManager.gameOver = true;
    }

    /// <summary>
    /// Sent when another object enters a trigger collider attached to this
    /// object (2D physics only).
    /// </summary>
    /// <param name="other">The other Collider2D involved in this collision.</param>
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Hazard")
        {
            Death();
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "Pickup")
        {
            var pickupType = enums.PickupType.Bananna;
            if (other.gameObject.name.Contains("Monkey"))
            {
                pickupType = enums.PickupType.Monkey;
            }
            if (other.gameObject.name.Contains("Banana"))
            {
                pickupType = enums.PickupType.Bananna;
            }
            levelManager.Pickup(pickupType);
            Destroy(other.gameObject);
        }
    }
}
