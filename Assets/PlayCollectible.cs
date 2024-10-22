using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayCollectible : MonoBehaviour
{
    private int gem_number = 0; 
    public Text text_component;
    // Start is called before the first frame update
    private void UpdateText()
    {
        text_component.text = gem_number.ToString();
    }

    public void GemCollecting(){
        gem_number ++;
        UpdateText();
    }
    void Start()
    {
        UpdateText();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
