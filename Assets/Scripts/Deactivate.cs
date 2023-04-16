using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deactivate : MonoBehaviour
{
    private bool isActivated = false; // Variable to keep track of activation status

    void Start()
    {
        if (!isActivated)
        {
            // Deactivate the object this script is attached to
            gameObject.SetActive(false);
            isActivated = true; // Set activation status to true
        }
    }
}