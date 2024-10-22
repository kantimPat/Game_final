using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game_over : MonoBehaviour
{
    public GameObject game_overscene;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void GameOver()
    {
        game_overscene.SetActive(true);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
