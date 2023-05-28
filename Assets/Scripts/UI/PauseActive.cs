using UnityEngine;

public class PauseActive : MonoBehaviour
{
    [SerializeField] private GameObject PauseScreen;
    private PlayerInputSystem _playerInputSystem;
    private void Start()
    {
        PauseScreen.SetActive(false);

        _playerInputSystem = new PlayerInputSystem();
        _playerInputSystem.Player.OpenPause.performed += ctx => OpenPause();
    }

    private void OpenPause()
    {
        PauseScreen.SetActive(true);
    }

    private void OnEnable()
    {
        _playerInputSystem.Enable();
    }

    private void OnDisable()
    {
        _playerInputSystem.Disable();
    }
}

