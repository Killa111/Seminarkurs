using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HeldenWahl : MonoBehaviour
{
    public Menu menu;

    private bool player0Orplayer1HeldenWahl;       // saves if player0 (false) or player1 (true) currently chooses

    public string[] namesHeroes;

    public int[] healthHeroes;

    public int[] damageHeroes;

    public int[] walkingRangeHeroes;

    public int[] attackingRangeHeroes;

    public string[] descriptionHeroes;

    private string[] names0Heroes = new string[3];
    private int[] health0Heroes = new int[3];
    private int[] damage0Heroes = new int[3];
    private int[] walkingRange0Heroes = new int[3];
    private int[] attackingRange0Heroes = new int[3];

    private string[] names1Heroes = new string[3];
    private int[] health1Heroes = new int[3];
    private int[] damage1Heroes = new int[3];
    private int[] walkingRange1Heroes = new int[3];
    private int[] attackingRange1Heroes = new int[3];

    public TMP_Text title;

    public TMP_Text nameHero0Text;

    public TMP_Text nameHero1Text;

    public TMP_Text nameHero2Text;

    public TMP_Text descriptionHero0Text;

    public TMP_Text descriptionHero1Text;

    public TMP_Text descriptionHero2Text;


    private int hero0Number = 0;
    private int hero1Number = 1;
    private int hero2Number = 2;


    public void buttonLeftHero0()
    {
        hero0Number = heroLeft(hero0Number);
        textUpdate();
    }

    public void buttonRightHero0()
    {
        hero0Number = heroRight(hero0Number);
        textUpdate();
    }

    public void buttonLeftHero1()
    {
        hero1Number = heroLeft(hero1Number);
        textUpdate();
    }

    public void buttonRightHero1()
    {
        hero1Number = heroRight(hero1Number);
        textUpdate();
    }

    public void buttonLeftHero2()
    {
        hero2Number = heroLeft(hero2Number);
        textUpdate();
    }

    public void buttonRightHero2()
    {
        hero2Number = heroRight(hero2Number);
        textUpdate();
    }


    private int heroRight(int currentHeroNumber)
    {
        int currentHeroNumberStart = currentHeroNumber;

        currentHeroNumber++;

        if(currentHeroNumber >= namesHeroes.Length)
        {
            return currentHeroNumberStart;
        }

        while(currentHeroNumber == hero0Number ||       // check if Hero in currentHeroNummer is already used
                currentHeroNumber == hero1Number ||     // the goes forward until it is not the case any more
                currentHeroNumber == hero2Number)
        {
            currentHeroNumber++;

            if (currentHeroNumber >= namesHeroes.Length)
            {
                return currentHeroNumberStart;
            }
            
        }

        return currentHeroNumber;
    }

    private int heroLeft(int currentHeroNumber)
    {
        int currentHeroNumberStart = currentHeroNumber;

        currentHeroNumber--;

        if (currentHeroNumber < 0)
        {
            return currentHeroNumberStart;
        }

        while (currentHeroNumber == hero0Number ||       // check if Hero in currentHeroNummer is already used
                currentHeroNumber == hero1Number ||     // the goes forward until it is not the case any more
                currentHeroNumber == hero2Number)
        {
            currentHeroNumber--;

            if (currentHeroNumber < 0)
            {
                return currentHeroNumberStart;
            }

        }

        return currentHeroNumber;
    } 

    private void textUpdate()
    {
        if (player0Orplayer1HeldenWahl)
        {
            title.text = "Choose  Player 1";
        }
        else
        {
            title.text = "Choose  Player 0";
        }

        nameHero0Text.text = namesHeroes[hero0Number];
        nameHero1Text.text = namesHeroes[hero1Number];
        nameHero2Text.text = namesHeroes[hero2Number];

        descriptionHero0Text.text = "Health: " + healthHeroes[hero0Number] + '\n' + "Damage: " + damageHeroes[hero0Number] + '\n'+
            "Walking range: " + walkingRangeHeroes[hero0Number] + '\n'+ "Attack range: "+ attackingRangeHeroes[hero0Number] + '\n'+
            descriptionHeroes[hero0Number] + "  " + hero0Number;

        descriptionHero1Text.text = "Health: " + healthHeroes[hero1Number] + '\n' + "Damage: " + damageHeroes[hero1Number] + '\n' +
            "Walking range: " + walkingRangeHeroes[hero1Number] + '\n' + "Attack range: " + attackingRangeHeroes[hero1Number] + '\n' +
            descriptionHeroes[hero1Number] + "  " + hero1Number;

        descriptionHero2Text.text = "Health: " + healthHeroes[hero2Number] + '\n' + "Damage: " + damageHeroes[hero2Number] + '\n' +
            "Walking range: " + walkingRangeHeroes[hero2Number] + '\n' + "Attack range: " + attackingRangeHeroes[hero2Number] + '\n' +
            descriptionHeroes[hero2Number] + "  " + hero2Number;
    }

    public void resetHeroes()
    {
        hero0Number = 0;
        hero1Number = 1;
        hero2Number = 2;
    }

    public void setStats0Heroes()
    {
        names0Heroes[0] = namesHeroes[hero0Number];
        names0Heroes[1] = namesHeroes[hero1Number];
        names0Heroes[2] = namesHeroes[hero2Number];

        health0Heroes[0] = healthHeroes[hero0Number];
        health0Heroes[1] = healthHeroes[hero1Number];
        health0Heroes[2] = healthHeroes[hero2Number];

        damage0Heroes[0] = damageHeroes[hero0Number];
        damage0Heroes[1] = damageHeroes[hero1Number];
        damage0Heroes[2] = damageHeroes[hero2Number];

        walkingRange0Heroes[0] = walkingRangeHeroes[hero0Number];
        walkingRange0Heroes[1] = walkingRangeHeroes[hero1Number];
        walkingRange0Heroes[2] = walkingRangeHeroes[hero2Number];

        attackingRange0Heroes[0] = attackingRangeHeroes[hero0Number];
        attackingRange0Heroes[1] = attackingRangeHeroes[hero1Number];
        attackingRange0Heroes[2] = attackingRangeHeroes[hero2Number];

        VariablesAcrossScenes.instance.names0Heroes = names0Heroes;
        VariablesAcrossScenes.instance.health0Heroes = health0Heroes;
        VariablesAcrossScenes.instance.damage0Heroes = damage0Heroes;
        VariablesAcrossScenes.instance.walkingRange0Heroes = walkingRange0Heroes;
        VariablesAcrossScenes.instance.attackingRange0Heroes = attackingRange0Heroes;

        VariablesAcrossScenes.instance.number0Heroes[0] = hero0Number;
        VariablesAcrossScenes.instance.number0Heroes[1] = hero1Number;
        VariablesAcrossScenes.instance.number0Heroes[2] = hero2Number;
    }

    public void setStats1Heroes()
    {
        names1Heroes[0] = namesHeroes[hero0Number];
        names1Heroes[1] = namesHeroes[hero1Number];
        names1Heroes[2] = namesHeroes[hero2Number];

        health1Heroes[0] = healthHeroes[hero0Number];
        health1Heroes[1] = healthHeroes[hero1Number];
        health1Heroes[2] = healthHeroes[hero2Number];

        damage1Heroes[0] = damageHeroes[hero0Number];
        damage1Heroes[1] = damageHeroes[hero1Number];
        damage1Heroes[2] = damageHeroes[hero2Number];

        walkingRange1Heroes[0] = walkingRangeHeroes[hero0Number];
        walkingRange1Heroes[1] = walkingRangeHeroes[hero1Number];
        walkingRange1Heroes[2] = walkingRangeHeroes[hero2Number];

        attackingRange1Heroes[0] = attackingRangeHeroes[hero0Number];
        attackingRange1Heroes[1] = attackingRangeHeroes[hero1Number];
        attackingRange1Heroes[2] = attackingRangeHeroes[hero2Number];

        VariablesAcrossScenes.instance.names1Heroes = names1Heroes;
        VariablesAcrossScenes.instance.health1Heroes = health1Heroes;
        VariablesAcrossScenes.instance.damage1Heroes = damage1Heroes;
        VariablesAcrossScenes.instance.walkingRange1Heroes = walkingRange1Heroes;
        VariablesAcrossScenes.instance.attackingRange1Heroes = attackingRange1Heroes;

        VariablesAcrossScenes.instance.number1Heroes[0] = hero0Number;
        VariablesAcrossScenes.instance.number1Heroes[1] = hero1Number;
        VariablesAcrossScenes.instance.number1Heroes[2] = hero2Number;
    }

    // Start is called before the first frame update
    void Start()
    {
        textUpdate();
    }

    public void setPlayer0HeldenWahl()
    {
        player0Orplayer1HeldenWahl = false;
    }

    public void confirmHeroesChoosen()
    {
        if (!player0Orplayer1HeldenWahl)
        {
            setStats0Heroes();
            resetHeroes();

            player0Orplayer1HeldenWahl = true;
            textUpdate();
        }
        else
        {
            setStats1Heroes();
            resetHeroes();

            menu.activateGame();
        }
        
    }
}
