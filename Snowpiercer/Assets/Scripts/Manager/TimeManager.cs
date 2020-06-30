using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TimeManager : MonoBehaviour
{
    static public TimeManager instance = null;

    public float timeToFirstStop = 30f;
    public float timeBetweenStops = 180f;
    public float cruisingSpeed = 10f;

    public float accelerationTime;
    public float decelerationTime;

    public float RemainingTime { get; private set; }
    public float CurrentSpeed { get; private set; }
    public bool isRunning = false;
    public bool isRunningEndless = true;

    private bool decelerationQueried = false;

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
        this.RemainingTime = this.timeToFirstStop;
        this.CurrentSpeed = this.cruisingSpeed;

        TaskManager.instance.lastTask += StartTimer;
    }

    // Update is called once per frame
    void Update()
    {
        if(this.isRunning && !this.isRunningEndless)
        {
            this.RemainingTime -= Time.deltaTime;
            if (this.RemainingTime < 0f)
            {
                this.RemainingTime = timeBetweenStops;
                this.isRunning = false;
                TaskManager.instance.StartTasks();
            }
            else if(this.RemainingTime < this.decelerationTime)
            {
                this.CurrentSpeed = this.RemainingTime * this.cruisingSpeed / this.decelerationTime;
                if(!this.decelerationQueried)
                {
                    SoundManager.instance.Decelerate();
                    this.decelerationQueried = true;
                }
            }
        }
    }

    public void StartTimer()
    {
        this.RemainingTime = timeBetweenStops;
        this.isRunning = true;
        this.decelerationQueried = false;
        StartCoroutine(Accelerate());
        SoundManager.instance.Accelerate();
    }

    public IEnumerator Accelerate()
    {
        for(float i = 0f; i < this.accelerationTime; i += Time.deltaTime)
        {
            this.CurrentSpeed = i * this.cruisingSpeed / this.accelerationTime;
            yield return null;
        }
    }

    public void Halt(float remainingTime = -1f)
    {
        if(remainingTime < 0f)
        {
            remainingTime = this.decelerationTime;
        }
        this.isRunningEndless = false;
        this.RemainingTime = remainingTime;
    }
}
