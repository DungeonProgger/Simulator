using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seed : MonoBehaviour
{
    public enum GroundTypes
    {
        Bads = 1,
        Pit = 2,
    }
    public enum Types
    {
        Potato = 1,
        Tomato = 2,
    }
    [SerializeField] public GroundTypes Type;

    public Plant Plant;

    private void Update()
    {
        //  if (transform.rotation)
    }
}
