using UnityEngine;
using System.Collections.Generic;

public class RoomManager : MonoBehaviour
{
    // 字典存放场景内【全部房间】，无论解锁与否
    private readonly Dictionary<Vector2Int, RoomCell> roomDict = new Dictionary<Vector2Int, RoomCell>();

    void Awake()
    {
        BuildRoomDictionary();
    }
    public void RefreshRoomList()
    {
        BuildRoomDictionary();
    }

    private void BuildRoomDictionary()
    {
        roomDict.Clear();
        RoomCell[] allRoomObjects = FindObjectsByType<RoomCell>(FindObjectsInactive.Include);
        foreach (RoomCell room in allRoomObjects)
        {
            Vector2Int key = new Vector2Int(room.row, room.col);
            if (!roomDict.ContainsKey(key))
            {
                roomDict.Add(key, room);
            }
        }
    }
    public RoomCell GetRoom(int row, int col)
    {
        Vector2Int key = new Vector2Int(row, col);
        roomDict.TryGetValue(key, out RoomCell targetRoom);
        return targetRoom;
    }
    public bool TryGetRoom(int row, int col, out RoomCell roomCell)
    {
        Vector2Int key = new Vector2Int(row, col);
        return roomDict.TryGetValue(key, out roomCell);
    }

    // 拓展便捷方法：推进剧情解锁房间
    public void UnlockRoom(int row, int col)
    {
        if (TryGetRoom(row, col, out RoomCell room))
        {
            room.isRoomActive = true;
        }
    }
}