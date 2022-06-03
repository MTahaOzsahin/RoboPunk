using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kajujam.Concrates.Inputs
{
    public class CinemachineMouse1Input : MonoBehaviour
    {
        private void Start()
        {
            CinemachineCore.GetInputAxis = GetAxisCustom;
        }
        public float GetAxisCustom(string axisName)
        {
            if (axisName == "Mouse X")
            {
                if (Input.GetMouseButton(1))
                {
                    return UnityEngine.Input.GetAxis("Mouse X");
                }
                else
                {
                    return UnityEngine.Input.GetAxis(axisName);
                }
            }
            else if (axisName == "Mouse Y")
            {
                if (Input.GetMouseButton(1))
                {
                    return UnityEngine.Input.GetAxis("Mouse Y");
                }
                else
                {
                    return UnityEngine.Input.GetAxis(axisName);
                }
            }
            return UnityEngine.Input.GetAxis(axisName);
        } 
    }
}
