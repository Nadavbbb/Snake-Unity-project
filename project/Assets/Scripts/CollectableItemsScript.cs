using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableItemsScript : MonoBehaviour
{
    [SerializeField] public Transform camera; // The object to look at

    void Update()
    {
        // Check if the target is not null
        if (camera != null)
        {
            // Make this object look at the target
            transform.LookAt(camera);
        }
    }
}
