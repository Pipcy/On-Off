using UnityEngine;

public class TaskPanel1 : MonoBehaviour
{
    public float stayDuration = 10f;
    public float slideSpeed = 5f;

    private bool isMenuVisible = true;
    private float initialPosition;
    private float targetPosition;

    private void Start()
    {
        initialPosition = transform.position.y;
        targetPosition = initialPosition + GetComponent<RectTransform>().rect.height;
        Invoke("SlideUpAndOut", stayDuration);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ToggleMenuVisibility();
        }
    }

    private void SlideUpAndOut()
    {
        targetPosition = initialPosition + GetComponent<RectTransform>().rect.height;
    }

    private void ToggleMenuVisibility()
    {
        isMenuVisible = !isMenuVisible;
        targetPosition = isMenuVisible ? initialPosition : initialPosition + GetComponent<RectTransform>().rect.height;
    }

    private void FixedUpdate()
    {
        Vector3 currentPosition = transform.position;
        Vector3 targetPositionVector = new Vector3(currentPosition.x, targetPosition, currentPosition.z);
        transform.position = Vector3.Lerp(currentPosition, targetPositionVector, slideSpeed * Time.deltaTime);
    }
}
