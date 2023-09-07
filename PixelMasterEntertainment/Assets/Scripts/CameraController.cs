using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float rotationSpeed = 1f; 

    private Vector2 touchStartPos;
    private bool isRotating = false;

    private void Update()
    {
        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    touchStartPos = touch.position;
                    isRotating = true;
                    break;

                case TouchPhase.Moved:
                    if (isRotating)
                    {
                        float rotationY = touch.deltaPosition.x * rotationSpeed * Time.deltaTime;

                        transform.RotateAround(target.position, Vector3.up, rotationY);
                    }
                    break;

                case TouchPhase.Ended:
                    isRotating = false;
                    break;
            }
        }
    }
}
