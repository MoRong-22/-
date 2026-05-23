using System.Numerics;

namespace Content.IHelper
{
    public interface IMovable
    {
        Vector3 Center { get; set; }
        Quaternion Rotation { get; set; }
        Vector3 Velocity { get; set; }
    }
}
