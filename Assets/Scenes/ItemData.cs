using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemData : MonoBehaviour
{
    
    public string ItemTitle = "";
    public string ItemContent = "";
    public string ItemCategory = "";
    public string ItemSolution = "";

    public string getTitle () {
        return ItemTitle;
    }

    public string getContent () {
        return ItemContent;
    }

    public string getSolution () {
        return ItemSolution;
    }
}
