using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void VictoryScene()
    {
        SceneManager.LoadScene("VictoryTextScene");
    }

    public void LoseScene()
    {
        SceneManager.LoadScene("LoseTextScene");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
