using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class MenuOption : MonoBehaviour
{
    public string m_optionText = "";
    public UnityEvent m_event = null;
    private Text m_textComponent = null;
    private GameObject m_indicator = null;

    private void Start()
    {
        m_indicator = transform.GetChild(0).gameObject;
        m_textComponent = GetComponent<Text>();
        m_textComponent.text = m_optionText;
    }

    public void OptionSelected()
    {
        m_indicator.SetActive(true);
    }

    public void OptionDeselected()
    {
        m_indicator.SetActive(false);
    }
}
