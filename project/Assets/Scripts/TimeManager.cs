using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public void StopTheTime()
    {
        Time.timeScale = 0;
    }

    public void ContinueTheTime()
    {
        Time.timeScale = 1;
    }
}
