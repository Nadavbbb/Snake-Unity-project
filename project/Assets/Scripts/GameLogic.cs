using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLogic : MonoBehaviour
{
    [SerializeField] GameObject snake;
    [SerializeField] GameObject life;
    [SerializeField] GameObject startpoint;
    private int lifeCount;

    [SerializeField] GameObject trashCanLevel1;
    [SerializeField] GameObject trashCanLevel2;
    [SerializeField] GameObject trashCanLevel3;
    [SerializeField] GameObject trashCanLevel4;

    [SerializeField] GameObject Gate1;
    [SerializeField] GameObject Gate2;
    [SerializeField] GameObject Gate3;

    [SerializeField] GameObject MessagesPanel;

    [SerializeField] GameObject Timer;
    // Start is called before the first frame update
    void Start()
    {
        lifeCount = 3;
    }

    IEnumerator ShowMessage(int index) // 0 - next level, 1- you lost, 2 - you won.
    {
        MessagesPanel.transform.GetChild(index).gameObject.SetActive(true);

        yield return new WaitForSeconds(4f);

        MessagesPanel.transform.GetChild(index).gameObject.SetActive(false);

        if (index > 0) // the game ended due to win or loss, its here because it has to accur after 4 seconds
            SceneManager.LoadScene(0);

    }
    public void OpenGateLogic(Collider collider)
    {
        if (collider.transform.parent.parent.name=="Level 1" && trashCanLevel1.transform.childCount==1)
        {
            Destroy(Gate1);
            Timer.GetComponent<TimerScript>().SetTimeRemaining(Timer.GetComponent<TimerScript>().GetTimeRemaining() + 4 * 60);
            StartCoroutine(ShowMessage(0));
        }
        else if(collider.transform.parent.parent.name == "Level 2" && trashCanLevel2.transform.childCount == 1)
        {
            Destroy(Gate2);
            Timer.GetComponent<TimerScript>().SetTimeRemaining(Timer.GetComponent<TimerScript>().GetTimeRemaining() + 4 * 60);
            StartCoroutine(ShowMessage(0));
        }
        else if(collider.transform.parent.parent.name == "Level 3" && trashCanLevel3.transform.childCount == 1)
        {
            Destroy(Gate3);
            Timer.GetComponent<TimerScript>().SetTimeRemaining(Timer.GetComponent<TimerScript>().GetTimeRemaining() + 4 * 60);
            StartCoroutine(ShowMessage(0));
        }

        else if (collider.transform.parent.parent.name == "Level 4" && trashCanLevel1.transform.childCount == 1) 
        {
            WonTheGame();
        }
    }
    public void WonTheGame()
    {
        Timer.GetComponent<TimerScript>().SetTimeIsRunning(false);
        StartCoroutine(ShowMessage(2));

    }
    public void LostTheGame()
    {
        snake.GetComponent<SnakeController>().SetStopSnake(true);
        Timer.GetComponent<TimerScript>().SetTimeIsRunning(false);
        if (lifeCount!=3)
            life.transform.GetChild(lifeCount).gameObject.SetActive(false);
        StartCoroutine(ShowMessage(1));

    }
    // life lost function
    public void Lost1Life()
    {
        snake.transform.SetPositionAndRotation(startpoint.transform.position, startpoint.transform.rotation);
        life.transform.GetChild(lifeCount).gameObject.SetActive(false);
    }
    public void ObstacleCollision()
    {
        // remove 1 life
        lifeCount -= 1;
        if (lifeCount == 0)
        {
            LostTheGame();
        }
        else {
            Lost1Life();
        }
        
    }
    public void AddLifeIfHasPlace(Collider other)
    {
        if (lifeCount < 3)
        {
            lifeCount++;
            foreach (Transform childTransform in life.transform)
            {
                GameObject heartUI = childTransform.gameObject;
                if (!heartUI.activeSelf)
                {
                    heartUI.SetActive(true);
                    Destroy(other.gameObject); // Destroy the collided object, not just the collider
                    return;
                }
            }
        }
    }

}
