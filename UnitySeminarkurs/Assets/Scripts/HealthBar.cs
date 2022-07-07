using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    Stats stats;
    public GameObject playerName;

    public int health;
    public int currentHealth;

    public Slider healthSlider;

    void Awake() // gets called before Start
    {
        stats = playerName.GetComponent<Stats>();
    }

    void Start()
    {
        health = stats.getHealth();
        currentHealth = stats.getCurrentHealth();
        healthSlider.value = (float) currentHealth / health;
    }

    void Update()
    {
        currentHealth = stats.getCurrentHealth();
        healthSlider.value = (float) currentHealth / health;
    }

}
