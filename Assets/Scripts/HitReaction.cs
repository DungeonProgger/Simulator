using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitReaction : MonoBehaviour
{
    private void OnTriggerEnter(Collider col)
    {
        if (!col.CompareTag("Tool"))
        {
            return;
        }
        gameObject.GetComponent<Animator>().SetTrigger("Start");
    }
    private void OnTriggerExit(Collider col)
    {
        if (!col.CompareTag("Tool"))
        {
            return;
        }
        gameObject.GetComponent<Animator>().SetTrigger("Stop");
    }    
}
