using UnityEngine;

public abstract class Tool : MonoBehaviour
{
    public enum Types
    {
        Any = 0,
        Rake = 1,
        Shovel = 2,
        Watering—an = 3,
    }
    public abstract Types Type { get; protected set; }
    [SerializeField] public int Power;

}
