﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserInterfaceManager : MonoBehaviour
{
    [SerializeField]
    Text friendCount;
    [SerializeField]
    Text lifeText;

    #region END GAME HUD
    [SerializeField]
    GameObject endGameMenu;
    [SerializeField]
    GameObject endGameCanvas;
    [SerializeField]
    GameObject startMenu;
    #endregion

    #region STATS HUD
    Text friendsFoundText;
    Text charismaEarnedText;
    Text friendsFoundText2;
    Text charismaEarnedText2;
    #endregion

    public void InitializeManager()
    {
        friendCount = GameObject.Find("friendCountText").GetComponent<Text>();
        lifeText = GameObject.Find("lifeText").GetComponent<Text>();
        endGameMenu = GameObject.Find("GameOver");
        endGameCanvas = GameObject.Find("MainMenu");
        startMenu = GameObject.Find("StartPanel");
        friendsFoundText = GameObject.Find("friendsFoundText").GetComponent<Text>();
        charismaEarnedText = GameObject.Find("charismaEarnedText").GetComponent<Text>();
        friendsFoundText2 = GameObject.Find("friendsFoundText (1)").GetComponent<Text>();
        charismaEarnedText2 = GameObject.Find("charismaEarnedText (1)").GetComponent<Text>();
        endGameMenu.SetActive(false);
    }

    public void AddFriend()
    {
        PlayerStats.current.currentFriends++;
        if (PlayerStats.current.canGainLifeOnFriend && Random.Range(0, 1f) < PlayerStats.current.gainLifeFromFriendChance)
        {
            PlayerStats.current.currentLives++;
        }
        friendCount.text = "Friends: " + PlayerStats.current.currentFriends.ToString();
    }

    public void AddLife(int amount)
    {
        PlayerStats.current.currentLives += amount;
        if (PlayerStats.current.currentLives > 0)
        {
            lifeText.text = "Confidence: " + PlayerStats.current.currentLives.ToString();
        }
        else
        {
            GameManager.instance.EndGame();
            lifeText.text = "Confidence: " + "0";
        }
    }

    private void Update()
    {
        if (PlayerStats.current.currentLives > 0)
        {
            lifeText.text = "Confidence: " + PlayerStats.current.currentLives.ToString();
        }
    }

    public void HideMainMenu()
    {
        endGameCanvas.SetActive(false);
        startMenu.SetActive(false);
    }

    public void ShowEndGameUI()
    {
        endGameCanvas.SetActive(true);
        endGameMenu.SetActive(true);
        friendsFoundText.text = "found " + PlayerStats.current.currentFriends + " friends";
        PlayerStats.current.SetEndGameStats();
        charismaEarnedText.text = "earned " + PlayerStats.current.currentFriends + " charisma";
        UpdateEndGameStats();
    }

    public void UpdateEndGameStats()
    {
        friendsFoundText2.text = "best: " + PlayerStats.current.friendRecord + " friends";
        charismaEarnedText2.text = "total:  " + PlayerStats.current.currentCharisma + " charisma";
    }
}
