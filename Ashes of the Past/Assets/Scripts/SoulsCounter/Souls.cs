using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Souls : MonoBehaviour
{
    public static Souls instance;

    public Text soulsCounter;
    public GameObject character;

    private int souls;

    private void Awake() 
    {
        instance = this;
    }

    void Start()
    {
        souls = character.GetComponent<CharacterStats>().souls;
        soulsCounter.text = souls.ToString();
    }

    public void GiveSouls(int amount)
    {
        souls += amount;
        soulsCounter.text = souls.ToString();
        character.GetComponent<CharacterStats>().souls = souls;
    }

    public void TakeSouls(int amount)
    {
        souls -= amount;
        soulsCounter.text = souls.ToString();
        character.GetComponent<CharacterStats>().souls = souls;
    }

}
