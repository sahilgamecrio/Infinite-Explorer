using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayManager : MonoBehaviour
{
    [SerializeField] Transform origin;
    Vector3 inputVector = Vector3.zero;

    private void FixedUpdate()
    {
        //RaycastHit hit;
        //if (Physics.Raycast(transform.position, transform.forward, out hit, 1f))
        //{
        //    curruntTilepos = hit.transform.position;
        //}
        Debug.DrawRay(transform.position,transform.forward * 30, Color.red);
        RaycastHit[] hits;
        hits = Physics.RaycastAll(transform.position,transform.forward, 30f);
        Debug.Log(hits.Length);
        //Debug.Log(origin.localEulerAngles.y);
        if (hits.Length <= 3 && hits.Length>0)
        {
            if (origin.localEulerAngles.y <1 && origin.localEulerAngles.y>-1)
            {
                Grasstilespawner.Instance.addSingleTile(hits[hits.Length - 1].transform.position, true,10);
            }
            else if (origin.localEulerAngles.y > 89 && origin.localEulerAngles.y<91)
            {
                Grasstilespawner.Instance.addSingleTile(hits[hits.Length - 1].transform.position, false,10);
            }
            else if(origin.localEulerAngles.y >269 && origin.localEulerAngles.y<271)
            {
                Grasstilespawner.Instance.addSingleTile(hits[hits.Length - 1].transform.position, false, -10);
            }
            else if(origin.localEulerAngles.y < 181 && origin.localEulerAngles.y>179)
            {
                Grasstilespawner.Instance.addSingleTile(hits[hits.Length - 1].transform.position, true, -10);
            }
        }
    }
}
