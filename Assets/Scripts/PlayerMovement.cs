using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]Transform RayOrigin;
    Rigidbody rb;
    const float _speed = 7f;
    float horizontalInput;
    float verticalInput;
    //int collidercount;
    Vector3 curruntTilepos = Vector3.zero;
    Vector3 inputVector = Vector3.zero;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        
        RaycastHit hit;
        if (Physics.Raycast(RayOrigin.position,RayOrigin.forward,out hit,1f))
        {
            curruntTilepos = hit.transform.position ;
        }
        RaycastHit[] hits;
        hits = Physics.RaycastAll(RayOrigin.transform.position, RayOrigin.forward, 30f);
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = horizontalInput == 0 ? Input.GetAxisRaw("Vertical") : 0;
        inputVector = new Vector3(horizontalInput,0,verticalInput);
        
        rb.velocity = new Vector3(horizontalInput * _speed,rb.velocity.y,verticalInput*_speed);
        
        
        if (inputVector.magnitude != 0) 
        {
            float angle = (Mathf.Atan2(verticalInput, -horizontalInput) * Mathf.Rad2Deg) - 90;
            RayOrigin.transform.rotation = Quaternion.AngleAxis(angle, Vector3.up); 
        }
        Debug.DrawRay(RayOrigin.position, RayOrigin.transform.forward *30, Color.green);
        Debug.Log(hits.Length);
        //if(hits.Length > 0) Debug.Log(hits[hits.Length - 1].transform.position);
        if (hits.Length <= 3)
        {
            if (inputVector.z != 0 && inputVector.x == 0)
            {
                Grasstilespawner.Instance.AddTiles(hits[hits.Length - 1].transform.position + inputVector * 10f, Vector3.right);
            }
            else if (inputVector.x != 0 && inputVector.z == 0)
            {
                Grasstilespawner.Instance.AddTiles(hits[hits.Length - 1].transform.position + inputVector * 10f, Vector3.forward);
            }
        }
    }
}
