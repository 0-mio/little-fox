using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animator;
    
    public float speed;
    public float jumpforce;
    public float Cherry;
    
    public LayerMask grand;
    public Collider2D coll;

    public Text CherryNumbers;

    private bool ishurt;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!ishurt)
        {
            Movement();
        }
        animatechange();
    }

    void Movement()
    {
        float horizontalmove;
        horizontalmove = Input.GetAxis("Horizontal");

        float facedirection = Input.GetAxisRaw("Horizontal");

        if(horizontalmove!=0)
        {
            rb.velocity = new Vector2(horizontalmove * speed, rb.velocity.y);
        }

        if (facedirection != 0)
            transform.localScale = new Vector3(facedirection, 1, 1);

        if (Input.GetKeyDown("w"))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpforce);
            animator.SetBool("jumping", true);
        }
        animator.SetFloat("running", Mathf.Abs(facedirection));
    }

    void animatechange()
    {
        animator.SetBool("idle", true);

        if (rb.velocity.y < 0)
        {
            animator.SetBool("jumping", false);
            animator.SetBool("falling", true);
        }

        if(coll.IsTouchingLayers(grand))
        {
            animator.SetBool("falling", false);
            animator.SetBool("idle", true);
        } 
        if(ishurt)
        {
            animator.SetBool("hurt", true);
            if (Mathf.Abs(rb.velocity.x) < 0.1f)
            {
                ishurt = false;
                animator.SetBool("hurt", false);

            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "collections")
        {
            Destroy(collision.gameObject);
            Cherry++;
            CherryNumbers.text = Cherry.ToString();
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            if (animator.GetBool("falling"))
            {
                Destroy(collision.gameObject);
                rb.velocity = new Vector2(rb.velocity.x, jumpforce);
                animator.SetBool("jumping", true);
            }

            else if(transform.position.x < collision.gameObject.transform.position.x)
            {
                rb.velocity = new Vector2(-2,5);
                ishurt = true;
            }

            else if (transform.position.x > collision.gameObject.transform.position.x)
            {
                rb.velocity = new Vector2(2, 5);
                ishurt = true;
            }
        }
    }




}
