using System.Collections.Generic;
using UnityEngine;

public abstract class Condition 
{
    public GameObject Model { get; protected set; }
    public List<Transition> Transitions = new List<Transition>();
    public Transition FindTransitionWithTool(Tool.Types typeOfTool)
    {
        foreach (var transition in Transitions)
        {
            if (transition.WorkingTool == typeOfTool)
            {
                return transition;
            }
        }
        return null;
    }
}
