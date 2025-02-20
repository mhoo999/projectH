using UnityEngine;
using UnityEngine.UI;

public class ResetObject : MonoBehaviour
{
    public Transform targetObject; // 초기화할 오브젝트
    public Button resetButton; // 리셋 버튼

    private Vector3 initialPosition;
    private Quaternion initialRotation;
    private Vector3 initialScale;

    void Start()
    {
        // 초기 상태 저장
        if (targetObject != null)
        {
            initialPosition = targetObject.position;
            initialRotation = targetObject.rotation;
            initialScale = targetObject.localScale;
        }

        // 버튼 클릭 시 ResetObject 함수 실행
        if (resetButton != null)
        {
            resetButton.onClick.AddListener(ResetTarget);
        }
    }

    void ResetTarget()
    {
        if (targetObject != null)
        {
            // 위치, 회전, 크기 초기화
            targetObject.position = initialPosition;
            targetObject.rotation = initialRotation;
            targetObject.localScale = initialScale;
        }
    }
}
