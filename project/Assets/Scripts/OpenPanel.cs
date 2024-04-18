using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class OpenPanel : MonoBehaviour
{
    public GameObject panel;
    public bool isHoraotOpen = false;
    // כשהמשתמש לוחץ על הכפתור של ההוראות
    public void PanelopenAndClose()
    {
        panel.SetActive(true);
        isHoraotOpen = true;
    }
    private void Update()
    {
         // כשהמשתמש לוחץ על כל מקום במסך
        if (Input.GetMouseButtonDown(0) && isHoraotOpen)
            panel.SetActive(false);
    }

}
