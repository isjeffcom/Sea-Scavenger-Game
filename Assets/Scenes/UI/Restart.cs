using UnityEngine;

public class Restart : MonoBehaviour
{
    public void restartGame()
    {
        GlobalController._ins.resetScene();
    }
}
