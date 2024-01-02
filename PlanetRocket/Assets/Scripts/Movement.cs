using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float speed = 1f;
    [SerializeField] private float rotateSpeed = 10f;
    Rigidbody rocketRigid;
    // Start is called before the first frame update
    void Start()
    {
        rocketRigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    void ProcessThrust()
    {
        if(Input.GetKey(KeyCode.Space)){
            Debug.Log("스페이스바 눌림");
            if(rocketRigid != null) rocketRigid.AddRelativeForce(Vector3.up * speed * Time.deltaTime);
        }
    }

    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            Debug.Log("왼쪽으로 회전");
            ApplyRotation(rotateSpeed);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            Debug.Log("오른쪽으로 회전");
            ApplyRotation(-rotateSpeed);
        }
    }

    void ApplyRotation(float rotationThisFram)
    {
        rocketRigid.freezeRotation = true; // 다른 물체와 부딪혔을때 반발력을 없애 회전에 문제가 없도록 하기 위함
        transform.Rotate(Vector3.forward * rotationThisFram * Time.deltaTime);
        rocketRigid.freezeRotation = false; // 다시 풀어서 회전에 문제 없도록 함
    }
}
