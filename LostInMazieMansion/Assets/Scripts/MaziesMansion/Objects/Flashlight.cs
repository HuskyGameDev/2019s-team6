using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

namespace MaziesMansion.Objects
{
    [RequireComponent(typeof(Light2D))]
    public sealed class Flashlight: MonoBehaviour
    {
        private new Light2D light;
        public float LightOffIntensity = 0;
        public float LightOnIntensity = 0.6f;

        private void Start()
        {
            light = GetComponent<Light2D>();
            IsOn = PersistentData.Instance.FlashlightActive;
            Direction = PersistentData.Instance.FlashlightFacing;
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
            get => PersistentData.Instance.FlashlightFacing;
            set
            {
                PersistentData.Instance.FlashlightFacing = value;
                transform.rotation = value.AsDirectionQuaternion();
            }
        }
    }
}
