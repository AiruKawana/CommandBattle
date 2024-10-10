using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneManager : MonoBehaviour
{
    public void VictoryScene()
    {
        SceneManager.LoadScene("VictoryTextScene");
    }

    public void LoseScene()
    {
        SceneManager.LoadScene("LoseTextScene");
    }
}
