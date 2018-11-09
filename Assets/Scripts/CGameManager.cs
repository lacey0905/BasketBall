using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CGameManager : MonoBehaviour {

    private Vector3 mouseWorldPoint = Vector3.zero;
    private Vector3 clickMousePoint = Vector3.zero;
    private Vector3 distance = Vector3.zero;

    private LineRenderer lineRenderer;


    public GameObject Ball;

    Rigidbody ballRd;


    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();

        ballRd = Ball.GetComponent<Rigidbody>();
    }

    private void Start()
    {
        
    }

    void Update()
    {

        

        if (Input.GetMouseButtonDown(0))
        {
            
            mouseWorldPoint = Camera.main.ScreenToWorldPoint(
                new Vector3(
                    Input.mousePosition.x,
                    Input.mousePosition.y,
                    -Camera.main.transform.position.z
                )
            );
            clickMousePoint = mouseWorldPoint;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            distance = clickMousePoint - mouseWorldPoint;
            float power = Vector3.Distance(clickMousePoint, mouseWorldPoint);
            if(power > 5f)
            {
                power = 5f;
            }
            ballRd.velocity = Vector3.zero;
            ballRd.AddForce(distance.normalized * (power * 5f), ForceMode.Impulse);

            ballRd.AddTorque(Vector3.up * 100f);

            clickMousePoint = Vector3.zero;
        }

        if (Input.GetMouseButton(0))
        {
            mouseWorldPoint = Camera.main.ScreenToWorldPoint(
                new Vector3(
                    Input.mousePosition.x,
                    Input.mousePosition.y,
                    -Camera.main.transform.position.z
                )
            );

            

            lineRenderer.SetPosition(0, clickMousePoint);
            lineRenderer.SetPosition(1, mouseWorldPoint);

        }
       
    }
}
