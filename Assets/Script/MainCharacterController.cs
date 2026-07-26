using System.Linq;
using UnityEngine;

public class MainCharacterController : MonoBehaviour
{
        [Header("基础属性配置（编辑器面板填写）")]
        public int baseHp;
        public int baseAtk;
        public int baseDef;

        //逻辑实体
        private AllyEntity allyEntity;

        void Awake()
        {
            //实例化逻辑角色
            allyEntity = new AllyEntity();
            allyEntity.baseMaxHealth = baseHp;
            allyEntity.baseAttack = baseAtk;
            allyEntity.baseDefense = baseDef;
            allyEntity.InitCharacter();
        }
        /// <summary>
        /// 外部攻击调用，转发给逻辑层计算伤害
        /// </summary>
        public void ReceiveAttack(int rawDamage)
        {
            allyEntity.TakeDamage(rawDamage);
        }

        /// <summary>
        /// 获取逻辑实体，供外部访问
        /// </summary>
        public AllyEntity GetEntity()
        {
            return allyEntity;
        }
    public void SkillAttack1HitCheck()
    {
        int rawDamage = allyEntity.Attack;
        GameObject[] allEneries = GameObject.FindGameObjectsWithTag("Enery");
        if (allEneries.Length == 0)
            return;
        GameObject closestEnemy = allEneries[0];
        float minDistance = Vector2.Distance(transform.position, closestEnemy.transform.position);
        foreach (GameObject enemy in allEneries)
        {
            float distance = Vector2.Distance(transform.position, enemy.transform.position);
            if (distance < minDistance)
            {
                minDistance = distance;
                closestEnemy = enemy;
            }
        }
        MonsterControl monster = closestEnemy.GetComponent<MonsterControl>();
        if (monster != null)
        {
            monster.ReceiveAttack(rawDamage);
        }
    }
    public void EndAnimationSkillAttack1()
    {
        GetComponent<Animator>().SetBool("SkillAttack1", false);
    }
}
