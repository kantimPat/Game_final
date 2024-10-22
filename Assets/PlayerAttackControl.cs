using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackControl : MonoBehaviour
{
    private PlayerMoveControl player_move_control;
    private GatherInput gather_input;
    private Animator animator; 
    public bool attack_started = false; 
    

    // Start is called before the first frame update
    void Start()
    {
        
        player_move_control = GetComponent<PlayerMoveControl>();
        animator = GetComponent<Animator>();
        gather_input = GetComponent<GatherInput>();
        
            
    }
    // public void ActiveAttack()
    // {
    //     atk_collider.enabled = true;
    // }
    private void Attack()
    {
        if(gather_input.try_atk)
        {
            animator.SetBool("Attack",true);
            attack_started = true;
        }
    }
    private void ResetAttack()
    {
        animator.SetBool("Attack",false);
        gather_input.try_atk = false;
        attack_started = false;
    }

    // Update is called once per frame
    void Update()
    {
        Attack();
    }
}
