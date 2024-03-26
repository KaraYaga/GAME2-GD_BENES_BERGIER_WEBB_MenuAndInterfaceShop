using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewObject", menuName = "ShopObject/ObjectDetails", order = 1)]
public class ObjectScript : ScriptableObject
{
    public string ID;
    public Sprite image;
    public int price;
    public string rarity;
}
