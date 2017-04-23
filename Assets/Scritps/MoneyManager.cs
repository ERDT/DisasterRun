using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MoneyManager : MonoBehaviour {

    public PlayerController thePlayer;
    public Text wallet;
    public int credits;

    // Use this for initialization
    void Start()
    {
        if (PlayerPrefs.HasKey("Credits"))
        {
            credits = PlayerPrefs.GetInt("Credits");
        }
    }

    // Update is called once per frame
    void Update()
    {
        wallet.text = credits +" :Mulla";
        PlayerPrefs.SetInt("Credits", credits);
    }
    public void addMoney(int moneyToAdd)
    {
        credits += moneyToAdd;
    }
}

