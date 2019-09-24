using UnityEngine;
using UnityEngine.UI;

public class PinchZoom : MonoBehaviour
{
    public float perspectiveZoomSpeed = 0.5f;  // The rate of change of the field of view in perspective mode.
    public float orthoZoomSpeed = 0.5f;        // The rate of change of the orthographic size in orthographic mode.
    public Text zoom;

    void Update()
    {
        // If there are two touches on the device...
        if (Input.touchCount == 2)
        {
            // Store both touches.
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);

            // Find the position in the previous frame of each touch.
            Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
            Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;


            // Find the magnitude of the vector (the distance) between the touches in each frame.
            float prevTouchDeltaMag = (touchZeroPrevPos - touchOnePrevPos).magnitude;
            float touchDeltaMag = (touchZero.position - touchOne.position).magnitude;

            // Find the difference in the distances between each frame.
            float deltaMagnitudeDiff = prevTouchDeltaMag - touchDeltaMag;

            // If the camera is orthographic...
            if (GetComponent<Camera>().orthographic)
            {
                // ... change the orthographic size based on the change in distance between the touches.
                GetComponent<Camera>().orthographicSize += deltaMagnitudeDiff * orthoZoomSpeed;
                // Make sure the orthographic size never drops below zero.
                GetComponent<Camera>().orthographicSize = Mathf.Max(GetComponent<Camera>().orthographicSize, 0.1f);
            }
            else
            {
                zoom.text = "camera not ortho";
                // Otherwise change the field of view based on the change in distance between the touches.
                GetComponent<Camera>().fieldOfView += deltaMagnitudeDiff * perspectiveZoomSpeed;

                // Clamp the field of view to make sure it's between 0 and 180.
                GetComponent<Camera>().fieldOfView = Mathf.Clamp(GetComponent<Camera>().fieldOfView, 0.1f, 179.9f);
            }
        }
    }
}


/**
   Vector3 touchStart;
   public float zoomOutMin = 1;
   public float zoomOutMax = 8;

   public void Update()
   {
       if (Input.GetMouseButtonDown(0))
       {
           touchStart = Camera.main.ScreenToWorldPoint(Input.mousePosition);
       }
       if (Input.touchCount == 2)
       {
           Touch touchZero = Input.GetTouch(0);
           Touch touchOne = Input.GetTouch(1);

           Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
           Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

           float prevMagnitude = (touchZeroPrevPos - touchOnePrevPos).magnitude;
           float currentMagnitude = (touchZero.position - touchOne.position).magnitude;

           float difference = currentMagnitude - prevMagnitude;
           zoom(difference * 0.01f);
       }
       zoom(Input.GetAxis("Mouse ScrollWheel"));
   }

   void zoom(float _increment)
   {
       Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize - _increment, zoomOutMin, zoomOutMax);
   }
   */


/**
public float orthoZoomSpeed = 1.0f;
public float zoomPercentage; //Controls zoom speed


void Update()
{
    zoomPercentage = (Camera.main.orthographicSize / 50.0f);

    if (Input.touchCount == 2)
    {
        Touch touchZero = Input.GetTouch(0);
        Touch touchOne = Input.GetTouch(1);

        Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
        Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

        float prevTouchDeltaMag = (touchZeroPrevPos - touchOnePrevPos).magnitude;
        float touchDeltaMag = (touchZero.position - touchOne.position).magnitude;

        float deltaMagnitudeDiff = prevTouchDeltaMag - touchDeltaMag;

        Camera.main.orthographicSize += deltaMagnitudeDiff * orthoZoomSpeed * zoomPercentage;
        Camera.main.orthographicSize = Mathf.Max(Camera.main.orthographicSize, 5.0f);
        Camera.main.orthographicSize = Mathf.Min(Camera.main.orthographicSize, 50.0f);
    }
}
*/
