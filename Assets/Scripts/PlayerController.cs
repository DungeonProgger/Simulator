using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Inventory _mainInventory;
    [SerializeField] private Inventory[] _otherInventories;
    private PlayerInputSystem _playerInputSystem;
    private ContinuousTurnProviderBase _rotator;
    public bool IsMoveWithStick { get; private set; }
    private void Awake()
    {
        _playerInputSystem = new PlayerInputSystem();
        _rotator = GetComponent<ContinuousTurnProviderBase>();

        _playerInputSystem.Player.OpenInventory.performed += ctx => StateInventoryChange(true);
        _playerInputSystem.Player.CloseInventory.performed += ctx => StateInventoryChange(false);

        StateInventoryChange(false);
    }
    private void Update()
    {
        IsMoveWithStick = _playerInputSystem.Player.Move.ReadValue<Vector2>().magnitude != 0;
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
        foreach (Inventory inventory in _otherInventories)
            inventory.gameObject.SetActive(false);
        _rotator.enabled = !inventoryOpen;
    }
}
