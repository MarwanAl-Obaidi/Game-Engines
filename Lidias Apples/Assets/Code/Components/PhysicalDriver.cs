using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicalDriver : MonoBehaviour
{
    [HideInInspector]
    public Rigidbody m_rb = null;
    public Collider m_collider = null;
    public Vector3 m_groundPoint = Vector3.zero;

    private void Start()
    {
        m_rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        RaycastHit hit;
        Ray r = new Ray(this.transform.position, Vector3.down);
        if (m_collider.Raycast(r, out hit, float.MaxValue))
        {
            m_groundPoint = hit.point;
        }
    }
}
