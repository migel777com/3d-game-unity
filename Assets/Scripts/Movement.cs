using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float speed = 2f;
    [SerializeField] private float turnSpeed = 45f;
    [SerializeField] private Transform targetModel;

    [SerializeField] private ConfigurableJoint rootJoint;

    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        var velocity = Vector3.forward * Input.GetAxis("Vertical") * speed;
        targetModel.transform.Translate(velocity * Time.deltaTime);
        //targetModel.transform.Rotate(Vector3.up, Input.GetAxis("Horizontal") * Time.deltaTime * turnSpeed);

        Vector3 direction = new Vector3(Input.GetAxis("Vertical"), 0f, Input.GetAxis("Horizontal")).normalized;

        float targerAngle = Mathf.Atan2(direction.z, direction.x) * Mathf.Rad2Deg;

        rootJoint.targetRotation = Quaternion.Euler(0f, targerAngle, 0f);
        animator.SetFloat("Speed", velocity.z);
    }
}
