using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Inventory _mainInventory;
    private PlayerInputSystem _playerInputSystem;
    private ContinuousTurnProviderBase _rotator;
    private bool _inventoryIsOpen = false;
    private void Awake()
    {
        _playerInputSystem = new PlayerInputSystem();


        _playerInputSystem.Player.OpenInventory.performed += ctx => StateInventoryChange(true);
        _playerInputSystem.Player.CloseInventory.performed += ctx => StateInventoryChange(false);
    }
    private void OnEnable()
    {
        _playerInputSystem.Enable();
    }

    private void OnDisable()
    {
        _playerInputSystem.Disable();
    }

    private void StateInventoryChange(bool inventoryOpen)
    {
        _mainInventory.gameObject.SetActive(inventoryOpen);
        _rotator.enabled = !inventoryOpen;
    }
}
