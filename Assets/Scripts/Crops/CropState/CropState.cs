using UnityEngine;

namespace Crops.CropState
{
    public abstract class CropState
    {
        public abstract CropState NextState();
    }
    
    public class UnplowedState : CropState
    {
        public override CropState NextState()
        {
            return new PlowedState();
        }
    }
    
    public class PlowedState : CropState
    {
        public override CropState NextState()
        {
            return new SeededState();
        }
    }

    public class SeededState : CropState
    {
        public override CropState NextState()
        {
            return new GrowingState();
        }
    }

    public class GrowingState : CropState
    {
        public override CropState NextState()
        {
            return new GrownState();
        }
    }

    public class GrownState : CropState
    {
        public override CropState NextState()
        {
            // Do something when the crop is fully grown
            return new UnplowedState();
        }
    }
}