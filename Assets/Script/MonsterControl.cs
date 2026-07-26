using System.Buffers.Text;
using UnityEngine;

/// <summary>
/// 怪物总控制器
/// 负责寻找依赖、创建AI、转发Unity消息
/// </summary>
public class MonsterControl : MonoBehaviour
{
    [Header("游荡AI参数")]
    public float stopWaitDuration = 1f;
    public float moveSpeed = 2.5f;
    [Header("怪物战斗基础属性")]
    public int baseHp;
    public int baseAttack;
    public int baseDef;
    private IMonsterAI monsterAI;
    private RoomManager roomManager;
    private MonsterEntity monsterEntity;

    void Awake()
    {
        //查找全局房间管理器
        roomManager = FindAnyObjectByType<RoomManager>();
        //创建游荡AI，把roomManager传入构造函数
        monsterAI = new MonsterWanderAI(roomManager);
        monsterAI.SetTransform(transform);
        //面板参数同步给AI
        if (monsterAI is MonsterWanderAI wanderAi)
        {
            wanderAi.stopWaitDuration = stopWaitDuration;
            wanderAi.moveSpeed = moveSpeed;
        }
        monsterAI.SpawnInit();
        monsterEntity = new MonsterEntity();
        monsterEntity.baseMaxHealth = baseHp;
        monsterEntity.baseAttack = baseAttack;
        monsterEntity.baseDefense = baseDef;
        monsterEntity.InitCharacter();
        monsterEntity.MonsterDeadEvent += OnMonsterDead;
    }

    void Update()
    {
        monsterAI?.UpdateAI(Time.deltaTime);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Room"))
        {
            RoomCell hitRoom = other.GetComponent<RoomCell>();
            monsterAI?.OnRoomTriggerStay(hitRoom);
        }
    }
    /// <summary>
    /// 【外部调用】怪物受到攻击
    /// </summary>
    /// <param name="rawDamage">原始伤害</param>
    public void ReceiveAttack(int rawDamage)
    {
        monsterEntity.TakeDamage(rawDamage);
    }

    /// <summary>
    /// 获取怪物逻辑实体（可选，方便外部读取属性）
    /// </summary>
    public MonsterEntity GetMonsterEntity()
    {
        return monsterEntity;
    }
    /// <summary>
    /// 怪物死亡回调：停止AI，原地静止
    /// </summary>
    private void OnMonsterDead()
    {
        Debug.Log("怪物停止行动，原地不动");
        // 清空AI，不再执行Update逻辑，怪物彻底停下
        monsterAI = null;

        //可选：关闭刚体移动、关闭碰撞等
        //GetComponent<Rigidbody2D>().simulated = false;
    }
    /// <summary>
    /// 怪物复活/刷新，重置AI状态
    /// </summary>
    public void ResetMonsterAI()
    {
        monsterAI?.SpawnInit();
        monsterEntity?.InitCharacter();
    }
}

