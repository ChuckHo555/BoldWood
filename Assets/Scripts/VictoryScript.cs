using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryScript : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if (!enemyPresent())
        {
            SceneManager.LoadScene(3);
        }

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }
    }
    public bool enemyPresent()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Boss Enemy");
        return enemies.Length > 0;
    }
}
