using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SelectionArea : MonoBehaviour
{
    [SerializeField] public int[] ZoneNumbers;
    [SerializeField] private GameObject selectobleObject;
    private PlayerInputSystem _playerInput;

    private void Start()
    {
        _playerInput = new PlayerInputSystem();

        //_playerInput.Player.LeftLeverUp.performed += ctx => InputLever(_leftLever, 15);
    }
    private void OnEnable()
    {
        _playerInput.Enable();
    }

    private void OnDisable()
    {
        _playerInput.Disable();
    }
    public void Selected()
    {
        Inventory nextInventory;
        if (selectobleObject.TryGetComponent<Inventory>(out nextInventory))
        {
            nextInventory.gameObject.SetActive(true);
        }
        else if (selectobleObject != null)
        {

        }
    }
}
