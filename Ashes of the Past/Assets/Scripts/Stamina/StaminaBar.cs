using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaBar : MonoBehaviour
{
    public Slider staminaBar;
    public GameObject character;

    public int maxStamina;
    public int currentStamina;
    [SerializeField] private int recoverySpeed;

    private WaitForSeconds regenTick = new WaitForSeconds(0.1f);
    private Coroutine regen;

    public static StaminaBar instance;

    private void Awake() 
    {
        instance = this;
    }

    void Start()
    {
        maxStamina = character.GetComponent<CharacterStats>().stamina;
        recoverySpeed = character.GetComponent<CharacterStats>().staminaRecovery;
        currentStamina = maxStamina;
        staminaBar.maxValue = maxStamina;
        staminaBar.value = maxStamina;
    }

    public void UseStamina(int amount)
    {
        if (currentStamina - amount >= 0)
        {
            currentStamina -= amount;
            staminaBar.value = currentStamina;

            if(regen != null) StopCoroutine(regen);

            regen = StartCoroutine(RegenStamina());
        }
        else
        {
            currentStamina = 0;
            staminaBar.value = currentStamina;

            if(regen != null) StopCoroutine(regen);
            regen = StartCoroutine(RegenStamina());
        }
    }

    private IEnumerator RegenStamina()
    {
        yield return new WaitForSeconds(1);

        while (currentStamina < maxStamina)
        {
            currentStamina += maxStamina / recoverySpeed;
            staminaBar.value = currentStamina;
            yield return regenTick;
        }
        regen = null;
    }

}
