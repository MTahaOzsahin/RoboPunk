using Kajujam.Abstracts.Inputs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kajujam.Concrates.Inputs
{
    public class PCInputs : IPlayerInputs
    {
        public float Horizontal => Input.GetAxis("Horizontal");
        public float Vertical => Input.GetAxis("Vertical");
    }
}
