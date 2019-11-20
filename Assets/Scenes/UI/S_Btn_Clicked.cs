using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Btn_Clicked : MonoBehaviour
{
    public void startGame ()
    {
        GlobalController._ins.startGame();
    }
}
