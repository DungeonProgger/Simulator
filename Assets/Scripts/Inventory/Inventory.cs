using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Inventory : MonoBehaviour
{
    [SerializeField] private SelectionArea[] areas;
    private Dictionary<int, SelectionArea> selectionAreas = new Dictionary<int, SelectionArea>();
    private PlayerInputSystem _playerInput;
    private double _degree;
    private double degree
    {
        get { return _degree; }
        set 
        {
            if (value > 330)
                _degree = 12;
            else if (value > 300)
                _degree = 11;
            else if (value > 270)
                _degree = 10;
            else if (value > 240)
                _degree = 9;
            else if (value > 210)
                _degree = 8;
            else if (value > 180)
                _degree = 7;
            else if (value > 150)
                _degree = 6;
            else if (value > 120)
                _degree = 5;
            else if (value > 90)
                _degree = 4;
            else if (value > 60)
                _degree = 3;
            else if (value > 30)
                _degree = 2;
            else if (value > 0)
                _degree = 1;
        }
    }
    private void OnEnable()
    {
        _playerInput.Enable();
    }
    private void OnDisable()
    {
        _playerInput.Disable();
    }
    private void Start()
    {
        _playerInput = new PlayerInputSystem();
        foreach (var area in areas)
            foreach (var zoneNumber in area.ZoneNumbers)
                selectionAreas.Add(zoneNumber, area);
    }
    private void Update()
    {
        Vector2 axisValue = _playerInput.UI.ChooseLeftArea.ReadValue<Vector2>();
    }
    private void ChooseArea(int zone)
    {
        SelectionArea currentSelectionArea;
        if (selectionAreas.TryGetValue(zone, out currentSelectionArea))
        {
            currentSelectionArea.Selected();
        }
        this.gameObject.SetActive(false);
    }
}
