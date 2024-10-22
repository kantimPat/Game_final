using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{

    public int lvlToLoad;

    private void LoadLevel() 
    {
        SceneManager.LoadScene(lvlToLoad);    
    }
    private void OnTriggerEnter2D(Collider2D col)   
    {
        if(col.CompareTag("Player"))
        {
            GetComponent<BoxCollider2D>().enabled = false;
            col.GetComponent<GatherInput>().DisableControl();
            LoadLevel();
        }
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
