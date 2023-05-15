using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopActive : MonoBehaviour
{
    [SerializeField] Canvas can;
    private void OnTriggerEnter(Collider col)
    {
        if (!col.CompareTag("Player"))
        {
            return;
        }
        can.enabled = true;
    }
    private void OnTriggerExit(Collider col)
    {
        if (!col.CompareTag("Player"))
        {
            return;
        }
        can.enabled = false;
    }
    private void Start()
    {
        can.enabled = false;
    }
}
