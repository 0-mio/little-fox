using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    private Rigidbody2D rb;
    public Transform leftpoint, rightpoint;
    public Animator animator;

    private float leftx,rightx;

    private bool FaceDirection = true;
    public float speed;
    public float jumpforce;

    public LayerMask grand;
    public Collider2D coll;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        transform.DetachChildren();
        leftx = leftpoint.position.x;
        rightx = rightpoint.position.x;
        Destroy(leftpoint.gameObject);
        Destroy(rightpoint.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        animatechange();
    }

    void movement()
    {
        if (FaceDirection && coll.IsTouchingLayers(grand))
        {
            rb.velocity = new Vector2(-speed, jumpforce);
            animator.SetBool("jump", true);
            if (transform.position.x < leftx)
            {
                transform.localScale = new Vector3(-1, 1, 1);
                FaceDirection = false;
            }
        }
        else if(!FaceDirection && coll.IsTouchingLayers(grand))
        {
            rb.velocity = new Vector2(speed, jumpforce);
            animator.SetBool("jump", true);
            if (transform.position.x > rightx)
            {
                transform.localScale = new Vector3(1, 1, 1);
                FaceDirection = true;
            }
        }
    }

    void animatechange()
    {
        if (rb.velocity.y < 0)
        {
            animator.SetBool("jump", false);
            animator.SetBool("fall", true);
        }

        if(coll.IsTouchingLayers(grand))
        {
            animator.SetBool("fall", false);
        }
    }
}
