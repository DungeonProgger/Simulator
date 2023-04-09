public class Transition
{
    public Tool.Types WorkingTool;
    public Condition NextCondition;
    private int _progress = 0;

    public Transition(Tool.Types workingTool, Condition nextCondition)
    {
        WorkingTool = workingTool;
        NextCondition = nextCondition;
    }
    public bool ProgressUp(int progress)
    {
        _progress += progress;
        if (_progress > 100)
            return true;
        return false;
    }
}
