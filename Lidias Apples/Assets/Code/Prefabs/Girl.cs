using UnityEngine;

public class Girl : Character
{
    [SerializeField]
    private PhysicalDriver m_driver = null;
    [SerializeField]
    private float m_force = 10f;
    [SerializeField]
    private float m_maxVelocity = 2f;
    private bool m_catchMode = false;
    public AudioClip[] m_steps = null;
    [SerializeField]
    private AudioSource m_stepAudioSource = null;

    public override void InitCharacter()
    {
        Game.OnLeft += Game_OnLeft;
        Game.OnRight += Game_OnRight;
        m_catchMode = true;
    }

    public void ClearCharacter()
    {
        Game.OnLeft -= Game_OnLeft;
        Game.OnRight -= Game_OnRight;
        m_catchMode = false;
    }

    public void SetCatchMode(bool value)
    {
        m_catchMode = value;
    }

    private void LateUpdate()
    {
        if (m_catchMode)
        {
            m_animator.SetFloat("Velocity", m_driver.m_rb.velocity.magnitude);
        }
    }

    private void Update()
    {
        transform.position = m_driver.m_groundPoint;
    }

    private void Game_OnRight()
    {
        AddForce(Vector3.left * m_force);
    }

    private void Game_OnLeft()
    {
        AddForce(Vector3.right * m_force);
    }

    private void AddForce(Vector3 f)
    {
        if (m_driver.m_rb.velocity.magnitude < m_maxVelocity)
        {
            m_driver.m_rb.AddForce(f);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (m_catchMode)
        {
            if (collision.gameObject.layer == LayerMask.NameToLayer("Apple"))
            {
                Game.m_boy.HideApple();
                Game.AddCatchedApple();
                Game.CheckGameWinLoose();
            }
        }
    }

    private void RFootDown()
    {
        int ind = Mathf.FloorToInt(Random.Range(0, m_steps.Length - 1));
        m_stepAudioSource.clip = m_steps[ind];
        m_stepAudioSource.Play();
    }

    private void LFootDown()
    {
        int ind = Mathf.FloorToInt(Random.Range(0, m_steps.Length - 1));
        m_stepAudioSource.clip = m_steps[ind];
        m_stepAudioSource.Play();
    }
}
