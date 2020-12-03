using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CoinCounter : MonoBehaviour
{
    [Header("Set in Inspector")]
    public Text uitCoins; //UI Text CoinCounterText
    //[Header("Set Dynamically")]
    
    
    static public int CoinsCollected;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    void UpdateGUI()
    {
        // Show the data in the GUITexts
        //uitLevel.text = "Level: " + (level + 1) + " of " + levelMax;
        uitCoins.text = "Coins Collected: " + CoinsCollected;
        if(RCoin.collected > CoinsCollected)
        {
            CoinsCollected = RCoin.collected;
        }
    }
    void Update()
    {
        UpdateGUI();
    }
}
