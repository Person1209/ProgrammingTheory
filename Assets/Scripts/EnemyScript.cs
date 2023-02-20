using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Base Enemy script
public class EnemyScript : MonoBehaviour
{
    protected Rigidbody m_body;

    protected void Init()
    {
        m_body = GetComponent<Rigidbody>();
    }
    private void Start()
    {
        Init();
    }

    protected Vector3 VectorToPlayer()
    {
        return PlayerScript.Instance.transform.position - transform.position;
    }
    protected void PushTowardsPlayer(float speed)
    {
        m_body.AddForce(speed * Time.deltaTime * VectorToPlayer().normalized);
    }
}