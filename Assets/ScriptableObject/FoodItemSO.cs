using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "FoodItem", menuName = "FoodItemSO/FoodItem")]
public class FoodItemSO : ScriptableObject
{
    public GameObject foodPrefab;
    public int score;
}
