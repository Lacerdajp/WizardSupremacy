using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private bool isLive;
    private Rigidbody2D body;
    private Animator anim;
    private BoxCollider2D boxcollider;

    public bool IsLive { get => isLive; set => isLive = value; }
    public Animator Anim { get => anim; set => anim = value; }
    public Rigidbody2D Body { get => body; set => body = value; }


    // Start is called before the first frame update
    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        boxcollider = GetComponent<BoxCollider2D>();
    }
    private void Start()
    {
        IsLive = true;
    }

    // Update is called once per frame
    private void Update()
    {
        if (!IsLive)
        {
            Debug.Log(isLive);
        }
        
    }
}
