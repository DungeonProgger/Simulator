public class Transition
{
    public Tool.Types WorkingTool;
    public GroundBlockCondition NextCondition;
    public int Progress = 0;

    public Transition(Tool.Types workingTool, GroundBlockCondition nextCondition)
    {
        WorkingTool = workingTool;
        NextCondition = nextCondition;
    }
    public void ProgressUp(int progress)
    {
        Progress += progress;
    }
}
