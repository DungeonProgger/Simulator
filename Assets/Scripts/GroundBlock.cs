using System.Collections.Generic;
using UnityEngine;

public class GroundBlock : StateMachine
{
    [SerializeField] private GameObject _defaultModel;
    [SerializeField] private GameObject _bedsModel;
    [SerializeField] private GameObject _plantedModel;
    [SerializeField] private GameObject _pitModel;

    [SerializeField] private Transform _plantSpawnPoint;

    private GameObject currentPlant = null;

    private Condition _default;
    private Condition _plowed;
    private Condition _beds;
    private Condition _pit;
    private Condition _plantedBeds;
    private Condition _plantedPit;
    protected override void InitializationCondition()
    {
        _default = new Condition(_defaultModel);
        _plowed = new Condition(_defaultModel);
        _beds = new Condition(_bedsModel);
        _pit = new Condition(_pitModel);
        _plantedBeds = new Condition(_bedsModel);
        _plantedPit = new Condition(_plantedModel);

        _default.AddTransition(Tool.Types.Shovel, _plowed);
        _plowed.AddTransition(Tool.Types.Shovel, _pit);
        _plowed.AddTransition(Tool.Types.Rake, _beds);
        _beds.AddTransition(Seed.GroundTypes.Bads, _plantedBeds);
        _pit.AddTransition(Seed.GroundTypes.Pit, _plantedPit);
        
        ChangeCurrentCondition(_default);
    }
    private void OnTriggerEnter(Collider other)
    {
        var workingTool = other.GetComponent<Tool>();
        if (currentPlant == null)
        {
            if (workingTool != null && CurrentCondtion.FindTransitionWithTool(workingTool.Type) != null)
            {
                Worked(workingTool.Type, workingTool.Power);
            }

            var seed = other.GetComponent<Seed>();
            if (seed != null && CurrentCondtion.FindTransitionWithSeed(seed.Type) != null)
            {
                currentPlant = Instantiate(seed.Plant.gameObject, _plantSpawnPoint.position, _plantSpawnPoint.rotation);
                currentPlant.SetActive(true);
                Worked(seed.Type);
            }
        }

    }
    public void Worked(Tool.Types workingTool, int power)
    {
        Transition transition = CurrentCondtion.FindTransitionWithTool(workingTool);
        if (transition != null)
        {
            if (transition.ProgressUp(power))
            {
                ChangeCurrentCondition(transition.NextCondition);
            }
        }
    }
    public void Worked(Seed.GroundTypes seed)
    {
        Transition transition = CurrentCondtion.FindTransitionWithSeed(seed);
        if (transition != null)
        {
            ChangeCurrentCondition(transition.NextCondition);
        }
    }
}