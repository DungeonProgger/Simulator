using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    private void Sell()
    {
       GameObject.Find("Player").GetComponent<Inventory>().tomat--;
    }
}
