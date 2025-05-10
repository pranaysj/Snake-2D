using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PowerUpItem", menuName = "PowerUpSO/PowerUp")]
public class PowerUpSO : ScriptableObject
{
    public int snakeSpeed;
    public bool isScoreBoosterActive;
    public bool isShieldActive;
}
