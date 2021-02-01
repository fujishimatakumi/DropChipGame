using UnityEngine;
using UnityEngine.UI;
// Photon 用の名前空間を参照する
using Photon.Pun;
using Photon.Pun.UtilityScripts;
using Photon.Realtime;

public class KillZone : MonoBehaviour
{
    [SerializeField] Text m_judgeText;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("接触");
        int number = PhotonNetwork.PlayerList.Length;
        m_judgeText.text = number + "Win"; 
    }
}
