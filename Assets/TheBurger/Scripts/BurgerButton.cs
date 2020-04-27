using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurgerButton : MonoBehaviour
{
    public BurgerIcons.Ingredient thisIngredient;

    [SerializeField]
    private MeshRenderer IconMesh;
    [SerializeField]
    private MeshRenderer LEDMeshRenderer;

    public void SetIcon(BurgerIcons.Ingredient ingredient)
    {
        thisIngredient = ingredient;
        IconMesh.material.mainTexture = BurgerIcons.Instance.IngredientIcons[(int) ingredient];
    }

}
