using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyReddog : Enemy
{

    public Transform ground_check;
    public Transform wall_check; 

    private bool detect_ground;
    private bool detect_wall; 
    public float speed = 1;
    private int direction = -1;
    public LayerMask layerToCheck;
    public float radius;

    private void SetAnimatorValue()
    {
        anim.SetFloat("speed",Mathf.Abs(rb.velocity.x));
    }
    private void FixedUpdate()
    {
        Filp();
        rb.velocity = new Vector2(direction * speed, rb.velocity.y);
    }
    private void Filp() 
    { 
        detect_ground = Physics2D.OverlapCircle(ground_check.position, radius, layerToCheck);         
        detect_wall = Physics2D.OverlapCircle(wall_check.position, radius, layerToCheck);

        if (!detect_ground || detect_wall)
        {
            direction *= -1;
            transform.localScale = new Vector3(-transform.localScale.x, 1, 1);
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(ground_check.position, radius);
        Gizmos.DrawWireSphere(wall_check.position, radius);
    } 
    
    
    
    
    
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SetAnimatorValue();
    }
}
