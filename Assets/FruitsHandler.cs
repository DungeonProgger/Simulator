using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitsHandler : MonoBehaviour
{
    public enum Type
    {
        Tomato = 1,
        Potato = 2
    };
    public int tomatoCount = 5;
    public int potatoCount = 5;
    public int money = 5;

    public void AddFruits(int count, Type type)
    {
        if (type == Type.Tomato)
            tomatoCount += count;
        else if (type == Type.Potato)
            potatoCount += count;
    }
}
