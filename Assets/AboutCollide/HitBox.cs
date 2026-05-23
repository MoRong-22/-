using UnityEngine;

namespace AboutCollide
{
    public class HitBox
    {
        public HitBox(Vector3 pos, float xLength, float yLength, float zLength)
        {
            this.Position = pos;
            this.XLength = xLength;
            this.YLength = yLength;
            this.ZLength = zLength;
        }

        public HitBox(float x, float y, float z, float xLength, float yLength, float zLength)
        {
            this.Position =  new Vector3(x, y, z);
            this.XLength = xLength;
            this.YLength = yLength;
            this.ZLength = zLength;
        }
        public Vector3 Position;
        public float XLength;
        public float YLength;
        public float ZLength;
    }
}