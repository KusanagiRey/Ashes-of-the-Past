using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour, IDataPersistence
{
    public float health;
    public int stamina;
    public int staminaRecovery;
    public float damage;
    public int souls;

    public void LoadData(GameData data)
    {
        this.health = data.health;
        this.stamina = data.stamina;
        this.staminaRecovery = data.staminaRecovery;
        this.damage = data.damage;
        this.souls = data.souls;
    }

    public void SaveData(ref GameData data)
    {
        data.health = this.health;
        data.stamina = this.stamina;
        data.staminaRecovery = this.staminaRecovery;
        data.damage = this.damage;
        data.souls = this.souls;
    }
}
