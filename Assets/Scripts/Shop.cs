using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    [SerializeField] private UnityEngine.UI.Text CountOfMoneyS;
    [SerializeField] private UnityEngine.UI.Text CountOfMoneyB;
    [SerializeField] private UnityEngine.UI.Text CountOfTomats;
    [SerializeField] private UnityEngine.UI.Text CountOfMoneyForTomats;
    private void Update()
    {
        FruitsHandler fruitsHandlerScript = GameObject.Find("Player").GetComponent<FruitsHandler>();
        if (CountOfMoneyS != null) CountOfMoneyS.text = "У вас на счету " + fruitsHandlerScript.money + " монет";
        if (CountOfMoneyB != null) CountOfMoneyB.text = "У вас на счету " + fruitsHandlerScript.money + " монет";
        if (CountOfTomats != null) CountOfTomats.text = fruitsHandlerScript.tomatoCount + " помидора";
        if (CountOfMoneyForTomats != null) CountOfMoneyForTomats.text = fruitsHandlerScript.tomatoCount * 5 + " монет";
    }
    public void SellTomat()
    {
        FruitsHandler fruitsHandlerScript = GameObject.Find("Player").GetComponent<FruitsHandler>();
        fruitsHandlerScript.money += fruitsHandlerScript.tomatoCount * 5;
        fruitsHandlerScript.tomatoCount = 0;
    }
    public void BuySeeds()
    {
        FruitsHandler fruitsHandlerScript = GameObject.Find("Player").GetComponent<FruitsHandler>();
        if (fruitsHandlerScript.money >= 5) fruitsHandlerScript.money -= 5;
    }
    public void BuyShovel()
    {
        FruitsHandler fruitsHandlerScript = GameObject.Find("Player").GetComponent<FruitsHandler>();
        if (fruitsHandlerScript.money >= 20) fruitsHandlerScript.money -= 20;

    }
}
