using UnityEngine;

public abstract class Plant : StateMachine
{
    [SerializeField] protected float GrowthTime;
    protected float CurrentTime;

    protected bool isGrowingDone = false;

    public bool isGrowed { get; protected set; } = false;

    public Seed.Types Type;

    protected abstract void Growing();

    protected void Update()
    {
        Growing();
        if (isGrowingDone) Debug.Log("Need Water");
        //IconNeedWather
        if (isGrowed)
            Destroy(gameObject);
    }

    protected void OnTriggerEnter(Collider other)
    {
        var workingTool = other.GetComponent<Tool>();
        if (workingTool != null && CurrentCondtion.FindTransitionWithTool(workingTool.Type) != null )
            Worked(workingTool.Type, workingTool.Power);
    }

    protected void Worked(Tool.Types workingTool, int power)
    {
        Transition transition = CurrentCondtion.FindTransitionWithTool(workingTool);
        if (transition != null)
        {
            if (transition.ProgressUp(power) && isGrowingDone)
            {
                ChangeCurrentCondition(transition.NextCondition);
                isGrowingDone = false;
            }
        }
    }
}
