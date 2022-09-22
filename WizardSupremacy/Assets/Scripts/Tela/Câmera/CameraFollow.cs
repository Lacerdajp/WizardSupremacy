using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private float minimoX;
    [SerializeField] private float minimoY;
    [SerializeField] private float maximoX;
    [SerializeField] private float maximoY;
    public Transform target;

    private void Start()
    {
        
    }
    void Update()
    {
       transform.position=new Vector3(Mathf.Clamp(target.position.x,minimoX,maximoX),
                                      Mathf.Clamp(target.position.y,minimoY,maximoY),
                                      transform.position.z);
       
    }
}
