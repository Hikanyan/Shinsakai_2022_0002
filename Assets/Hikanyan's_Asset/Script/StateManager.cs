using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager
{

    void Dead()
    {
        
    }
    enum BuffState{
        Poisoned,//毒
        Blind,//盲目
        Asleep,//睡眠
        Confused,//混乱
        Stunned,//気絶
        Paralyzed,//麻痺
        Charmed,//魅了
        Diseased,//病気
        Silenced,//沈黙
        Bleeding,//出血
        Stoned,//石化
        Drunk,//酔い
        Frozen,//凍結
        Burning,//炎上
        Entangled,//からみ
        Greased,//足元がぬるぬる
        Bound,//拘束
        Mad,//狂乱
        Berserk,//狂化
        Angered,//怒り
        Enraged,//激怒
        Taunted,//挑発
        Slowed,//鈍化
        Frightened,//恐怖
        HorsDeCombat,//戦闘不能
        Dead,//死亡
        Vulnerable,//耐性低下
        Nauseated,//吐き気
        Feeble,//弱体化
        Cursed,//呪い
        Doomed,//破滅
        Lucky,//運が良い
        Unlucky,//運が悪い
        Disarmed,//武器を奪われた
        Dominated,//支配
        Deaf,//音が聞こえない
        Burdened,//重荷
        Hungry,//空腹
        Thirsty,//のどの渇き
        Starving//飢えている
    }
}
