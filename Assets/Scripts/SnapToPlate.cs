using Oculus.Interaction;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class SnapToPlate : MonoBehaviour
{
    public Transform plate;
    public GameObject sandwichTracker;
    private bool snapToggle;
    private int ingredientIndex;
    private BoxCollider boxCollider;

    void Start()
    {
        snapToggle = false;
        ingredientIndex = -1;
        boxCollider = GetComponent<BoxCollider>();
    }

    void Update()
    {
        // calculate distance from object to target
        float distance = Vector3.Distance(transform.position, plate.position);

        if (distance < 0.1f && !snapToggle) 
        {   
            // turn off grab interactors
            IEnumerable<GrabInteractor> setInteractors = transform.GetChild(0).GetComponent<GrabInteractable>().Interactors;
            foreach (GrabInteractor interactor in setInteractors)
            {
                interactor.Unselect();
            }

            // snap into place with correct position and orientation
            Vector3 newPosition = plate.position;
            newPosition.y += 0.01f * (sandwichTracker.GetComponent<SandwichTracker>().ingredientCount + 1); // determine height based on existing ingredients
            transform.SetPositionAndRotation(newPosition, plate.rotation * Quaternion.Euler(0, 180f, 0)); // ingredient flipped 180 degrees
            
            snapToggle = true;

            // assign current ingredient index
            ingredientIndex = sandwichTracker.GetComponent<SandwichTracker>().ingredientCount;

            // update ingredient count and sandwich contents
            sandwichTracker.GetComponent<SandwichTracker>().ingredientCount += 1;
            sandwichTracker.GetComponent<SandwichTracker>().currentSandwich.Add(this.gameObject.tag);

            if (sandwichTracker.GetComponent<SandwichTracker>().ingredientCount >= 9) {
                sandwichTracker.GetComponent<SandwichTracker>().ingredientCount += 1;
            }

        }

        // update for removal of ingredients
        if (distance > 0.1f && snapToggle)
        {
            snapToggle = false;

            // decrement ingredient count and remove the last item from the ingredient list
            sandwichTracker.GetComponent<SandwichTracker>().ingredientCount -= 1;
            sandwichTracker.GetComponent<SandwichTracker>().currentSandwich.RemoveAt(sandwichTracker.GetComponent<SandwichTracker>().currentSandwich.Count - 1);
        }

        // only top item can be grabbed
        if (ingredientIndex >= 0 && ingredientIndex < sandwichTracker.GetComponent<SandwichTracker>().ingredientCount)
        {
            boxCollider.enabled = false;
        }
        if (ingredientIndex >= 0 && ingredientIndex == sandwichTracker.GetComponent<SandwichTracker>().ingredientCount - 1) {
            boxCollider.enabled = true;
        }
    }
}
