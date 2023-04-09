using UnityEngine;

public abstract class Plant : MonoBehaviour
{
    public enum Types
    {
        Potato = 1,
        Tomato = 2,
    }

    [SerializeField] private GameObject _1Model;
    [SerializeField] private GameObject _2Model;
    [SerializeField] private GameObject _3Model;

    private Transform[] _models;

    private static PlantCondition _currentCondtion;

    public abstract Types Type { get; protected set;}

    private PlantCondition Condition1;
    private PlantCondition Condition2;
    private PlantCondition Condition3;

    private void Awake()
    {
        _models = gameObject.GetComponentsInChildren<Transform>();

        Condition1 = new PlantCondition(Condition2,_1Model);
        Condition2 = new PlantCondition(Condition2,_2Model);
        Condition3 = new PlantCondition(Condition2,_3Model);
        
        ChangeCurrentCondition(Condition1);
    }
    private void ChangeCurrentCondition(PlantCondition newCondition)
    {
        _currentCondtion = newCondition;
        ChangeModel(_currentCondtion.Model);
    }

    private void ChangeModel(GameObject newModel)
    {
        foreach (var model in _models)
            if (model.gameObject != this.gameObject)
                model.gameObject.SetActive(false);
        newModel.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        var workingTool = other.GetComponent<Tool>();
        if (workingTool.Type == Tool.Types.Watering—an)
            Worked(workingTool.Power);
    }
    public void Worked(int power)
    {
        Transition transition = _currentCondtion.FindTransitionWithTool(Tool.Types.Watering—an);
        if (transition != null)
        {
            if (transition.ProgressUp(power))
            {
                ChangeCurrentCondition((PlantCondition)transition.NextCondition);
            }
        }
    }
}
