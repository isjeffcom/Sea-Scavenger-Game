using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionHistories : MonoBehaviour
{
    public static ActionHistories _ins;

    List<History> history = new List<History>();

    // Start is called before the first frame update
    void Awake()
    {
        _ins = this;
        
    }

    public List<History> GetHistory ()
    {
        return history;
    }

    public void AddHistory (string name, string solution, bool res, int money)
    {
        history.Add(new History(name, solution, res, money));
    }

    public void delHistory (string name)
    {
        // Dont need this one yet
        int count = 0;
        foreach(History item in history)
        {
            if(name == item.name)
            {
                history.RemoveAt(count);
            }

            count++;
        }
    }


}
