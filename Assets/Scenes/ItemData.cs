using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemData : MonoBehaviour
{
    
    public string ItemTitle = "";
    public string ItemContent = "";
    public string ItemCategory = "";
    public string ItemSolution = "";

    public string ItemMaterial = "";
    public string ItemPublishYear = "";
    public string ItemLethal = "";


    public string getTitle ()
    {
        return ItemTitle;
    }

    public string getContent ()
    {
        return ItemContent;
    }

    public string getSolution ()
    {
        return ItemSolution;
    }

    public string getMaterial()
    {
        return ItemMaterial;
    }

    public string getPubYear()
    {
        return ItemPublishYear;
    }

    public string getLethal()
    {
        return ItemLethal;
    }
}
