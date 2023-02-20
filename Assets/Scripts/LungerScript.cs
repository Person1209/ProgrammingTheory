using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LungerScript : EnemyScript
{
    [SerializeField]
    private float maxTime = 8.0f;
    [SerializeField]
    private float lungeForce = 3000.0f;
    [SerializeField]
    private float pushForce = 0.8f;

    private float m_timer;
    private bool m_lunged = false;

    private void Start()
    {
        Init();
        m_timer = Random.value * maxTime;
    }

    private void Update()
    {
        if (m_lunged)
            return;

        m_timer -= Time.deltaTime;

        if (m_timer <= 0.0f)
        {
            m_body.AddForce(VectorToPlayer().normalized * lungeForce, ForceMode.Impulse);
            m_lunged = true;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (!m_lunged)
            return;

        if (collision.rigidbody)
        {
            collision.rigidbody.AddForce(m_body.velocity * pushForce, ForceMode.Impulse);
            m_body.velocity *= -pushForce;
        }
    }
}
