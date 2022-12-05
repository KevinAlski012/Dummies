using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField, Range(20, 100)] private float speed;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] private float jumpForce = 200;
    bool isJumping;
    private void Start()
    {

    }
    private void Update()
    {
        var Direction = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(Direction * speed, rb.velocity.y);

        if (Input.GetButtonDown("Jump") && isJumping == false)
        {
            float xy = rb.velocity.x;
            rb.velocity = new Vector2(xy, jumpForce);
        }
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("OnCollisionEnter2D");
        if (other.gameObject.CompareTag("Land"))
        {
            isJumping = false;
            Debug.Log(isJumping);
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        Debug.Log("OnCollisionExit2D");
        if (other.gameObject.CompareTag("Land"))
        {
            isJumping = true;
            Debug.Log(isJumping);

        }
    }
}
