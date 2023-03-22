using UnityEngine;

public class GroundBlock : MonoBehaviour
{
    private GroundBlockCondition _groundWithWeeds;
    private GroundBlockCondition _untilledGround;

    private static GroundBlockCondition _currentCondtion;

    private void Start()
    {
        _groundWithWeeds = new GroundBlockCondition(Tool.Types.Rake, _untilledGround);
        _untilledGround = new GroundBlockCondition(Tool.Types.Rake, _groundWithWeeds);
        _currentCondtion = _groundWithWeeds;
    }
    public static void Worked(Tool.Types workingTool, int power)
    {
        Transition transition = _currentCondtion.FindTransitionWithTool(workingTool);
        if (transition != null)
        {
            transition.ProgressUp(power);

            if (transition.Progress >= 100)
            {
                _currentCondtion = transition.NextCondition;
            }
        }
    }
}
    