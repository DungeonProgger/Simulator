using System.Collections;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class CollisionTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(ReloadingXRGrab());
    }

    IEnumerator ReloadingXRGrab()
    {
        transform.parent.GetComponent<XRGrabInteractable>().enabled = false;
        yield return new WaitForSeconds(0.1f);
        transform.parent.GetComponent<XRGrabInteractable>().enabled = true; 
    }
}
