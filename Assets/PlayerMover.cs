using UnityEngine;
using System.Collections;

public class PlayerMover : MonoBehaviour
{

    public float moveSpeed = 5f;

   
    CameraRayCaster cameraRayCaster;

    bool startMoving;

    Vector3 targetPostion = Vector3.zero;

	// Use this for initialization
	void Start ()
    {
        cameraRayCaster = GameObject.FindObjectOfType<CameraRayCaster>();
        startMoving = false;

    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetMouseButtonDown(0))
        {
            targetPostion = cameraRayCaster.GetCurrentMousePosition();
            startMoving = true;
        }

        if (startMoving)
        {
            float step = moveSpeed * Time.deltaTime;

            transform.position = Vector3.MoveTowards(transform.position, targetPostion, step);

            if (Vector3.Distance(transform.position,targetPostion) <= 0)
            {
                startMoving = false;
             
            }
        }
	}
}
