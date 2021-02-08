using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Pun.UtilityScripts;
using Photon.Realtime;

public class ItemController : MonoBehaviour
{
    [SerializeField] GameObject m_nowChip;
    public GameObject NowChip { get { return m_nowChip; } set { m_nowChip = value; } }

    private bool m_used = false;

    [SerializeField] GameObject m_redraw;
    Button bu;

    DropChipTurnManager dropChipTurnManager;

    void Start()
    {
        dropChipTurnManager = GameObject.Find("Manager").GetComponent<DropChipTurnManager>();
        bu = GetComponent<Button>();
    }

    void Update()
    {
        if (dropChipTurnManager.ActivePlayer.Equals(PhotonNetwork.LocalPlayer))
        {
            bu.interactable = true;
        }
        else
        {
            bu.interactable = false;
        }
    }

    public void PushReDraw()
    {
        if (dropChipTurnManager.ActivePlayer.Equals(PhotonNetwork.LocalPlayer) && !m_used)
        {
            PhotonNetwork.Destroy(m_nowChip);
            dropChipTurnManager.SpawnChip();
            Destroy(bu.gameObject);
        }
    }
}
