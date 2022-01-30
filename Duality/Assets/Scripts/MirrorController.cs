using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorController : MonoBehaviour
{
    public float MoveSpeed;

    public GameObject LeftObject;
    private PlayerController _lController;

    public GameObject RightObject;
    private PlayerController _rController;

    private float horizontal;
    private float vertical;

    // Start is called before the first frame update
    void Start()
    {
        // animator = GetComponentInChildren<Animator>();
        _lController = LeftObject.GetComponentInChildren<PlayerController>();
        _rController = RightObject.GetComponent<PlayerController>(); 
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        // if (Input.GetAxis("Horizontal") < 0) 
        // {
        //     Debug.Log("flip x");
        //     if(transform.rotation.eulerAngles.z != -90) 
        //     {
        //         transform.localRotation = Quaternion.Euler(0,0,-90);
        //     }
        // }
        // else if (Input.GetAxis("Horizontal") > 0)
        // {
        //     Debug.Log("dont flip x");
        //     if(transform.rotation.eulerAngles.z != 90) 
        //     {
        //         transform.localRotation = Quaternion.Euler(0,0,90);

        //     }
        // }
        // else if (Input.GetAxis("Vertical") > 0) 
        // {
        //     Debug.Log("flip y");
        //     transform.localRotation = Quaternion.Euler(0,0,0);
        //     _sr.flipY = true;
        // }
        // else if (Input.GetAxis("Vertical") < 0)
        // {
        //     Debug.Log("dont flip y");
        //     transform.localRotation = Quaternion.Euler(0,0,0);
        //     _sr.flipY = false;
        // }
    }

    private void FixedUpdate()
    {  
        _lController.AttemptMove(horizontal, vertical, MoveSpeed);
        _rController.AttemptMove(horizontal * -1, vertical, MoveSpeed);
        
    }
}
