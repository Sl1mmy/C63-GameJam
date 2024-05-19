using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GetData : MonoBehaviour
{
    public TextMeshProUGUI coinText;
    public TextMeshProUGUI timeText;

    void Start()
    {
        coinText.text = "Coins: " + (PlayerPrefs.GetInt("Coins1") + PlayerPrefs.GetInt("Coins2")).ToString();
        timeText.text = (PlayerPrefs.GetFloat("Time1") + PlayerPrefs.GetFloat("Time2")).ToString();
        PlayerPrefs.DeleteAll();
    }



    private string FormatTime(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time % 60);
        float milliseconds = (time * 1000) % 1000;
        return string.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, milliseconds);
    }
}
