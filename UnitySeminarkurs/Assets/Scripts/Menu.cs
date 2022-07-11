using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{

    public int cosenLevel;

    public GameObject StartMenu;
    public GameObject LevelWahl;
    public GameObject ModiWahl;
    public GameObject HeldenWahl;
    public GameObject Einstellungen;
    public GameObject Credits;
    public GameObject MultiplayerMenu;
    public GameObject MultiplayerName;
    public GameObject MultiplayerJoin;
    public GameObject MultiplayerLobby;
    public GameObject Game;


    private bool GameModi;        // 0 = Offline, 1 = Online
       
    public void setGameModi(bool aGameModi)
    {
        GameModi = aGameModi;
    }

    public bool getGameModi()
    {
        return GameModi;
    }

    public void activateOfflineOnline()
    {
        if (GameModi)              // if ist true wenn Online
        {
            activateMultiplayerMenu();
        }
        else                       // else wenn Offline
        {
            activateLevelWahl();
        }
    }



    // Start is called before the first frame update
    void Start()
    {
        activateStartMenu();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    private void CloseAll()
    {
        StartMenu.SetActive(false);
        LevelWahl.SetActive(false);
        ModiWahl.SetActive(false);
        HeldenWahl.SetActive(false);
        Einstellungen.SetActive(false);
        Credits.SetActive(false);
        MultiplayerMenu.SetActive(false);
        MultiplayerName.SetActive(false);
        MultiplayerJoin.SetActive(false);
        MultiplayerLobby.SetActive(false);
        Game.SetActive(false);

    }

    public void activateStartMenu()
    {
        CloseAll();

        StartMenu.SetActive(true);
    }

    public void activateLevelWahl()
    {
        CloseAll();

        LevelWahl.SetActive(true);
    }

    public void activateModiWahl()
    {
        CloseAll();

        ModiWahl.SetActive(true);
    }

    private bool heldenWahlFromLevelWahlOrMultiplayerLobby;     // 0 = from LevelWahl, 1 = from MultiplayerLobby
    
    public void activateHeldenWahlfromLevelWahl()
    {
        heldenWahlFromLevelWahlOrMultiplayerLobby = false;

        activateHeldenWahl();
    }

    public void activateHeldenWahlfromMultiplayerLobby()
    {
        heldenWahlFromLevelWahlOrMultiplayerLobby = true;

        activateHeldenWahl();
    }

    private void activateHeldenWahl()
    {
        CloseAll();

        HeldenWahl.SetActive(true);

        HeldenWahl.GetComponent<HeldenWahl>().setPlayer0HeldenWahl();   // states that the HeldenWahl was opened
                                                                        // and now player0 chooses
    }

    public void returnFromHeldenWahl()          
    {
        if (heldenWahlFromLevelWahlOrMultiplayerLobby)   // if is true from MultiplayerLobby
        {
            activateMultiplayerLobby();
        }
        else                                    // else when from LevelWahl
        {
            activateLevelWahl();
        }
    }

    public void closeGame()
    {
        if (heldenWahlFromLevelWahlOrMultiplayerLobby)   // if is true from MultiplayerLobby
        {
            activateMultiplayerLobby();
        }
        else                                    // else when from LevelWahl
        {
            activateLevelWahl();
        }
    }

    private void activateEinstellungen()
    {
        CloseAll();

        Einstellungen.SetActive(true);
    }

    public bool enterSettings;          // 0 = from MainMenu, 1 = from InGameMenu

    public void activateEinstellungenStartbildschirm()
    {
        enterSettings = false;
        activateEinstellungen();
    }

    public void activateEinstellungenMenuImLevel()
    {
        enterSettings = true;
        activateEinstellungen();
    }

    public void returnFromSettings()
    {
        if(enterSettings)       // if is true if from InGameMenu
        {
            activateInGameMenu();
        }
        else                    // else if from MainMenu
        {
            activateStartMenu();
        }
    }

    public void activateInGameMenu()
    {
        //temporary
        activateGame();
    }


    public void activateCredits()
    {
        CloseAll();

        Credits.SetActive(true);
    }

    public void activateMultiplayerMenu()
    {
        CloseAll();

        MultiplayerMenu.SetActive(true);
    }

    private void activateMultiplayerName()
    {
        CloseAll();

        MultiplayerName.SetActive(true);
    }

    public void activateMultiplayerNameJoin()
    {
        JoinOrCreate = false;
        activateMultiplayerName();
    }

    public void activateMultiplayerNameCreate()
    {
        JoinOrCreate = true;
        activateMultiplayerName();
    }

    private bool JoinOrCreate;              // 0 = Join, 1 = Create

    public void nameChosen()
    {
        if (JoinOrCreate)       // if is true if Create
        {
            activateMultiplayerLobby();
        }
        else                    // else when Join
        {
            activateMultiplayerJoin();
        }
    }

    public void activateMultiplayerJoin()
    {
        CloseAll();

        MultiplayerJoin.SetActive(true);
    }

    public void activateMultiplayerLobby()
    {
        CloseAll();

        MultiplayerLobby.SetActive(true);
    }

    public void activateGame()
    {
        CloseAll();

        switch (cosenLevel)
        {
            case 0:
                SceneManager.LoadScene("Level1", LoadSceneMode.Additive);
            break;


        }

        
    }


}
