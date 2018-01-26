using UnityEngine;
using System.Collections;

public class CameraRayCaster : MonoBehaviour {


    public Transform MouseCursor;

    // Use this for initialization

    private void Start()
    {
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update ()
    {
        RaycastHit hit;
        Ray ray = Camera.main
            .ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            Vector3 objectHit = hit.point;
            MouseCursor.position = new Vector3(objectHit.x, objectHit.y, objectHit.z);
            // Do something with the object that was hit by the raycast.
        }
    }


}
