using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class Regenerate : MonoBehaviour
{
    private Vector3 position;
    private Quaternion rotation;
    private GameObject thisObject;
    private float distanceThreshold;
    private bool duplicated;

    void Start()
    {
        position  = transform.position;
        rotation = transform.rotation;
        distanceThreshold = 0.05f;
        thisObject = gameObject;
        duplicated = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Calculate the distance between the current position and the original position
        float distance = Vector3.Distance(transform.position, position);

        // Check if the distance exceeds the duplication threshold
        if (distance > distanceThreshold && !duplicated)
        {
            // Instantiate a new copy of the object at the original position
            Instantiate(thisObject, position, rotation);
            duplicated = true;
        }
    }
}
