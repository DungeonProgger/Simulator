using System.Collections.Generic;
using UnityEngine;

public class GroundBlockCondition
{
    public List<Transition> Transitions = new List<Transition>();
    public GroundBlockCondition(Tool.Types tool,GroundBlockCondition nextCondition)
    {
        Transitions.Add(new Transition(tool, nextCondition));
    }
    public GroundBlockCondition(List<Tool.Types> tools,List<GroundBlockCondition> nextConditions)
    {
        for (int i = 0; i < tools.Count; i++)
        {
            Transitions.Add(new Transition(tools[i], nextConditions[i]));
        }   
    }
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
