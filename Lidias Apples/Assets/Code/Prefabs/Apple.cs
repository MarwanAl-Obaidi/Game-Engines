using UnityEngine;

public class Apple : MonoBehaviour
{
    [SerializeField]
    private Transform m_appleJoint;
    public bool m_follow = false;
    private Rigidbody m_rb = null;

    private void Start()
    {
        m_rb = GetComponent<Rigidbody>();
        m_rb.isKinematic = true;
    }

    private void Update()
    {
        if (m_follow)
        {
            this.transform.position = m_appleJoint.transform.position;
        }
    }

    public void AttachApple()
    {
        m_follow = true;
        m_rb.isKinematic = true;
    }

    public void DetachApple(float f)
    {
        m_follow = false;
        m_rb.isKinematic = false;
        m_rb.AddForce(Vector3.left * f, ForceMode.Impulse);
    }

    public void HideApple()
    {
        this.gameObject.SetActive(false);
        m_rb.isKinematic = true;
    }

    public void ShowApple()
    {
        this.gameObject.SetActive(true);
        m_rb.isKinematic = true;
    }
}
