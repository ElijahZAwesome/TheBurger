using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurgerIcons : MonoBehaviour
{
    public static BurgerIcons Instance;

    public enum Ingredient
    {
        Tomato = 0,
        Lettuce = 1,
        Onion = 2,
        Pickle = 3,
        Bacon = 4,
        Mushroom = 5,
        OnionRing = 6,
        Bun = 7,
        Cheddar = 8,
        Swiss = 9,
        PepperJack = 10,
        Mayo = 11,
        Mustard = 12,
        Ketchup = 13,
        Barbeque = 14,
        Mystery = 15
    }

    /// <summary>
    /// An array of textures for ingredient icons,
    /// in the same order as Ingredient
    /// </summary>
    public Texture2D[] IngredientIcons = new Texture2D[Enum.GetNames(typeof(Ingredient)).Length];

    private void Start()
    {
        Instance = this;
    }
}
