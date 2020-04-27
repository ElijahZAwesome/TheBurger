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
        UnnormalizedColor(255, 212, 94), // Bun
        UnnormalizedColor(255, 165, 0), // Cheddar
        UnnormalizedColor(237, 237, 237), // Swiss
        UnnormalizedColor(237, 237, 237), // PepperJack
        Color.white, // Mayo
        Color.yellow, // Mustard
        Color.red, // Ketchup
        UnnormalizedColor(59, 14, 22), // Barbeque sauce
        new Color(Random.value, Random.value, Random.value), // Mystery Sauce
    };

    public static Color UnnormalizedColor(float r, float g, float b)
    {
        return new Color(r / 255, g / 255, b / 255);
    }
}
