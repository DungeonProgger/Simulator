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
    [SerializeField] private GameObject BuySeedsButton;
    [SerializeField] private GameObject BuyShowelButton;
    [SerializeField] private UnityEngine.UI.Image PurchasesImage;
    [SerializeField] private UnityEngine.UI.Image PurchasesImage1;
    [SerializeField] private GameObject NewSeeds;
    private FruitsHandler fruitsHandlerScript;
    private Tool[] tools;

    private void Start()
    {
        NewSeeds.SetActive(false);
        PurchasesImage.enabled = false;
        BuySeedsButton.SetActive(true);
        BuyShowelButton.SetActive(true);
        PurchasesImage1.enabled = false;
        FruitsHandler fruitsHandlerScript = GameObject.Find("Player").GetComponent<FruitsHandler>();
        tools = FindObjectsOfType<Tool>();
    }
    private void Update()
    {
        FruitsHandler fruitsHandlerScript = GameObject.Find("Player").GetComponent<FruitsHandler>();
        if (CountOfMoneyS != null) CountOfMoneyS.text = "� ��� �� ����� " + fruitsHandlerScript.money + " �����";
        if (CountOfMoneyB != null) CountOfMoneyB.text = "� ��� �� ����� " + fruitsHandlerScript.money + " �����";
        if (CountOfTomats != null) CountOfTomats.text = fruitsHandlerScript.tomatoCount + " ��������";
        if (CountOfMoneyForTomats != null) CountOfMoneyForTomats.text = fruitsHandlerScript.tomatoCount * 5 + " �����";
    }
    public void SellTomat()
    {
        fruitsHandlerScript.money += fruitsHandlerScript.tomatoCount * 5;
        fruitsHandlerScript.tomatoCount = 0;
    }
    public void BuySeeds()
    {
        if (fruitsHandlerScript.money >= 5 && BuySeedsButton.activeSelf == true)
        {
            BuySeedsButton.SetActive(false);
            PurchasesImage.enabled = true;
            fruitsHandlerScript.money -= 5;
            NewSeeds.SetActive(true);
        }
    }
    public void BuyTool(Tool upgradedTool)
    {
        foreach (var tool in tools)
        {
            if (tool == upgradedTool)
            {
                if (fruitsHandlerScript.money >= 20 && BuyShowelButton.activeSelf == true)
                {
                    BuyShowelButton.SetActive(false);
                    PurchasesImage1.enabled = true;
                    fruitsHandlerScript.money -= 20;
                    //upgradedTool.Upgrade(100);
                }
                break;
            }
        }
    }
}
