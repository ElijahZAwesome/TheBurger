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

    public void SetState(bool correct, bool off = false)
    {
        if (off)
        {
            LEDMeshRenderer.material.color = BurgerColors.Off;
            return;
        }
        LEDMeshRenderer.material.color = correct ? BurgerColors.Correct : BurgerColors.Wrong;
    }

}
