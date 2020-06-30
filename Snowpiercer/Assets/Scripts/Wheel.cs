using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wheel : MonoBehaviour
{
    public Animator animator;

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("multiplier", TimeManager.instance.CurrentSpeed);
    }
}
