using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruits : MonoBehaviour
{   
    [SerializeField] private GameObject[] Objects;
    [SerializeField] private FruitsHandler.Type type;
    private Vector3[] _defoultPosition = new Vector3[3];
    private FruitsHandler _fruitsHandler;

    public int FruitsCount;
    private void OnEnable()
    {
        _fruitsHandler = FindObjectOfType<FruitsHandler>();
        for (int i = 0; i < Objects.Length; i++)
        {
            Objects[i].SetActive(true);
            for (int k = 0; k < Objects[i].transform.childCount; k++)
                Objects[i].transform.GetChild(k).gameObject.SetActive(true);
            _defoultPosition[i] = Objects[i].transform.position;
        }
        FruitsCount = CheckFruitsCount();
    }
    private void Update()
    {
        for (var i = 0; i < Objects.Length; i++)
            if (Objects[i] != null && (_defoultPosition[i] - Objects[i].transform.position).magnitude > 0.1f)
            {
                Destroy(Objects[i]);
                _fruitsHandler.AddFruits(1, type);
                FruitsCount = CheckFruitsCount();
            }  
    }

    private int CheckFruitsCount()
    {
        var count = -1;
        foreach (var obj in Objects)
        {
            if (obj != null)
            {
                count++;
            }
        }
        return count;
    }
}
