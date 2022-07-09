using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    public int side;
    public int number;
    public string name;
    public int health;
    public int attack;
    public int movementRange;
    public int attackRange;
    int currentHealth;

    /*
    private void Awake() // is executed before Start
    {
        if (side == 0)
        {
            name = HeldenWahl.names0Heroes[number];
            health = HeldenWahl.health0Heroes[number];
            attack = HeldenWahl.damage0Heroes[number];
            movementRange = HeldenWahl.walkingRange0Heroes[number];
            attackRange = HeldenWahl.attackingRange0Heroes[number];
        } 
        else if (side == 1)
        {
            name = HeldenWahl.names1Heroes[number];
            health = HeldenWahl.health1Heroes[number];
            attack = HeldenWahl.damage1Heroes[number];
            movementRange = HeldenWahl.walkingRange1Heroes[number];
            attackRange = HeldenWahl.attackingRange1Heroes[number];
        }

        Debug.Log(name + health + attack + movementRange + attackRange);
    }
    */
    private void Start()
    {
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
