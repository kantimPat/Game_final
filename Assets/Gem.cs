using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            // call gem collecting method from PlayCollectibl
            col.GetComponent<PlayCollectible>().GemCollecting();
            
            // sound effect 
            GetComponent<AudioSource>().Play();

            // hide sprite and collider function of object
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<Collider2D>().enabled = false;
            
            // Destroy(col);
        }
    }    
}
