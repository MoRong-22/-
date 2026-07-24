using UnityEngine;

public class MonsterWanderLogic : MonoBehaviour
{
    [Tooltip("踩到有守卫房间后的等待时长")]
    public float stopWaitDuration = 1f;
    [Tooltip("房间之间移动速度")]
    public float moveSpeed = 2.5f;
    private RoomManager roomManager;
    public RoomCell currentRoom;
    private float waitTimer;
    private bool isWaiting;
    private Vector3 targetPos;
    private bool isMoving;
    public RoomCell lastRoom;
    private readonly Vector2Int[] moveDirs =
    {
        new Vector2Int(-1, 0),
        new Vector2Int(1, 0),
        new Vector2Int(0, -1)
    };

    void Awake()
    {
        roomManager = FindAnyObjectByType<RoomManager>();
        SpawnInit();
    }

    void Update()
    {
       
        if (!currentRoom)
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x - 10, transform.position.y, transform.position.z), moveSpeed * Time.deltaTime);
        if (isMoving)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
      
            if (Vector3.Distance(transform.position,targetPos) < 0.02f)
            {
                isMoving = false;
            }
        }
     
        if (isWaiting)
        {
            waitTimer += Time.deltaTime;
            if (waitTimer >= stopWaitDuration)
            {
                isWaiting = false;
                waitTimer = 0;
               
                TryPickNextRoom();
            }
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Room"))
        {
            RoomCell hitRoom = other.GetComponent<RoomCell>();
            if (hitRoom != currentRoom)
            {
                lastRoom = currentRoom;
                currentRoom = hitRoom;
            }
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

    void TryPickNextRoom()
    {
        if (isWaiting || isMoving)
            return;
        int tryTimes = 0;
        const int maxTry = 20;
        RoomCell targetRoom = null;
        if (currentRoom.col == 1)
        {
            if(currentRoom.row<2)
            {
                roomManager.TryGetRoom(currentRoom.row+1, currentRoom.col, out RoomCell candidate);
                targetRoom= candidate;
            }
            else if (currentRoom.row > 2)
            {
                roomManager.TryGetRoom(currentRoom.row - 1, currentRoom.col, out RoomCell candidate);
                targetRoom = candidate;
            }
        }

        while (targetRoom==null&&tryTimes < maxTry)
        {
            Vector2Int randomDir = moveDirs[Random.Range(0, moveDirs.Length)];
            int nextRow = currentRoom.row + randomDir.x;
            int nextCol = currentRoom.col + randomDir.y;
            if (roomManager.TryGetRoom(nextRow, nextCol, out RoomCell candidate) && candidate.isRoomActive && candidate != lastRoom)
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

    void SetMoveTarget(Vector3 pos)
    {
        targetPos = pos;
        isMoving = true;
    }

    public void SpawnInit()
    {
        currentRoom = null;
        targetPos = transform.position;
        isMoving = false;
        isWaiting = false;
        waitTimer = 0;
        lastRoom = null;
    }
}