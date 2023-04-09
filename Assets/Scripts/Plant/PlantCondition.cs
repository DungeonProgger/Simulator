using UnityEngine;

public class PlantCondition : Condition
{
    public Transition Transition;

    public PlantCondition(PlantCondition nextCondition, GameObject model)
    {
        Transition = new Transition(Tool.Types.Watering—an, nextCondition);
        Model = model;
    }
} 
    