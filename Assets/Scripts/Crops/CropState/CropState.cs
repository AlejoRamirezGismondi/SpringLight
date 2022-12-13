namespace Crops.CropState
{
    public abstract class CropState
    {
        public abstract CropState NextState(CropTile cropTile);
    }
    
    public class UnplowedState : CropState
    {
        public UnplowedState(CropTile cropTile)
        {
            cropTile.spriteRenderer.sprite = cropTile.unplowed;
        }
        
        public override CropState NextState(CropTile cropTile)
        {
            cropTile.spriteRenderer.sprite = cropTile.plowed;
            return new PlowedState();
        }
    }
    
    public class PlowedState : CropState
    {
        public override CropState NextState(CropTile cropTile)
        {
            return new SeededState();
        }
    }

    public class SeededState : CropState
    {
        public override CropState NextState(CropTile cropTile)
        {
            return new GrowingState();
        }
    }

    public class GrowingState : CropState
    {
        public override CropState NextState(CropTile cropTile)
        {
            return new GrownState();
        }
    }

    public class GrownState : CropState
    {
        public override CropState NextState(CropTile cropTile)
        {
            // Do something when the crop is fully grown
            return new UnplowedState(cropTile);
        }
    }
}