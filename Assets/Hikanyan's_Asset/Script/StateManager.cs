using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager
{

    void Dead()
    {
        
    }
    enum BuffState{
        Poisoned,//��
        Blind,//�Ӗ�
        Asleep,//����
        Confused,//����
        Stunned,//�C��
        Paralyzed,//���
        Charmed,//����
        Diseased,//�a�C
        Silenced,//����
        Bleeding,//�o��
        Stoned,//�Ή�
        Drunk,//����
        Frozen,//����
        Burning,//����
        Entangled,//�����
        Greased,//�������ʂ�ʂ�
        Bound,//�S��
        Mad,//����
        Berserk,//����
        Angered,//�{��
        Enraged,//���{
        Taunted,//����
        Slowed,//�݉�
        Frightened,//���|
        HorsDeCombat,//�퓬�s�\
        Dead,//���S
        Vulnerable,//�ϐ��ቺ
        Nauseated,//�f���C
        Feeble,//��̉�
        Cursed,//��
        Doomed,//�j��
        Lucky,//�^���ǂ�
        Unlucky,//�^������
        Disarmed,//�����D��ꂽ
        Dominated,//�x�z
        Deaf,//�����������Ȃ�
        Burdened,//�d��
        Hungry,//��
        Thirsty,//�̂ǂ̊���
        Starving//�Q���Ă���
    }
}
