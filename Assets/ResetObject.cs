using UnityEngine;
using UnityEngine.UI;

public class ResetObject : MonoBehaviour
{
    public Transform targetObject; // �ʱ�ȭ�� ������Ʈ
    public Button resetButton; // ���� ��ư

    private Vector3 initialPosition;
    private Quaternion initialRotation;
    private Vector3 initialScale;

    void Start()
    {
        // �ʱ� ���� ����
        if (targetObject != null)
        {
            initialPosition = targetObject.position;
            initialRotation = targetObject.rotation;
            initialScale = targetObject.localScale;
        }

        // ��ư Ŭ�� �� ResetObject �Լ� ����
        if (resetButton != null)
        {
            resetButton.onClick.AddListener(ResetTarget);
        }
    }

    void ResetTarget()
    {
        if (targetObject != null)
        {
            // ��ġ, ȸ��, ũ�� �ʱ�ȭ
            targetObject.position = initialPosition;
            targetObject.rotation = initialRotation;
            targetObject.localScale = initialScale;
        }
    }
}
