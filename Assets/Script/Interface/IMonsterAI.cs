using UnityEngine;

    /// <summary>
    /// 怪物寻路逻辑
    /// </summary>
    public interface IMonsterAI
    {
        void UpdateAI(float deltaTime);
        void OnRoomTriggerStay(RoomCell hitRoom);
        void SpawnInit();
        void SetTransform(Transform monsterTrans);
    }
