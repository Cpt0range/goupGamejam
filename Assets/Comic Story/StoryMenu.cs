using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StoryMenu : MonoBehaviour
{
 public void StoryContinue()
    {
        SceneManager.LoadScene(3);
    }
}
