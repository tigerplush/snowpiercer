using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class TaskManager : MonoBehaviour
{
    static public TaskManager instance;

    public delegate void LastTaskHandler();
    public LastTaskHandler lastTask;

    //public List<Action> taskList = new List<Action>();

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void Start()
    {
        //taskList.Add(CarManager.instance.AddCar);
        //taskList.Add(FamilyManager.instance.ShowFamilySelectionDialogue);
        //taskList.Add(CarManager.instance.ShowCarSelectionDialogue);
        
    }

    public void StartTasks()
    {
        StartCoroutine(NextTask());
    }

    private IEnumerator NextTask()
    {
        yield return StartCoroutine(FamilyManager.instance.Income());
        yield return StartCoroutine(CarManager.instance.AddCar());
        yield return StartCoroutine(FamilyManager.instance.ShowFamilySelectionDialogue());
        yield return StartCoroutine(CarManager.instance.ShowCarSelectionDialogue());
        lastTask?.Invoke();
    }
}
