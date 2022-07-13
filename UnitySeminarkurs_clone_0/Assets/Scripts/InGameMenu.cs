using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameMenu : MonoBehaviour
{
    public GameObject inGameMenu;

    public GameObject button1;
    public GameObject button2;

    private void Start()
    {
        inGameMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        KeyInput();
    }

    void KeyInput()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            inGameMenu.SetActive(true);

            button1.SetActive(false);
            button2.SetActive(false);
        }
    }

    public void closeInGameMenu()
    {
        inGameMenu.SetActive(false);

        button1.SetActive(true);
        button2.SetActive(true);
    }
}
