using System.Collections;
using System.Collections.Generic;
//using UnityEditor.SearchService;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public float max_health;
    public float health;
    private Animator animator;
    private bool can_take_dmg = true;
    private Game_over gameover_scene;
    
    void Start()
    {
        animator = GetComponentInParent<Animator>();
        gameover_scene = GameObject.FindGameObjectWithTag("logic").GetComponent<Game_over>();
        health = max_health;
        
    }
    public void TakeDamage(float dmg)
    {
        if (!can_take_dmg) 
        {
            return;
        }

        health -= dmg;
        Debug.Log($"Player health {health}");
        animator.SetBool("Hurt",true);

        if(health <= 0)
        {
            GetComponent<PolygonCollider2D>().enabled = false;
            GetComponentInParent<GatherInput>().DisableControl();
            gameover_scene.GameOver();
            Debug.Log("You are dead!"); 
            
        }

        StartCoroutine(DamagePrevention());
    }
    public IEnumerator DamagePrevention()
    {
        can_take_dmg = false;
        yield return new WaitForSeconds(0.15f);

        if (health > 0 )
        {
            can_take_dmg = true;
            animator.SetBool("Hurt",false);
            // -> idle animation 
        }
        else {
            animator.SetBool("Dead",true);
            // Debug.Log("left 4 dead 2 best game ever");
            
            // -> dead animation
        }

    }

    
    // Update is called once per frame
    void Update()
    {
        
    }
}
