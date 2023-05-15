using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WateringCan : Tool
{
    public override Types Type { get; protected set; }

    private void Awake()
    {
        Type = Types.Watering—an;
    }
}
