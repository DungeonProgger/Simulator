using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class SelectionArea : MonoBehaviour
{
    [SerializeField] public int[] ZoneNumbers;
    [SerializeField] private GameObject selectobleObject;
    [SerializeField] private Color defaultColor;
    [SerializeField] private Color selectableColor;
    [SerializeField] private Image background;

    private void Start()
    {
        background.color = defaultColor;
    }
    public void Choosed()
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
    public void Selected()
    {

    }
}
