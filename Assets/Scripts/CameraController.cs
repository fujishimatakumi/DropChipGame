using System;
using System.Collections;
using UnityEngine;
using System.Linq;

public class CameraController : MonoBehaviour
{
    /// <summary> チップの出現位置 </summary>
    [SerializeField] Transform m_chipSpawnPoint = null;

    public delegate void CametaMoveFinCallBack();

    public void CameraMove(float wateTime, CametaMoveFinCallBack cametaMoveFinCallBack)
    {
        StartCoroutine(SpawnPointMove(wateTime, cametaMoveFinCallBack));
    }
    /// <summary> 一番高い位置にいるChipControllerを返します </summary>
    ChipController TopChip()
    {
        ChipController[] chips = GameObject.FindObjectsOfType<ChipController>();
        if (chips.Length <= 0) return null;

        ChipController topChip = chips.OrderByDescending(chip => chip.transform.position.y).First();
        Debug.Log(topChip.transform.position);
        return topChip;
    }

    IEnumerator SpawnPointMove(float waitTime, CametaMoveFinCallBack cametaMoveFinCallBack)
    {
        yield return new WaitForSeconds(waitTime);

        Vector3 pos = m_chipSpawnPoint.position;
        var topChip = TopChip();
        if (topChip != null)
        {
            var topY = topChip.transform.position.y + 2f;
            Debug.Log($"topY = {topY} pos = {pos}");
            if (pos.y - 1f < topY)
            {
                pos.y = topY;
            }
            m_chipSpawnPoint.position = pos;
        }
        cametaMoveFinCallBack?.Invoke();
    }
}
