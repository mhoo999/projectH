using UnityEngine;

public class RotateAndZoom : MonoBehaviour
{
    public float rotationSpeed = 100f; // 회전 속도
    public float zoomSpeed = 0.1f; // 확대/축소 속도
    public float minScale = 0.5f; // 최소 크기 제한
    public float maxScale = 2.0f; // 최대 크기 제한

    private Vector3 initialScale;

    void Start()
    {
        initialScale = transform.localScale;
    }

    void Update()
    {
        RotateObject();
        ZoomObject();
    }

    void RotateObject()
    {
        if (Input.GetMouseButton(0)) // 마우스 좌클릭 상태일 때만 회전
        {
            float XaxisRotation = Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;
            float YaxisRotation = Input.GetAxis("Mouse Y") * rotationSpeed * Time.deltaTime;

            transform.Rotate(Vector3.up, -XaxisRotation, Space.World);
            transform.Rotate(Vector3.right, YaxisRotation, Space.World);
        }
    }

    void ZoomObject()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (scroll != 0)
        {
            Vector3 newScale = transform.localScale + Vector3.one * scroll * zoomSpeed;

            // 정확한 최소/최대 제한 적용
            float clampedScale = Mathf.Clamp(newScale.x, initialScale.x * (minScale / 2), initialScale.x * (maxScale / 2));
            transform.localScale = new Vector3(clampedScale, clampedScale, clampedScale);
        }
    }

}
