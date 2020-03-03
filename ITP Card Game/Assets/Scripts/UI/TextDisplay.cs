using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TextDisplay : MonoBehaviour
{
    public TextMeshProUGUI coinText;

    public void Update()
    {
        coinText.text = GameObject.Find("GameHandler").GetComponent<GameHandler>().gameData.playerCoins.ToString();
    }
}
