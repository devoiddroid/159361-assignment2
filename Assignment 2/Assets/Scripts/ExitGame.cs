using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitGame : MonoBehaviour
{
    public void QuitGame()
    {
        // Only works when running the built game, not in the editor
        Application.Quit();
    }
}
