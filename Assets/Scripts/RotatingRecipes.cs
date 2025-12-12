using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Recipes", menuName = "Recipes/RecipesObject")]
public class RotatingRecipes : ScriptableObject
{
    public List<List<string>> recipes;
    public GameObject recipeBoard1;
    public GameObject recipeBoard2;
    public GameObject recipeBoard3;

    // Start is called before the first frame update
    void Start()
    {
        List<string> recipe1 = new List<string> { "bread", "cheese", "ham", "onion", "lettuce", "tomato", "bread" };
        recipes.Add(recipe1);

        List<string> recipe2 = new List<string> { "bread", "cheese", "ham", "onion", "cheese", "ham", "lettuce", "cheese", "bread" };
        recipes.Add(recipe2);

        List<string> recipe3 = new List<string> { "bread", "cheese", "tomato", "onion", "lettuce", "bread", "lettuce", "cheese", "tomato", "onion",  };
        recipes.Add(recipe3);
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
