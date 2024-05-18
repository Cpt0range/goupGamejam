using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    public void Tryagain()
    {
        SceneManager.LoadScene(6);
    }

    public void MainTitle()
    {
        SceneManager.LoadScene(0);
    }
}
