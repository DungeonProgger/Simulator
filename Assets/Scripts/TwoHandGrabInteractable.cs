using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class TwoHandGrabInteractable : XRGrabInteractable
{
    [SerializeField] private Transform _mainModel;
    [SerializeField] private IXRSelectInteractor _leftHand;
    [SerializeField] private IXRSelectInteractor _rightHand;
    private void Update()
    {
        if (!isSelected)
        {
            transform.position = _mainModel.position;
            transform.rotation = _mainModel.rotation;
        }
        else
        {
            if (IsSelectableBy(_leftHand))
            {
                Debug.Log(_leftHand);
            }
            else if (IsSelectableBy(_rightHand))
            {
                Debug.Log(_rightHand);
            }
        }
    }
}
