using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinCounter : MonoBehaviour
{
    // Reference to the text displaying the coin count
    public TextMeshProUGUI coinCountText;

    public int coinCount = 0;

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
        if (coinCountText != null) { coinCountText.text = "Coins: " + coinCount.ToString(); }
    }
}
