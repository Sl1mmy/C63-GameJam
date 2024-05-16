using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinCounter : MonoBehaviour
{
    // Reference to the text displaying the coin count
    public TextMeshProUGUI coinCountText;

    private int coinCount = 0;

    private void Start()
    {
        UpdateCoinCountUI();
    }

    // Increment the coin count and update UI
    public void IncrementCoinCount()
    {
        coinCount++;
        UpdateCoinCountUI();
    }

    // Update the UI with the current coin count
    private void UpdateCoinCountUI()
    {
        coinCountText.text = "Coins: " + coinCount.ToString();
    }
}
