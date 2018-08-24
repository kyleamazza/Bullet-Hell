using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public static GameManager instance = null;
    private int currentLevel = 1;

    // TODO Object pool enemies/enemy bullets
    [SerializeField] GameObject enemy;
    // List<Enemy> enemies;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);

        // enemies = new List<Enemy>();
    }

    private void Update()
    {
        
    }

    private void SetUpLevel()
    {
        // Load images, scroll images, make sure bullet scripts and whatnot are initialized?
    }

    void GameOver()
    {
        // Game Over screen
        // Return to menu
        currentLevel = 1;
    }

    // TODO Enemy Movement
    // TODO Waves/Proper level management
}
