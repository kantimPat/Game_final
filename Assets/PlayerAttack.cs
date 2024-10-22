using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public float atk_dmg = 10;
    private int enemy_layer; 
    public PolygonCollider2D atk_collider;
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.layer == enemy_layer){
            col.GetComponent<Enemy>().TakeDamage(10);
        }
    }
   public void ActiveAttack()
    {
        atk_collider.enabled = true;
    } 

    // Start is called before the first frame update
    void Start()
    {
        enemy_layer = LayerMask.NameToLayer("Enemy");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
