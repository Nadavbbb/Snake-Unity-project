using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MonoBehaviou : MonoBehaviour
{
    //����� ����� ����� ��� ���� �� ����� ���� �� ���� ���
    public void loadscene(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }
}
