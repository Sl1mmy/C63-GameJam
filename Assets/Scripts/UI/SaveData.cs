using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveData : MonoBehaviour
{
    public int lvl;
    public CoinCounter coinCounter;
    public StartTimer stopwatchController;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerPrefs.SetInt("Coins" + lvl, coinCounter.coinCount);
            print("Coins" + lvl + " Count: " + coinCounter.coinCount);
            PlayerPrefs.SetFloat("Time" + lvl, stopwatchController.elapsedTime);
            print("Time" + lvl + " time: " + stopwatchController.elapsedTime);
        }
    }
}
