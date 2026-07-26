using UnityEngine;
using Content.IHelper;

public class MonsterWanderAI :IMonsterAI
{
    // 配置参数（可以外部赋值）
    public float stopWaitDuration = 1f;
    public float moveSpeed = 2.5f;

    //运行状态
    public RoomCell currentRoom;
    public RoomCell lastRoom;
    private float waitTimer;
    private bool isWaiting;
    private Vector3 targetPos;
    private bool isMoving;

    private Transform monsterTransform;
    private RoomManager roomManager;

    private readonly Vector2Int[] moveDirs =
    {
        new Vector2Int(-1, 0),
        new Vector2Int(1, 0),
        new Vector2Int(0, -1)
    };

    public MonsterWanderAI(RoomManager roomMgr)
    {
        roomManager = roomMgr;
    }

    /// <summary>
    /// 绑定怪物Transform
    /// </summary>
    public void SetTransform(Transform monsterTrans)
    {
        monsterTransform = monsterTrans;
    }

    public void SpawnInit()
    {
        currentRoom = null;
        targetPos = monsterTransform.position;
        isMoving = false;
        isWaiting = false;
        waitTimer = 0;
        lastRoom = null;
    }

    public void UpdateAI(float deltaTime)
    {
        if (monsterTransform == null) 
            return;

        if (!currentRoom)
        {
            monsterTransform.position = Vector3.MoveTowards(
                monsterTransform.position,
                new Vector3(monsterTransform.position.x - 10, monsterTransform.position.y, monsterTransform.position.z),
                moveSpeed * deltaTime);
        }

        if (isMoving)
        {
            monsterTransform.position = Vector3.MoveTowards(
                monsterTransform.position, targetPos, moveSpeed * deltaTime);

            if (Vector3.Distance(monsterTransform.position, targetPos) < 0.02f)
            {
                isMoving = false;
            }
        }

        if (isWaiting)
        {
            waitTimer += deltaTime;
            if (waitTimer >= stopWaitDuration)
            {
                isWaiting = false;
                waitTimer = 0;
                TryPickNextRoom();
            }
        }
    }

    public void OnRoomTriggerStay(RoomCell hitRoom)
    {
        if (hitRoom != null && hitRoom != currentRoom)
        {
            lastRoom = currentRoom;
            currentRoom = hitRoom;
        }
        if (currentRoom.hasGuardian)
        {
            isWaiting = true;
            waitTimer = 0;
            isMoving = false;
        }
        else
        {
            isWaiting = false;
            if (currentRoom.row == 2 && currentRoom.col == 1)
            {
                if (roomManager.TryGetRoom(2, 0, out RoomCell forceTarget) && forceTarget.isRoomActive)
                {
                    SetMoveTarget(forceTarget.transform.position);
                    return;
                }
            }
            TryPickNextRoom();
        }
    }

    private void TryPickNextRoom()
    {
        if (isWaiting || isMoving)
            return;

        int tryTimes = 0;
        const int maxTry = 20;
        RoomCell targetRoom = null;

        if (currentRoom.col == 1)
        {
            if (currentRoom.row < 2)
            {
                roomManager.TryGetRoom(currentRoom.row + 1, currentRoom.col, out RoomCell candidate);
                targetRoom = candidate;
            }
            else if (currentRoom.row > 2)
            {
                roomManager.TryGetRoom(currentRoom.row - 1, currentRoom.col, out RoomCell candidate);
                targetRoom = candidate;
            }
        }

        while (targetRoom == null && tryTimes < maxTry)
        {
            Vector2Int randomDir = moveDirs[Random.Range(0, moveDirs.Length)];
            int nextRow = currentRoom.row + randomDir.x;
            int nextCol = currentRoom.col + randomDir.y;
            if (roomManager.TryGetRoom(nextRow, nextCol, out RoomCell candidate)
                && candidate.isRoomActive
                && candidate != lastRoom)
            {
                targetRoom = candidate;
                break;
            }
            tryTimes++;
        }

        if (targetRoom != null)
        {
            SetMoveTarget(targetRoom.transform.position);
        }
    }

    private void SetMoveTarget(Vector3 pos)
    {
        targetPos = pos;
        isMoving = true;
    }
}