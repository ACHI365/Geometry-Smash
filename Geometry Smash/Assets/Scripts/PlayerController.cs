using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // player components
    Rigidbody2D rb;
    [SerializeField] private GameObject player;
    
    // jump and move
    private bool jump = false;
    private bool canJump = true;
    [SerializeField] private float runSpeed = 40f;
    [SerializeField] private float jumpForce;
    
    // rotation
    [SerializeField] private float rotation;
    [SerializeField] private float rotationSpeed;
    private bool shouldRotate = false;

    // auxiliary variables
    [SerializeField] private float3 start;
    Vector3 temp = Vector3.zero;
    private int adCount = 0;
    
    // living state
    private bool Alive = true;
    
    // class references
    [SerializeField] private SpawnMap map;
    [SerializeField] private Score score;
    [SerializeField] private MusicManager musical;
    [SerializeField] private MenuSystem menu;
    [SerializeField] private AdsManager Ad;

    // visuals
    private SpriteRenderer sprite;
    [SerializeField] private ParticleSystem particle;
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        start = new float3(-8.039985f, -2.43631f, 0f);
        rb = GetComponent<Rigidbody2D>();
        Alive = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        // send signal to jump
        if (Input.GetKey(KeyCode.Space) && canJump)
            jump = true;
        
        // if in the air rotate
        if (!canJump)
        {
            if (shouldRotate)
            {
                this.transform.Rotate (Vector3.back * Time.deltaTime * rotationSpeed);
            }
            
        }

    }

    void FixedUpdate()
    {
        // change velocity 
        if (Alive)
        {
            rb.velocity = new Vector2(runSpeed, rb.velocity.y);

            if (jump)
            {
                rb.velocity = (new Vector2(rb.velocity.x, jumpForce));
                musical.PlayJump();
            }

            jump = false;        // if jump signal, then jump

        }
        else
        {
            rb.gravityScale = 0;
            rb.velocity = Vector2.zero;
        }
       
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("floor")) // if on floor then can jump
        {
            canJump = true;
        }

        if (collision.gameObject.CompareTag("Spike")) // if spike then respawn
        {
            Alive = false;
            musical.PlayDie();
            sprite.enabled = false;
            particle.Play();
            score.End();
            StartCoroutine(Delay());
        }
        
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("floor")) // if not on floor cannot jump
        {
            canJump = false;
            shouldRotate = true;
        }
    }
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Coin"))
        {
            score.Increment();
        }
    }

    private void Respawn()
    {
        menu.ChangeMenu(true);
        rb.transform.position = start; // restart to start position
        sprite.enabled = true;
    }

    public void StartGame()
    {
        Alive = true;
        rb.gravityScale = 1;
        menu.ChangeMenu(false);

        
        map.Clear();
    }
 
    IEnumerator Delay()
    {
        yield return new WaitForSeconds(1);
        Respawn();
        adCount++;
        
        if (adCount >= 3)
        {
            adCount = 0;
            Ad.ShowAd();

        }
    }
}