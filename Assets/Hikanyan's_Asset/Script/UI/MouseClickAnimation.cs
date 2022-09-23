using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
public class MouseClickAnimation : MonoBehaviour
{
    Sequence seq;

    [SerializeField] SpriteRenderer image; //�A�j���[�V����������Image���A�^�b�`���Ă���

    [SerializeField] Sprite _mouseClickSpriteLight;
    [SerializeField] Sprite _mouseClickSpriteLeft;

    private void Start()
    {
        //Sequence�̐錾
        seq = DOTween.Sequence();
        seq.Append(DOVirtual.DelayedCall(0.25f, () => image.sprite = _mouseClickSpriteLight));
        seq.Append(DOVirtual.DelayedCall(0.25f, () => image.sprite = _mouseClickSpriteLeft));
        seq.SetLoops(-1, LoopType.Restart);//�������[�v����
    }
}
