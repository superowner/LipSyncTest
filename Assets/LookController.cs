using UnityEngine;
using System.Collections;

public class LookController : MonoBehaviour
{
    /// <summary>
    /// 目線を向けるターゲット
    /// </summary>
    public Transform target;
    /// <summary>
    /// 目線を向けているか否か
    /// </summary>
    bool isLooking;
    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (isLooking)
        {
            if (target == null)
            {
                Debug.Log("targe is null.");
            }
            else
            {
                // 目線向ける際の関節のひねり影響を設定
                anim.SetLookAtWeight(
                    weight: 1.0f, // 全体的な関節への影響
                    bodyWeight: 0.3f,
                    headWeight: 0.8f,
                    eyesWeight: 1.0f,
                    clampWeight: 0.5f // 目線無理しない度。0だと頭の真後ろだろうと向く。怖い
                );
                // ターゲットの方を向く
                anim.SetLookAtPosition(target.position);
            }
        }
    }

    void OnGUI()
    {
        if (GUI.Button(new Rect(100, 100, 100, 20), "looking : " + isLooking.ToString()))
        {
            isLooking = !isLooking;
        }
    }
}