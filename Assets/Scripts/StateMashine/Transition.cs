public class Transition
{
    public Tool.Types WorkingTool;
    public Seed.GroundTypes SeedTypes;
    public Condition NextCondition;
    private int _progress = 0;

    public Transition(Tool.Types workingTool, Condition nextCondition)
    {
        WorkingTool = workingTool;
        NextCondition = nextCondition;
    }

    public Transition(Seed.GroundTypes seedTypeOfGround, Condition nextCondition)
    {
        SeedTypes = seedTypeOfGround;
        NextCondition = nextCondition;
    }
    public bool ProgressUp(int progress)
    {
        _progress += progress;
        if (_progress >= 100)
        {
            _progress = 0;
            return true;
        }
        return false;
    }
}
