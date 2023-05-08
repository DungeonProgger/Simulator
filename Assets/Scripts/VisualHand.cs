using UnityEngine;

public class VisualHand : MonoBehaviour
{
    [SerializeField] private Transform _physicsHand;
    [SerializeField] private int _speed;
    [SerializeField] private int _rotationSpeed;
    private void Update()
    {
        transform.position = _physicsHand.position;
        transform.rotation = _physicsHand.rotation;
    }
}
