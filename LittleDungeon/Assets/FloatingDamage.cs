using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FloatingDamage : MonoBehaviour
{
    public Animator animator;
    public TextMeshProUGUI damageText;

    // Start is called before the first frame update
    void Start()
    {
        AnimatorClipInfo[] clipInfo = animator.GetCurrentAnimatorClipInfo(0);
        Destroy(gameObject, clipInfo[0].clip.length);
        //damageText = animator.GetComponent<TextMeshProUGUI>();
    }

    public void SetText(string text)
    {
        damageText.text = text;
    }
}
