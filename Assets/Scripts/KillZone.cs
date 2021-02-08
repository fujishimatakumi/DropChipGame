using UnityEngine;
using UnityEngine.UI;
// Photon 用の名前空間を参照する
using Photon.Pun;
using Photon.Pun.UtilityScripts;
using Photon.Realtime;

public class KillZone : MonoBehaviour
{
    [SerializeField] DropChipTurnManager m_dropChipTurnManager;
    [SerializeField] Text m_judgeText;
    [SerializeField] Button m_titleButton;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        JudgeText();
        m_titleButton.gameObject.SetActive(true);
        Destroy(collision.gameObject);
    }

    private void JudgeText()
    {
        // 現在プレイしている人の「前の人」のせいでくずれた、と判定する（ActorNumber が 1 から始まることに注意）
        int lostPlayerIndex = ((m_dropChipTurnManager.ActivePlayerIndex + PhotonNetwork.PlayerList.Length - 1) % PhotonNetwork.PlayerList.Length) + 1;

        int myIndex = PhotonNetwork.LocalPlayer.ActorNumber;
        string resultMessage = "";
        resultMessage = $"loser: {lostPlayerIndex}, self: {myIndex}";
        Debug.Log(resultMessage);
        
        if (lostPlayerIndex == myIndex)
        {
            resultMessage = "You lose";
        }
        else
        {
            resultMessage = "You win";
        }

        m_judgeText.text = resultMessage;
        m_judgeText.gameObject.SetActive(true);
    }
}
