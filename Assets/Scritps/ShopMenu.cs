using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ShopMenu : MonoBehaviour {
    public int[] price;
    public string mainMenu;
    public Text[] Pricey;
    private float xJump;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Pricey[0].text = "+1 xJump " + price[0] * (int) PlayerPrefs.GetFloat("xJump") + " Mulla";
	}
    public void QuitToMain()
    {
        Time.timeScale = 1f;
        Application.LoadLevel(mainMenu);
    }
    public void AddXJump()
    {
        //PlayerPrefs.SetInt("Credits", 1000);
        if (PlayerPrefs.HasKey("xJump") && PlayerPrefs.GetInt("Credits")>=price[0])
        {
            PlayerPrefs.SetInt("Credits", PlayerPrefs.GetInt("Credits") - (price[0]*(int)PlayerPrefs.GetFloat("xJump")));
            xJump = PlayerPrefs.GetFloat("xJump");
            xJump += 1;
            PlayerPrefs.SetFloat("xJump", xJump);
        }
        else {
            if (!PlayerPrefs.HasKey("xJump"))
            {
                PlayerPrefs.SetFloat("xJump", 1f);
            }
        }
    }
}
