using System.Collections
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour {

    public Transition Transition;


	public void StartGame()
    {
        Transition.MakeTransition();
    }
}
