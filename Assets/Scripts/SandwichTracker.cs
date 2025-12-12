using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq; 

public class SandwichTracker : MonoBehaviour
{
    // Start is called before the first frame update
    public int ingredientCount;
    public List<string> currentSandwich;
    public bool completedSandwich;

    public List<List<string>> recipes;
    public GameObject firstRecipeBoard;
    public GameObject secondRecipeBoard;
    public GameObject thirdRecipeBoard;
    public int recipeCount; 

    private List<string> targetSandwich;

    void Start()
    {
        ingredientCount = 0;
        currentSandwich = new List<string>();
        completedSandwich = false; 

        recipes = new List<List<string>>();

        List<string> recipe1 = new List<string> { "bread", "cheese", "ham", "onion", "lettuce", "tomato", "bread" };
        recipes.Add(recipe1);

        List<string> recipe2 = new List<string> { "bread", "cheese", "ham", "onion", "cheese", "ham", "lettuce", "cheese", "bread" };
        recipes.Add(recipe2);

        List<string> recipe3 = new List<string> { "bread", "cheese", "tomato", "onion", "lettuce", "bread", "lettuce", "cheese", "tomato", "onion",  };
        recipes.Add(recipe3);

        targetSandwich = new List<string>();
        targetSandwich = recipes[0];
        recipeCount = 1;
    }

    // Update is called once per frame
    void Update()
    {
        // this creates an infinite loop of sandwiches
        if (targetSandwich.SequenceEqual(currentSandwich) && targetSandwich.SequenceEqual(recipes[0])) 
        {
            completedSandwich = true;
            targetSandwich = recipes[1];
        }

        if (targetSandwich.SequenceEqual(currentSandwich) && targetSandwich.SequenceEqual(recipes[1])) 
        {
            completedSandwich = true;
            targetSandwich = recipes[2];
        }

        if (targetSandwich.SequenceEqual(currentSandwich) && targetSandwich.SequenceEqual(recipes[2])) 
        {
            completedSandwich = true;
            targetSandwich = recipes[0];
        }
    }
}
