using UnityEngine;

public class RoomCell : MonoBehaviour
{
    public int row;
    public int col;
    public bool hasGuardian = false;
    public bool isRoomActive = false;
    private Collider2D roomCollider;
    private Collider2D[] scanBuffer;

    private int maskLayer2and3;

    private void Awake()
    {
        roomCollider = GetComponent<Collider2D>();
        maskLayer2and3 = (1 << 2) | (1 << 3);
        scanBuffer = new Collider2D[15];
        isRoomActive=this.gameObject.activeSelf;
    }

    private void FixedUpdate()
    {
        hasGuardian = false;
        ContactFilter2D filter = new ContactFilter2D();
        filter.layerMask = maskLayer2and3;
        filter.useTriggers = true;
        int count = Physics2D.OverlapCollider(roomCollider, filter, scanBuffer);
        for (int i = 0; i < count; i++)
        {
            if (scanBuffer[i].CompareTag("Ally")|| scanBuffer[i].CompareTag("MainCharacter"))
            {
                hasGuardian = true;
                break;
            }
        }
    }
}