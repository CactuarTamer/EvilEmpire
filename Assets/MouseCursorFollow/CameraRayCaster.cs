using UnityEngine;
using System.Collections;

public class CameraRayCaster : MonoBehaviour {


    public Transform MouseCursor;

    Vector3 objectHit;

    // Use this for initialization

    private void Start()
    {
        
    }

    // Update is called once per frame
    void Update ()
    {
        RaycastHit hit;
        Ray ray = Camera.main
            .ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            objectHit = hit.point;
            objectHit.z = 0;
            MouseCursor.position = new Vector3(objectHit.x, objectHit.y, 0);
            // Do something with the object that was hit by the raycast.
        }
    }

    public Vector3 getMouseVectorPostion()
    {
        
        return objectHit;
    }


}
