using Cinemachine;
using Kajujam.Concrates.Controller;
using UnityEngine;

namespace Kajujam.Concrates.ExtensionMethods
{
    public class CinemachinePOVExtension : CinemachineExtension
    {
        [SerializeField]
        float clampAngle = 80f;
        [SerializeField]
        float horizontalSpeed = 10f;
        [SerializeField]
        float vercitalSpeed = 10f;

        private InputManager inputManager;
        private Vector3 startingRotation;

        protected override void Awake()
        {
            inputManager = InputManager.Instance;
            base.Awake();
            startingRotation = transform.localRotation.eulerAngles;
        }
        protected override void PostPipelineStageCallback(CinemachineVirtualCameraBase vcam, CinemachineCore.Stage stage, ref CameraState state, float deltaTime)
        {
            if (vcam.Follow)
            {
                if (stage == CinemachineCore.Stage.Aim)
                {
                    if (startingRotation == null)
                    {
                        Vector2 deltaInput = inputManager.GetMouseDelta();
                        startingRotation.x += deltaInput.x *vercitalSpeed* Time.deltaTime;
                        startingRotation.y += deltaInput.y *horizontalSpeed* Time.deltaTime;
                        startingRotation.y = Mathf.Clamp(startingRotation.y, -clampAngle, clampAngle);
                        state.RawOrientation = Quaternion.Euler(-startingRotation.y,startingRotation.x,0f);
                    }
                }
            }
        }
    }
}
