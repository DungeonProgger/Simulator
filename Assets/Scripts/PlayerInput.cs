using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    [SerializeField] private InputActionProperty _gripValue;
    [SerializeField] private InputActionProperty _activateValue;

    private void Update()
    {
        var gripAction = _gripValue.action.ReadValue<float>();
        var activateAction = _activateValue.action.ReadValue<float>();

        _animator.SetFloat("Grip", gripAction); 
        _animator.SetFloat("Trigger", activateAction); 
    }
}
