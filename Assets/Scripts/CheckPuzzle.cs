using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OVR;
using Oculus.Interaction;
using Oculus.Interaction.Collections;

public class CheckPuzzle : MonoBehaviour
{
    // The target puzzle goal and flag for a solved puzzle
    public Transform targetPuzzle;
    public bool isSolved;
    public GameObject puzzleTracker;

    private Rigidbody rigidBody;
    private BoxCollider boxCollider;
    private int pieceIndex;
    private int currentPiece;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        boxCollider = GetComponent<BoxCollider>();
        pieceIndex = this.transform.GetSiblingIndex();
        if (transform.parent.name == "Movable Ingredients")
        {
            currentPiece = puzzleTracker.GetComponent<PuzzleTrack>().currentPiece;
        }
        else 
        { 
            currentPiece = puzzleTracker.GetComponent<SecretPuzzleTrack>().currentPiece;
        }

    }

    void Update()
    {
        // get the current piece if it has changed
        if (transform.parent.name == "Movable Ingredients")
        {
            currentPiece = puzzleTracker.GetComponent<PuzzleTrack>().currentPiece;
        }
        else
        {
            currentPiece = puzzleTracker.GetComponent<SecretPuzzleTrack>().currentPiece;
        }
        

        // calculate distance from object to target
        float distance = Vector3.Distance(transform.position, targetPuzzle.position);

        // controller releases grabbed puzzle piece
        if (distance < 0.05f && !isSolved && pieceIndex == currentPiece) 
        {
            IEnumerable<GrabInteractor> setInteractors = transform.GetChild(0).GetComponent<GrabInteractable>().Interactors;
            foreach (GrabInteractor interactor in setInteractors) 
            {
                interactor.Unselect();
            }

            // place puzzle piece with correct position and orientation
            transform.SetPositionAndRotation(targetPuzzle.position, targetPuzzle.rotation);
            targetPuzzle.gameObject.SetActive(false);

            // Fix positon by freezing
            rigidBody.constraints = RigidbodyConstraints.FreezeAll;

            // disable grab interaction
            boxCollider.enabled = false;

            isSolved = true;

            if (transform.parent.name == "Movable Ingredients")
            {
                puzzleTracker.GetComponent<PuzzleTrack>().currentPiece = currentPiece + 1;
            }
            else
            {
                puzzleTracker.GetComponent<SecretPuzzleTrack>().currentPiece = currentPiece + 1;
            }
        }

        
    }
}
