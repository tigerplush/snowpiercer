using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassengerCosmetics : MonoBehaviour
{
    public Animator animator;

    public float speed = 4f;

    private Vector3 target;
    private float carCenter = 0f;
    private bool isMoving = false;

    public void Start()
    {
        carCenter = transform.position.x;
    }

    public void Setup(AnimatorOverrideController controller)
    {
        animator.runtimeAnimatorController = controller;
    }

    public void Update()
    {
        Move();
    }

    public void Shift(float length)
    {
        Vector3 shift = new Vector3(length, 0f, 0f);
        transform.position -= shift;
        target -= shift;
        carCenter -= length;
    }

    private void Move()
    {
        if (isMoving)
        {
            Vector3 distance = target - transform.position;
            animator.SetFloat("Horizontal", Mathf.Sign(distance.x));

            if(distance.magnitude <= 0.1f)
            {
                isMoving = false;
                animator.SetBool("IsMoving", isMoving);
            }
            else
            {
                transform.position += new Vector3(Time.deltaTime * speed * Mathf.Sign(distance.x), 0f, 0f);
            }
        }
        else if(Random.value < 0.01f)
        {
            target = transform.position;
            target.x = carCenter + Random.value * 4f - 2f;
            isMoving = true;
            animator.SetBool("IsMoving", isMoving);
        }
    }
}
