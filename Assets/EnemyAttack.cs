using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public float damage = 10;
    protected PlayerStats playerStats;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("PlayerStats"))
        {
            playerStats = col.GetComponent<PlayerStats>();
            playerStats.TakeDamage(damage);

            SpecialAttack();
        }
    }
    

    public virtual void SpecialAttack()
    {
        
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
