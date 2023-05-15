using UnityEngine;
public abstract class StateMachine : MonoBehaviour
{
    protected Condition CurrentCondtion;

    protected Transform[] Models;

    private void Awake()
    {
        Models = gameObject.GetComponentsInChildren<Transform>();
        InitializationCondition();
    }
    protected virtual void InitializationCondition()
    {
    }

    protected virtual void ChangeCurrentCondition(Condition newCondition)
    {
        CurrentCondtion = newCondition;
        ChangeModel(CurrentCondtion.Model);
    }

    protected void ChangeModel(GameObject newModel)
    {
        foreach (var model in Models)
            if (model.gameObject != this.gameObject && model.gameObject.tag != "SpawnPoint")
                model.gameObject.SetActive(false);
        newModel.SetActive(true);
        for (int i = 0; i < newModel.transform.childCount; i++)
            newModel.transform.GetChild(i).gameObject.SetActive(true);
    }
}
