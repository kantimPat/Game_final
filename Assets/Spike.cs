using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    public float dmg = 10f;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("PlayerStats"))
        {
            Debug.Log("Player hit a spike");
            col.GetComponent<PlayerStats>().TakeDamage(dmg);
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
