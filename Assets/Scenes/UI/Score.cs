using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private int lastScore;
    private Text t;
    // Start is called before the first frame update
    void Awake() {
        lastScore = GlobalController._score;
    }

    // Update is called once per frame
    void LateUpdate() {
        if(lastScore != GlobalController._score)
        {
            lastScore = GlobalController._score;
            gameObject.GetComponent<Text>().text = GlobalController._score.ToString();
        }
    }
}
