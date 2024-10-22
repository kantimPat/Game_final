using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
//using UnityEditor.Experimental.GraphView;
//using UnityEditor.U2D;
using UnityEngine;

public class PlayerMoveControl : MonoBehaviour
{
    private bool boost_mode = false;
    private int direction = 1;
    public float speed = 5f; 
    public AudioSource speed_sound;

    public GatherInput gather_input;
    public new Rigidbody2D rigidbody2D;
    public Animator animator;

    public float ray_length = 0;
    public LayerMask ground_layer;
    public Transform left_point;
    private bool on_ground = false;
    private bool knock_back = false;
    
    // Start is called before the first frame update
    void Start()
    {
       gather_input = GetComponent<GatherInput>();
       rigidbody2D = GetComponent<Rigidbody2D>();
       animator = GetComponent<Animator>();
    }

    private void SetAnimatorValue()
    {
        animator.SetFloat("speed",Mathf.Abs(rigidbody2D.velocity.x));
        animator.SetFloat("v_speed",rigidbody2D.velocity.y);
        animator.SetBool("grounded",on_ground);
    }

    private void CheckStatus() 
    {
        on_ground = Physics2D.Raycast(left_point.position,Vector2.down,ray_length,ground_layer);
    }

    // Update is called once per frame
    void Update()
    {
        CheckStatus();
        Move();
        SetAnimatorValue();
    
    }

    void Boost(){
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            boost_mode = !boost_mode;
            if (boost_mode)
            {
                speed += 10;
                float timer = 0;
                int boost_time = 3;
                timer += 0.5f;
                if (timer > boost_time)
                {
                    speed = 5;
                }
                speed_sound.Play();
            }
            else 
            {
                speed = 5;
            }
            Debug.Log("speed");
        }
    }

    public IEnumerator KnockBack(float forceX, float forceY,float duration, Transform otherObject)
    {
        int knockBackDirection;
        if(transform.position.x < otherObject.position.x)
        {
            knockBackDirection = -1;
        }
        else
        {
            knockBackDirection = 1;
        }

        knock_back = true;
        rigidbody2D.velocity = Vector2.zero;
        Vector2 theForce = new Vector2(forceX * knockBackDirection, forceY);
        rigidbody2D.AddForce(theForce, ForceMode2D.Impulse);

        yield return new WaitForSeconds(duration);
        knock_back = false;
        rigidbody2D.velocity = Vector2.zero;
    }
    

    
    private void FixedUpdate()
    {
        Flip();
        if(knock_back) 
        {
            return;
        }
        JumpPlayer();

        
        
    }

    private void Move()
    {
        rigidbody2D.velocity = new Vector2(
            speed * gather_input.value_x ,
            rigidbody2D.velocity.y
        );
        Boost();
        
        
    }
    private void Flip()
    {
        if(gather_input.value_x  * direction < 0)
        {
            transform.localScale = new Vector3
            (
                -transform.localScale.x,1,1
            );
             direction *= -1;
        }
    }

    private void JumpPlayer()
    {
        if(gather_input.jump_input && on_ground)
        {
            rigidbody2D.velocity = new Vector2(gather_input.value_x * speed, gather_input.jump_force);
        }
        gather_input.jump_input = false;
    }
}
