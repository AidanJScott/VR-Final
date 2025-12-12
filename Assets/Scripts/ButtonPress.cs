using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ButtonPress : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject sandwichTracker;
    public GameObject successScreen;
    public GameObject failureScreen;
    public Transform leftControllerTransform;
    public Transform rightControllerTransform;
    public GameObject firstRecipeBoard;
    public GameObject secondRecipeBoard;
    public GameObject thirdRecipeBoard;

    private bool isSolved;

    private bool buttonToggle;

    void Start()
    {
        isSolved = sandwichTracker.GetComponent<SandwichTracker>().completedSandwich;
        buttonToggle = true;
    }

    // Update is called once per frame
    void Update()
    {


        if (buttonToggle && ((Vector3.Distance(transform.position, leftControllerTransform.position) < 0.075f) || (Vector3.Distance(transform.position, rightControllerTransform.position) < 0.075f))) 
        {
            buttonToggle = false;
            isSolved = sandwichTracker.GetComponent<SandwichTracker>().completedSandwich;

            if (isSolved)
            {
                successScreen.SetActive(true);
                failureScreen.SetActive(false);
                sandwichTracker.GetComponent<SandwichTracker>().completedSandwich = false;

                if (sandwichTracker.GetComponent<SandwichTracker>().recipeCount == 1) 
                {
                    firstRecipeBoard.SetActive(false);
                    secondRecipeBoard.SetActive(true);
                    sandwichTracker.GetComponent<SandwichTracker>().recipeCount = 2;
                }

                if (sandwichTracker.GetComponent<SandwichTracker>().recipeCount == 2) 
                {
                    secondRecipeBoard.SetActive(false);
                    thirdRecipeBoard.SetActive(true);
                    sandwichTracker.GetComponent<SandwichTracker>().recipeCount = 3;
                }

                if (sandwichTracker.GetComponent<SandwichTracker>().recipeCount == 3) 
                {
                    thirdRecipeBoard.SetActive(false);
                    firstRecipeBoard.SetActive(true);
                    sandwichTracker.GetComponent<SandwichTracker>().recipeCount = 1;
                }
            }
            else 
            {
                successScreen.SetActive(false);
                failureScreen.SetActive(true);
            }
        }

        if ((Vector3.Distance(transform.position, leftControllerTransform.position) > 0.075f) && (Vector3.Distance(transform.position, rightControllerTransform.position) > 0.075f)) 
        {
            buttonToggle = true;
        }

    }
}
