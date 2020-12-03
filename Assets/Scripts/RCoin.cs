using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;


public class RCoin : MonoBehaviour
{
    public static int collected = 0;
    [Header("Set Dynamically")]
    public Text coinGT;

    // Start is called before the first frame update
    void Start()
    {
        GameObject coinGO = GameObject.Find("CoinCounterText");
        coinGT = coinGO.GetComponent<Text>();
        coinGT.text = "Coins Collected: " + collected;
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    void OnControllerColliderHit(ControllerColliderHit coll)
    {
        GameObject collidedWith = coll.gameObject;
        if(collidedWith.tag == "RedCoin")
        {
            Destroy(collidedWith);
            //int count = int.Parse(coinGT.text);
            collected += 1;
            //coinGT.text = count.ToString();

           /* if(count > CoinCounter.CoinsCollected)
            {
                CoinCounter.CoinsCollected = count;
            }*/
        }
    }
}
