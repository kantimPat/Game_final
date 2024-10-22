using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRedDogAttack : EnemyAttack
{
    PlayerMoveControl playerMoveControls;
    public float force_x;
    public float force_y;
    public float duration;

    public override void SpecialAttack()
    {
        base.SpecialAttack();
        playerMoveControls = playerStats.GetComponentInParent<PlayerMoveControl>();
        StartCoroutine(playerMoveControls.KnockBack(force_x, force_y, duration, transform));
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
