using UnityEngine;
using UnityEngine.Experimental.Rendering.LWRP;

namespace MaziesMansion.Objects
{
    [RequireComponent(typeof(UnityEngine.Experimental.Rendering.Universal.Light2D))]
    public sealed class Flashlight: MonoBehaviour
    {
        private new UnityEngine.Experimental.Rendering.Universal.Light2D light;
        private Facing direction;

        public float LightOffIntensity = 0;
        public float LightOnIntensity = 0.6f;

        private void Start()
        {
            light = GetComponent<UnityEngine.Experimental.Rendering.Universal.Light2D>();
            IsOn = PersistentData.Instance.FlashlightActive;
        }

        public bool IsOn
        {
            get => PersistentData.Instance.FlashlightActive;
            set
            {
                PersistentData.Instance.FlashlightActive = value;
                light.intensity = value ? LightOnIntensity : LightOffIntensity;
            }
        }

        public Facing Direction
        {
            get => direction;
            set
            {
                direction = value;
                transform.rotation = direction.AsDirectionQuaternion();
            }
        }
    }
}
