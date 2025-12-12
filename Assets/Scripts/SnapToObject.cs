using UnityEngine;

public class SnapToLocation : MonoBehaviour
{
    // Tag to identify the specific object to snap
    public string objectTag = "BottomBreadSnap";

    // The child object defining the snap position
    private Transform snapLocation;

    void Start()
    {
        // Get the transform of the SnapLocation child object
        snapLocation = transform.Find("SnapLocation");
        if (snapLocation == null)
        {
            Debug.LogError("SnapLocation child not found. Make sure the SnapZone has a child object named 'SnapLocation'.");
        }
    }

    // This function is called by Unity when a collider enters the trigger zone
    void OnTriggerEnter(Collider other)
    {
        // Check if the entering object has the correct tag
        if (other.CompareTag(objectTag))
        {
            // Snap the object to the designated location
            other.transform.position = snapLocation.position;
            other.transform.rotation = snapLocation.rotation;

            // Optionally, disable its Rigidbody or apply other effects
            Rigidbody rb = other.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.isKinematic = true; // Stop the object from being affected by physics
            }
        }
    }
}