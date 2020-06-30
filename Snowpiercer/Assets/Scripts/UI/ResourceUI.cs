using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceUI : MonoBehaviour
{
    public Text fundsText;
    public Text passengerText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ResourceManager manager = ResourceManager.instance;
        fundsText.text = manager.Funds.ToString("N");
        passengerText.text = manager.Passengers.ToString();
    }
}
