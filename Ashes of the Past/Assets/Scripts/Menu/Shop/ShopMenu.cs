using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopMenu : MonoBehaviour
{
    private CharacterStats playerStats;

    public GameObject shopMenu;
    public GameObject character;

    public Text soulsAmount;
    public Button continueButton;


    [Header("Health")]
    public Text healthLevel;
    public Text healthCost;
    public Button healthUpgrade;

    [Header("Stamina")]
    public Text staminaLevel;
    public Text staminaCost;
    public Button staminaUpgrade;

    [Header("Stamina Recovery")]
    public Text rStaminaLevel;
    public Text rStaminaCost;
    public Button rStaminaUpgrade;

    [Header("Damage")]
    public Text damageLevel;
    public Text damageCost;
    public Button damageUpgrade;



    void Start() 
    {
        character.GetComponent<CharacterMovement>().enabled = false;
        character.GetComponent<PlayerCombat>().enabled = false;

        playerStats = character.GetComponent<CharacterStats>();
        soulsAmount.text = playerStats.souls.ToString();

        healthLevel.text = playerStats.health.ToString();
        if (playerStats.health >= 30)
        {
            healthCost.text = "60";
        } else
        if (playerStats.health >= 50)
        {
            healthCost.text = "120";
        }
        else
        {
            healthCost.text = "30";
        }

        staminaLevel.text = playerStats.stamina.ToString();
        if (playerStats.stamina >= 30)
        {
            staminaCost.text = "60";
        } else
        if (playerStats.stamina >= 50)
        {
            staminaCost.text = "120";
        }
        else
        {
            staminaCost.text = "30";
        }

        rStaminaLevel.text = playerStats.staminaRecovery.ToString();
        if (playerStats.staminaRecovery <= 20)
        {
            rStaminaCost.text = "60";
        } else
        if (playerStats.staminaRecovery <= 15)
        {
            rStaminaCost.text = "120";
        }
        else
        {
            rStaminaCost.text = "30";
        }

        damageLevel.text = playerStats.damage.ToString();
        if (playerStats.damage >= 30)
        {
            damageCost.text = "60";
        } else
        if (playerStats.damage >= 50)
        {
            damageCost.text = "120";
        }
        else
        {
            damageCost.text = "30";
        }
        
    }

    public void UpgradeHealth()
    {
        if ((Int32.Parse(soulsAmount.text) - Int32.Parse(healthCost.text)) >= 0)
        {
            character.GetComponent<CharacterStats>().health += 1;
            playerStats.health += 1;
            healthLevel.text = playerStats.health.ToString();

            Souls.instance.TakeSouls(Int32.Parse(healthCost.text));
            soulsAmount.text = character.GetComponent<CharacterStats>().souls.ToString();
        } 
    }

    public void UpgradeStamina()
    {
        if ((Int32.Parse(soulsAmount.text) - Int32.Parse(staminaCost.text)) >= 0)
        {
            character.GetComponent<CharacterStats>().stamina += 1;
            playerStats.stamina += 1;
            staminaLevel.text = playerStats.stamina.ToString();

            Souls.instance.TakeSouls(Int32.Parse(staminaCost.text));
            soulsAmount.text = character.GetComponent<CharacterStats>().souls.ToString();
        } 
    }

    public void UpgradeRStamina()
    {
        if (((Int32.Parse(soulsAmount.text) - Int32.Parse(rStaminaCost.text)) >= 0) && rStaminaLevel.text != "1")
        {
            character.GetComponent<CharacterStats>().staminaRecovery -= 1;
            playerStats.staminaRecovery -= 1;
            rStaminaLevel.text = playerStats.staminaRecovery.ToString();

            Souls.instance.TakeSouls(Int32.Parse(rStaminaCost.text));
            soulsAmount.text = character.GetComponent<CharacterStats>().souls.ToString();
        } 
    }

    public void UpgradeDamage()
    {
        if ((Int32.Parse(soulsAmount.text) - Int32.Parse(damageCost.text)) >= 0)
        {
            character.GetComponent<CharacterStats>().damage += 1;
            playerStats.damage += 1;
            damageLevel.text = playerStats.damage.ToString();

            Souls.instance.TakeSouls(Int32.Parse(damageCost.text));
            soulsAmount.text = character.GetComponent<CharacterStats>().souls.ToString();
        } 
    }

    public void OnContinueButtonPressed()
    {
        character.GetComponent<CharacterMovement>().enabled = true;
        character.GetComponent<PlayerCombat>().enabled = true;
        shopMenu.SetActive(false);
    }
}
