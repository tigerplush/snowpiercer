using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    static public UIManager instance = null;

    public GameObject remainingTime;
    public NewCarUI newCarUi;

    public void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //TimeManager.instance.TimeUp += TimeUp;
    }

    public void TimeUp()
    {
        NewCarDialogue();
    }

    public void NewCarDialogue()
    {
        newCarUi.gameObject.SetActive(true);
        remainingTime.SetActive(true);
    }
}
