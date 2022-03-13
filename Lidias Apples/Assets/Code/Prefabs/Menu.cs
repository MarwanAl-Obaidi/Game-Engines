using UnityEngine;

public class Menu : MonoBehaviour
{
    public GameObject[] m_items = null;
    public int m_selection = 0;
    private MenuOption[] m_options = null;

    private void Start()
    {
        m_options = new MenuOption[m_items.Length];
        for (int i=0; i < m_items.Length; ++i)
        {
            GameObject go = m_items[i];
            MenuOption mo = go.GetComponent<MenuOption>();
            m_options[i] = mo;
        }
        UpdateMenu();
    }

    private void Update()
    {
        UpdateMenu();
    }

    private void UpdateMenu()
    {
        for (int i=0; i < m_options.Length; ++i)
        {
            m_options[i].OptionDeselected();
        }
        m_options[m_selection].OptionSelected();
    }

    public void AcceptSelection()
    {
        m_options[m_selection].m_event.Invoke();
    }

    public void NextSelection()
    {
        m_selection++;
        m_selection = (int)Mathf.Repeat(m_selection, m_items.Length);
    }

    public void PreviousSelection()
    {
        m_selection--;
        m_selection = (int)Mathf.Repeat(m_selection, m_items.Length);
    }

    public void OnQuit()
    {
        Game.m_gameStateMachine.SetTrigger("Quit");
    }

    public void OnNewGame()
    {
        Game.m_gameStateMachine.SetTrigger("NewGame");
    }
}
