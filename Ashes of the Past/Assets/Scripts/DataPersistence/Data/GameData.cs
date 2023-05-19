using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public string lastUpdated;
    public float health;
    public int stamina;
    public int staminaRecovery;
    public float damage;
    public int souls;

    public GameData()
    {
        this.health = 20;
        this.stamina = 25;
        this.staminaRecovery = 25;
        this.damage = 2;
        this.souls = 0;
    }
}
