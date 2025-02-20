using UnityEngine;

public class RotateAndZoom : MonoBehaviour
{
    public float rotationSpeed = 100f; // ȸ�� �ӵ�
    public float zoomSpeed = 0.1f; // Ȯ��/��� �ӵ�
    public float minScale = 0.5f; // �ּ� ũ�� ����
    public float maxScale = 2.0f; // �ִ� ũ�� ����

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
        if (Input.GetMouseButton(0)) // ���콺 ��Ŭ�� ������ ���� ȸ��
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

            // ��Ȯ�� �ּ�/�ִ� ���� ����
            float clampedScale = Mathf.Clamp(newScale.x, initialScale.x * (minScale / 2), initialScale.x * (maxScale / 2));
            transform.localScale = new Vector3(clampedScale, clampedScale, clampedScale);
        }
    }

}
