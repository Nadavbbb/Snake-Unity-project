using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeTheScene : MonoBehaviour
{
    public void LoadTheScene()
    {
        SceneManager.LoadScene(1);
    }
}
