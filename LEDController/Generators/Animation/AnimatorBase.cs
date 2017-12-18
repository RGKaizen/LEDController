using LEDController.Interfaces;
namespace LEDController.Generators
{
    public class AnimatorBase
    {
        protected ILedManager ledManager { get; set; }

        public IPaletteManager palette { get; set; }

        public AnimatorBase(ILedManager ledManager, IPaletteManager palette)
        {
            this.palette = palette;
            this.ledManager = ledManager;
        }
    }
}
