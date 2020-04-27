using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using KModkit;
using UnityEngine;
using UnityEngine.Experimental.UIElements;
using Ingredient = BurgerIcons.Ingredient;
using Random = UnityEngine.Random;

public class BurgerModule : MonoBehaviour 
{
	private KMAudio Audio;
	private KMBombInfo Bomb;
	private KMBombModule Module;
	private KMSelectable Selectable;

	[SerializeField]
	private GameObject[] ProgressLEDS;
	private KMSelectable[] buttons;

	[SerializeField]
    private List<Ingredient> ingredientOrder;
	/// <summary>
	/// Where in the order are we now?
	/// E.G no buttons pressed = 0
	/// all buttons pressed = 4
	/// </summary>
    private int orderIndex = 0;

    private int currentStrikes = 0;

	private void Start () {
		Audio = GetComponent<KMAudio>();
		Bomb = GetComponent<KMBombInfo>();
		Module = GetComponent<KMBombModule>();
        Selectable = GetComponent<KMSelectable>();

        buttons = Selectable.Children;
		foreach(KMSelectable button in buttons)
		{
			button.OnInteract += () =>
            {
                button.AddInteractionPunch();
				ButtonPressed(button.GetComponent<BurgerButton>());
                return false;
			};
		}

        GenerateOrder();
	}

    private void ButtonPressed(BurgerButton button)
    {
        if (ingredientOrder[orderIndex] == button.thisIngredient)
        {
            orderIndex++;
        }
        else
        {
			Module.HandleStrike();
        }
    }

    private void GenerateOrder()
    {
		ingredientOrder = new List<Ingredient>();
		List<KMSelectable> unsetButtons = new List<KMSelectable>(buttons);
        for (int i = 0; i < buttons.Length; i++)
        {
			NewIngredient();
            int btnIndex = Random.Range(0, unsetButtons.Count);
			buttons[btnIndex].GetComponent<BurgerButton>().SetIcon(ingredientOrder[i]);
			unsetButtons.RemoveAt(0);
        }

        ingredientOrder = ingredientOrder.OrderBy(GetIngredientOrder).ToList();
    }

    private void NewIngredient()
    {
        var newIngredient = (Ingredient)Random.Range(0, Enum.GetNames(typeof(Ingredient)).Length);
        if (!ingredientOrder.Contains(newIngredient))
            ingredientOrder.Add(newIngredient);
		else NewIngredient();
    }

    private float GetIngredientOrder(Ingredient ingredient)
    {
        switch (ingredient)
        {
            case Ingredient.Tomato:
                return Bomb.GetPortPlateCount();
            case Ingredient.Lettuce:
                return Bomb.GetBatteryHolderCount() + 0.01f;
            case Ingredient.Onion:
                return Bomb.GetBatteryCount(Battery.AA) + 0.02f;
            case Ingredient.Pickle:
                return Bomb.GetStrikes() + 0.03f;
            case Ingredient.Bacon:
                return Bomb.GetPortPlates().Count(plate => plate.Length <= 0) + 0.04f;
            case Ingredient.Mushroom:
                return Bomb.GetSerialNumberLetters().Count() + 0.05f;
            case Ingredient.OnionRing:
                return Bomb.GetBatteryCount(Battery.D) + 0.06f;
            case Ingredient.Bun:
                return Bomb.GetSerialNumberNumbers().Count() + 0.07f;
            case Ingredient.Cheddar:
                return Bomb.GetIndicators().Count() + 0.08f;
            case Ingredient.Swiss:
                return Bomb.GetBatteryCount() + 0.09f;
            case Ingredient.PepperJack:
                return Bomb.CountDuplicatePorts() + 0.10f;
            case Ingredient.Mayo:
                return Bomb.GetSerialNumberNumbers().Sum() + 0.11f;
            case Ingredient.Mustard:
                return Bomb.GetOnIndicators().Count() + 0.12f;
            case Ingredient.Ketchup:
                return Bomb.GetOffIndicators().Count() + 0.13f;
            case Ingredient.Barbeque:
                return Bomb.GetSerialNumberNumbers().Last() + 0.14f;
            case Ingredient.Mystery:
                return Bomb.GetModuleIDs().Count + 0.15f;
            default:
                return 0;
        }
    }

    private void Update()
    {
        if (currentStrikes != Bomb.GetStrikes())
        {
            currentStrikes = Bomb.GetStrikes();
            GenerateOrder();
        }
    }
}
