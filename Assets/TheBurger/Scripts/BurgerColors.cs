using UnityEngine;

public class BurgerColors 
{
	public static Color Off = Color.black;
	public static Color Correct = Color.green;
	public static Color Wrong = Color.red;

    /// <summary>
    /// Colors of ingredients for the LEDs, order is important.
    /// </summary>
    public static Color[] IngredientColors =
    {
        Color.red, // Tomato
        Color.green, // Lettuce
        Color.white * 0.90f, // Onion
        Color.green / 2, // Pickle
        Color.red / 2, // Bacon
        Color.grey, // Mushroom
        Color.white * 0.75f, // Onion Ring
        new Color(255, 212, 94), // Bun
        new Color(255, 165, 0), // Cheddar
        new Color(237, 237, 237), // Swiss
        new Color(237, 237, 237), // PepperJack
        Color.white, // Mayo
        Color.yellow, // Mustard
        Color.red, // Ketchup
        new Color(59, 14, 22), // Barbeque sauce
        new Color(100 * Random.value,
            100 * Random.value, 100 * Random.value), // Mystery Sauce
    };
}
