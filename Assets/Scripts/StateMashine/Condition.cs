using System.Collections.Generic;
using UnityEngine;

public class Condition 
{
    public GameObject Model;
    public List<Transition> Transitions = new List<Transition>();

    public Condition(GameObject model)
    {
        Model = model;
    }
    public void AddTransition(Tool.Types tool, Condition nextCondition)
    {
        Transitions.Add(new Transition(tool, nextCondition));
    }

    public void AddTransition(Seed.GroundTypes seed, Condition nextCondition)
    {
        Transitions.Add(new Transition(seed, nextCondition));
    }

    public Transition FindTransitionWithTool(Tool.Types typeOfTool)
    {
        foreach (var transition in Transitions)
        {
            if (transition.WorkingTool == typeOfTool || transition.WorkingTool == Tool.Types.Any)
            {
                return transition;
            }
        }
        return null;
    }

    public Transition FindTransitionWithSeed(Seed.GroundTypes seedTypeOfGround)
    {
        foreach (var transition in Transitions)
        {
            if (transition.SeedTypes == seedTypeOfGround)
            {
                return transition;
            }
        }
        return null;
    }
}
