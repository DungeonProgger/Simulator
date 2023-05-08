using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class IntetavtableObjectPhysics : MonoBehaviour
{
    [SerializeField] protected Transform _defaultTarget;
    [SerializeField] private int strength;
    [SerializeField] private int damping;
    private TwoHandGrabInteractable _twoHandGrabInteractable;
    protected Transform _currentTarget;
    protected Rigidbody _rigidbody;
    protected void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _currentTarget = _defaultTarget;
        _twoHandGrabInteractable = _defaultTarget.GetComponent<TwoHandGrabInteractable>();
    }
    protected void FixedUpdate()
    {
        if (_twoHandGrabInteractable.isSelected)
        {
            _rigidbody.useGravity = false;
            var positionDelta = _currentTarget.position - _rigidbody.position;
            var force = positionDelta * strength - _rigidbody.velocity * damping;
            _rigidbody.AddForce(force);

            //transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(positionDelta), 100 * Time.fixedDeltaTime);

            var rotationDifference = _currentTarget.rotation * Quaternion.Inverse(transform.rotation);
            rotationDifference.ToAngleAxis(out float angleDegree, out Vector3 rotationAxis);

            if (angleDegree > 180)
                angleDegree -= 360;

            var rotationDifferenceInDegree = angleDegree * rotationAxis;

            _rigidbody.angularVelocity = rotationDifferenceInDegree * Mathf.Deg2Rad / Time.fixedDeltaTime;
        }
        else
        {
            _rigidbody.useGravity = true;
        }
    }
    // позициониравть руку в точке во время движения, и просчитывать физику в момент остановкки.
    // строить лучи и находить точки пересечения с объектами
}

