using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    public int side;
    public int number;
    private string nameHero;
    private int numberHero;
    private int health;
    private int attack;
    private int movementRange;
    private int attackRange;
    private int currentHealth;
   
    private void Start() 
    {
        if (side == 0)
        {
            numberHero = VariablesAcrossScenes.instance.number0Heroes[number];
            nameHero = VariablesAcrossScenes.instance.names0Heroes[number];
            health = VariablesAcrossScenes.instance.health0Heroes[number];
            attack = VariablesAcrossScenes.instance.damage0Heroes[number];
            movementRange = VariablesAcrossScenes.instance.walkingRange0Heroes[number];
            attackRange = VariablesAcrossScenes.instance.attackingRange0Heroes[number];
        } 
        else if (side == 1)
        {
            numberHero = VariablesAcrossScenes.instance.number1Heroes[number];
            nameHero = VariablesAcrossScenes.instance.names1Heroes[number];
            health = VariablesAcrossScenes.instance.health1Heroes[number];
            attack = VariablesAcrossScenes.instance.damage1Heroes[number];
            movementRange = VariablesAcrossScenes.instance.walkingRange1Heroes[number];
            attackRange = VariablesAcrossScenes.instance.attackingRange1Heroes[number];
        }

        Debug.Log(numberHero + " " + nameHero + " " + health + " " + attack + " " + movementRange + " " + attackRange);
    

        currentHealth = health;
    }
    
    public void setHealth( int newHealth)
    {
        health = newHealth;
    }

    public void setAttack(int newAttack)
    {
        attack = newAttack;
    }

    public void setMovementRange(int newMovementRange)
    {
        movementRange = newMovementRange;
    }

    public void setAttackRange(int newAttackRange)
    {
        attackRange = newAttackRange;
    }
    
    public int getHealth()
    {
        return health;
    }

    public int getAttack()
    {
        return attack;
    }

    public int getMovementRange()
    {
        return movementRange;
    }

    public int getAttackRange()
    {
        return attackRange;
    }

    public void setCurrentHealth( int newCurrentHealth)
    {
        currentHealth = newCurrentHealth;
    }

    public int getCurrentHealth()
    {
        return currentHealth;
    }

    public void decreaseCurrentHealth(int decrease)
    {
        currentHealth -= decrease;
    }

    public void increaseCurrentHealth(int increase)
    {
        currentHealth += increase;
    }
    
    public bool getAlive()
    {
        if (currentHealth <= 0)
        {
            return false;
        }
        return true;
    }
}
