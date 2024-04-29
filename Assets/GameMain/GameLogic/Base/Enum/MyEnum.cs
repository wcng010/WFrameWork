using System;

namespace Wcng
{
    public enum CardType
    {
        Null = -1,
        Deal, //抽牌
        Keephand, //留一手
        TortoiseShell, //龟甲
        SpeedUp, //动如脱兔
        MeleeAttack, //近战攻击
        DrawBow, //拉弓
        TurnAround, //转身
        Defence, //防御
        Move,//移动
        ChangeFloor,//改变层级
        Dodge//闪避
    }

    public enum CombatEventType
    {
        CombatBegin,
        TurnBasedRoundPreBegin,
        TurnBasedRoundBegin,
        TurnBasedRoundChange,
        TurnBasedRoundEnd,
        CombatEnd,
    }


    public enum NetWorkEventType
    {
        UpdateView,
        RoundPass,
    }

    public enum StateType
    {   //非战斗站立状态
        CommonIdleState,
        //战斗站立状态
        CombatIdleState,
        //指令移动状态
        MoveState,
        //行走状态
        WalkState,
        //跳跃状态
        JumpState,
        //下落状态
        FallState,
        //奔跑状态
        RunState,
        //拔刀
        DrawKnifeState,
        //收刀
        RetractKnifeState,
        //近战攻击
        MeleeAttackState,
        //拉弓
        DrawBowState,
        //射箭
        FlyArrowState,
        //受伤
        HurtState,
        //防御
        DefenceState,
        //反击
        CounterAttackState,
        //死亡
        DeathState,
        //恢复
        Recover,
        //改变层级
        ChangeFloor,
        //
        MoveUp,
        MoveDown,
        DodgeState,
        ThrowObjectState,
    }
}