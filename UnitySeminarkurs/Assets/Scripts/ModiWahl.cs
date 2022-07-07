using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ModiWahl : MonoBehaviour
{
    public string[] nameModi = new string[] { "Offline", "Online" };

    public Sprite[] spriteModi;

    public string[] infoModi = new string[] { "play offline", "play online" };

    public TMP_Text TextNameModi;

    public TMP_Text TextInfoModi;

    public GameObject imageModi;

    public int numberModi = 0;

    public Menu menu;

    // Start is called before the first frame update
    void Start()
    {
        TextNameModi.text = nameModi[0];
        TextInfoModi.text = infoModi[0];
        //imageModi.GetComponent<SpriteRenderer>().sprite = spriteModi[0];

    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void leftButtonModi()
    {
        numberModi--;

        if(numberModi < 0)
        {
            numberModi = 0;
        }

        changeModi();
    }

    public void rightButtonModi()
    {
        numberModi++;

        if (numberModi >= nameModi.Length)
        {
            numberModi = nameModi.Length-1;
        }

        changeModi();
    }

    private void changeModi()
    {
        TextNameModi.text = nameModi[numberModi];
        TextInfoModi.text = infoModi[numberModi];
        //imageModi.GetComponent<Sprite>(). = spriteModi[numberModi];
        setOnlineOfline();
    }

    private void setOnlineOfline()
    {
       if (numberModi == nameModi.Length - 1)
       {
           menu.setGameModi(true);     //Online
       }
       else
       {
           menu.setGameModi(false);    // Offline
       }

       

        
    }


}
