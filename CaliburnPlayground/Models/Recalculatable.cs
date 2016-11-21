using Caliburn.Micro;

namespace CaliburnPlayground.Models
{
    public abstract class Recalculatable : PropertyChangedBase
    {
        public abstract void Recalculate();
    }
}