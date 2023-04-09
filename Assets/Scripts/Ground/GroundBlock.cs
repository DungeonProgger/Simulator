using UnityEngine;

public class GroundBlock : MonoBehaviour
{
    [SerializeField] private GameObject _defaultModel;
    [SerializeField] private GameObject _bedsModel;
    [SerializeField] private GameObject _plantedModel;
    [SerializeField] private GameObject _pitModel;

    private GroundBlockCondition _groundWithWeeds;
    private GroundBlockCondition _untilledGround;

    private static GroundBlockCondition _currentCondtion;

    private Transform[] _models;

    private void Awake()
    {
        _models = gameObject.GetComponentsInChildren<Transform>();

        _groundWithWeeds = new GroundBlockCondition(Tool.Types.Rake, _untilledGround,_defaultModel);
        _untilledGround = new GroundBlockCondition(Tool.Types.Rake, _groundWithWeeds, _defaultModel);

        ChangeCurrentCondition(_groundWithWeeds);
    }
    private void OnTriggerEnter(Collider other)
    {
        var workingTool = other.GetComponent<Tool>();
        if (workingTool != null)
            Worked(workingTool.Type,workingTool.Power);
    }
    public void Worked(Tool.Types workingTool, int power)
    {
        Transition transition = _currentCondtion.FindTransitionWithTool(workingTool);
        if (transition != null)
        {
            if (transition.ProgressUp(power))
            {
                ChangeCurrentCondition((GroundBlockCondition)transition.NextCondition);
            }
        }
    }

    private void ChangeCurrentCondition(GroundBlockCondition newCondition)
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
}