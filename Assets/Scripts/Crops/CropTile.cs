using Crops.CropState;
using UnityEngine;

namespace Crops
{
    public class CropTile : Interactable
    {
        private CropState.CropState State { get; set; }

        // Constructor
        public CropTile()
        {
            State = new UnplowedState();
        }

        public override void Interact()
        {
            State = State.NextState();
        }
    }
}