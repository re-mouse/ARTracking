using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TransformController : MonoBehaviour
{
    private const float MIN_SIZE = 0.05f;
    private const float MAX_SIZE = 0.5f;
    
    [SerializeField]
    private Slider scaleSlider;

    public void MoveHorizontal(float unit)
    {
        transform.position = new Vector3(transform.position.x + unit, transform.position.y, transform.position.z);
    }

    public void MoveForward(float unit)
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + unit);
    }

    public void RotateObject(float angle)
    {
        Vector3 angles = transform.rotation.eulerAngles;
        transform.rotation = Quaternion.Euler(angles.x, angles.y + angle, angles.z);
    }

    public void ChangeScale()
    {
        float value = scaleSlider.value;
        float scale = MIN_SIZE + (MAX_SIZE - MIN_SIZE) * value;
        transform.localScale = new Vector3(scale, scale, scale);
    }
}
