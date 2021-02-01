using UnityEngine;
using UnityEngine.UI;

public class KillZone : MonoBehaviour
{
    [SerializeField] DropChipTurnManager m_dropChipTurnManager;
    [SerializeField] GameObject m_judgeTextObj;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("接触");
        JudgeText();
    }

    private void JudgeText()
    {
        int m_number = m_dropChipTurnManager.Number;
        Text m_judgeText = m_judgeTextObj.GetComponent<Text>();
        m_judgeTextObj.SetActive(true);
        m_judgeText.text = "Player" + m_number + "Win";
    }
}
