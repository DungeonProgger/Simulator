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
    public int tomatoCount { get; private set; } = 0;
    public int potatoCount { get; private set; } = 0;
    public int money { get; private set; } = 0;

    public void AddFruits(int count, Type type)
    {
        if (type == Type.Tomato)
            tomatoCount += count;
        else if (type == Type.Potato)
            potatoCount += count;
    }

    public void AddMoney(int count)
    {
        money += count;
    }
}
