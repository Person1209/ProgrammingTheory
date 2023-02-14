using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField]
    private float distance = 75.0f;
    [SerializeField]
    private float speed = 0.5f;

    private float rotation = Mathf.PI;

    // Update is called once per frame
    void Update()
    {
        float input = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        rotation += input;

        transform.position = new Vector3(
            Mathf.Sin(rotation) * distance,
            distance,
            Mathf.Cos(rotation) * distance
        );
        transform.LookAt(Vector3.zero);
    }
}
