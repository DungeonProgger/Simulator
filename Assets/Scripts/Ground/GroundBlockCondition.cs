using System.Collections.Generic;
using UnityEngine;

public class GroundBlockCondition : Condition
{
    public GroundBlockCondition(Tool.Types tool,GroundBlockCondition nextCondition, GameObject model)
    {
        Transitions.Add(new Transition(tool, nextCondition));
        Model = model;
    }
    public GroundBlockCondition(List<Tool.Types> tools,List<GroundBlockCondition> nextConditions, GameObject model)
    {
        for (int i = 0; i < tools.Count; i++)
        {
            Transitions.Add(new Transition(tools[i], nextConditions[i]));
        }
        Model = model;
    }
    
}
