using UnityEngine;

public class History : MonoBehaviour
{
    public string itemName;
    public string itemSolution;
    public bool itemRes;
    public int itemMoney;

    public History(string n, string s, bool r, int m)
    {
        itemName = n;
        itemSolution = s;
        itemRes = r;
        itemMoney = m;
    }

}
