using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMovement : MonoBehaviour
{
    [SerializeField]Transform Target;
    Vector3 offset = new Vector3(0, 20, -12);
    private void Start()
    {
        transform.position = Target.position+ offset;
    }
    private void LateUpdate()
    {
        transform .position = Target.position+offset;
    }
}
