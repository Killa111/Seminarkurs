using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private Stats stats;
    public GameObject playerName;

    private int health;
    private int currentHealth;

    public Slider healthSlider;

    private bool fistTime;

    void Awake() // gets called before Start
    {
        stats = playerName.GetComponent<Stats>();
    }


    void Update()
    {
        if (fistTime)
        {
            health = stats.getHealth();
        }

        currentHealth = stats.getCurrentHealth();
        healthSlider.value = (float) currentHealth / health;
    }

}
