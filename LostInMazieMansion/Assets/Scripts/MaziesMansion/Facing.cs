using UnityEngine;

namespace MaziesMansion
{
    public enum Facing: byte
    {
        UP = 0,
        DOWN = 1,
        LEFT = 2,
        RIGHT = 3,
    }

    internal static class FacingUtility
    {
        private static readonly Quaternion[] DIRECTION_QUATERNIONS = {
            /* UP    */ Quaternion.Euler(0, 0, 0),
            /* DOWN  */ Quaternion.Euler(0, 0, 180),
            /* LEFT  */ Quaternion.Euler(0, 0, -90),
            /* RIGHT */ Quaternion.Euler(0, 0, 90),
        };

        internal static Quaternion AsDirectionQuaternion(this Facing facing)
            => DIRECTION_QUATERNIONS[(byte)facing];

        internal static Facing FromMotionVector(Vector2 motion)
        {
            var angle = Vector2.SignedAngle(Vector2.up, motion);
            if(angle < -135f || angle > 135f)
                return Facing.DOWN;
            if(angle < -45f)
                return Facing.LEFT;
            if(angle > 45f)
                return Facing.RIGHT;
            return Facing.UP;
        }
    }
}
