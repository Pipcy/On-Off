using UnityEngine;

public class SpinObject : MonoBehaviour
{
    public float rotationSpeed = 10f;
    public SnowGlobe SnowBlobeScript;

    private void Update()
    {
        if (SnowBlobeScript.On)
        {
            Spin();
        }
        else
        {
            Stop();
        }
    }
    public void Spin()
    {
        // Rotate the object around its Y-axis
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }

    public void Stop()
    {
        // Rotate the object around its Y-axis
        transform.Rotate(Vector3.up, 0 * Time.deltaTime);
    }
}