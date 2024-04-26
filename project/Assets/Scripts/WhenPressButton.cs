using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MonoBehaviou : MonoBehaviour
{
    //בשביל לעשות שכאשר אני לוחץ על כפתור יפתח לי חלון חדש
    public void LoadThescene(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }
}
