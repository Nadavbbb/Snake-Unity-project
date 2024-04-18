using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class OpenPanel : MonoBehaviour
{
    public GameObject panel;
    public bool isHoraotOpen = false;
    // �������� ���� �� ������ �� �������
    public void PanelopenAndClose()
    {
        panel.SetActive(true);
        isHoraotOpen = true;
    }
    private void Update()
    {
         // �������� ���� �� �� ���� ����
        if (Input.GetMouseButtonDown(0) && isHoraotOpen)
            panel.SetActive(false);
    }

}
