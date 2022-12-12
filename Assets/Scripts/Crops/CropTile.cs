using Crops.CropState;

namespace Crops
{
    public class CropTile
    {
        private CropState.CropState State { get; set; }

        public CropTile()
        {
            State = new UnplowedState();
        }

        public void NextState()
        {
            State = State.NextState();
        }
    }
}