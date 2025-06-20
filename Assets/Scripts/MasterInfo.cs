using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterInfo : MonoBehaviour
{
    public static int coinCount = 0;
    [SerializeField] GameObject coinDisplay;
    [SerializeField] GameObject lastScoretxt;
    [SerializeField] GameObject highscoretxt;
    void Update()
    {
        int highScore = PlayerPrefs.GetInt("highScore", 0);

        // Eðer yeni skor daha yüksekse kaydet
        if (coinCount > highScore)
        {
            highScore = coinCount;
            PlayerPrefs.SetInt("highScore", highScore);
        }

        coinDisplay.GetComponent<TMPro.TMP_Text>().text = "COINS: " + coinCount;
        lastScoretxt.GetComponent<TMPro.TMP_Text>().text = "Score: " + coinCount;
        highscoretxt.GetComponent<TMPro.TMP_Text>().text = "HighScore: " + highScore;
    }
}
