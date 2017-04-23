using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CashScript : MonoBehaviour {

    public int moneyToAdd;
    private MoneyManager theMoneyManager;
    // Use this for initialization
    void Start()
    {
        theMoneyManager = FindObjectOfType<MoneyManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "PlayerPrototype")
        {
            theMoneyManager.addMoney(moneyToAdd);

            gameObject.SetActive(false);
        }
    }
}
