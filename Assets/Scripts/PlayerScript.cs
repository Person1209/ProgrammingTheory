using UnityEngine;

//Script for controlling player and camera
public class PlayerScript : MonoBehaviour
{
    [SerializeField]
    private float rotationSpeed = 0.5f;
    [SerializeField]
    private float movementSpeed = 0.5f;
    [SerializeField]
    private float cameraDistance = 6.0f;

    private Camera m_cam;
    private Rigidbody m_body;
    private float m_rotation = 0.0f;

    public static PlayerScript Instance
    {
        get;
        private set;
    }

    private void Start()
    {
        m_cam = Camera.main;
        m_body = GetComponent<Rigidbody>();

        if (Instance != null)
            Destroy(gameObject);
        else
            Instance = this;
    }

    private void Update()
    {
        float vInput = Input.GetAxis("Vertical");

        m_body.AddForce(
            Mathf.Cos(m_rotation) * movementSpeed * vInput * Time.deltaTime,
            0.0f,
            Mathf.Sin(m_rotation) * movementSpeed * vInput * Time.deltaTime,
            ForceMode.Impulse
        );
    }
    private void LateUpdate()
    {
        float hInput = -Input.GetAxis("Horizontal");

        m_rotation += hInput * rotationSpeed * Time.deltaTime;
        m_cam.transform.position = transform.position + new Vector3(
            -Mathf.Cos(m_rotation) * cameraDistance,
            Mathf.Sin(0.25f) * cameraDistance,
            -Mathf.Sin(m_rotation) * cameraDistance
        );
        m_cam.transform.LookAt(transform);
    }
}