using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    static public CameraMovement instance = null;
    public Camera thisCamera;
    public float edgeSize;
    public float moveSpeed;

    public float normalZoomLevel;
    public float closeZoomLevel;
    public float zoomSpeed;

    public float CurrentZoomLevel { get; private set; }

    private Vector3 newPosition;

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

    public void Start()
    {
        CurrentZoomLevel = normalZoomLevel;
    }

    // Update is called once per frame
    void Update()
    {
        //CurrentZoomLevel += Input.mouseScrollDelta.y * -zoomSpeed * Time.deltaTime;
        CurrentZoomLevel = Mathf.Clamp(CurrentZoomLevel, closeZoomLevel, normalZoomLevel);

        newPosition = transform.position;
        if(Input.mousePosition.x < edgeSize)
        {
            newPosition.x -= Time.deltaTime * moveSpeed;
        }
        if(Input.mousePosition.x > Screen.width - edgeSize)
        {
            newPosition.x += Time.deltaTime * moveSpeed;
        }

        newPosition.x = Mathf.Clamp(newPosition.x, (CarManager.instance.cars.Count - 1) * -4f, 0f);
        newPosition.y = Mathf.Lerp(-3f, 0f, (CurrentZoomLevel - closeZoomLevel) / (normalZoomLevel - closeZoomLevel));


    }

    public void Focus()
    {

    }

    private void LateUpdate()
    {
        transform.position = newPosition;
        thisCamera.orthographicSize = CurrentZoomLevel;
    }
}
