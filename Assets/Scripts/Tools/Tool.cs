using UnityEngine;

public abstract class Tool : MonoBehaviour
{
    public enum Types
    {
        Rake = 1,
        Shovel = 2,
    }
    protected enum InteractionsWithLayers
    {
        Ignore = 1,
        Work = 2,
        Collide = 3,
    }
    [SerializeField] protected Types TypeOfTool;
    [SerializeField] protected int Power;
    [SerializeField] protected GameObject Trigger;
    [SerializeField] protected GameObject Collider;
    private void OnTriggerEnter(Collider other)
    {
        GroundBlock.Worked(TypeOfTool, Power);
    }
    public void ChangeState(bool isOnHand)
    {
        Collider.SetActive(false);
        Trigger.SetActive(false);
        if (isOnHand)
            Trigger.SetActive(true);
        else
            Collider.SetActive(true);
    }
}
