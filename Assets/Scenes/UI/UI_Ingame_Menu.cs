using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Ingame_Menu : MonoBehaviour
{
    public void gameContinue()
    {
        GlobalController._ins.inGameMenu();
    }

    public void gameRestart()
    {
        GlobalController._ins.resetScene();
    }

    public void gameExit()
    {
        GlobalController._ins.exitGame();
    }

}
