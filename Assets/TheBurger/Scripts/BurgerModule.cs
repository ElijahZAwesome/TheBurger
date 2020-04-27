using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurgerModule : MonoBehaviour 
{
	private KMAudio Audio;
	private KMBombInfo Bomb;
	private KMBombModule Module;
	private KMSelectable Selectable;

	public GameObject[] ProgressLEDs;

	private KMSelectable[] buttons;

	private void Start () {
		Audio = GetComponent<KMAudio>();
		Bomb = GetComponent<KMBombInfo>();
		Module = GetComponent<KMBombModule>();
		Selectable = GetComponent<KMSelectable>();

		buttons = Selectable.Children;
		foreach(KMSelectable button in buttons)
		{
			button.OnInteract += () => { button.AddInteractionPunch(); return false; };
		}

		Init();
	}

	private void Init()
	{
		// sutb
	}
}
