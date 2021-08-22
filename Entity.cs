using System;

namespace AggroSystem
{
    public interface Entity
    {
        double GetXPos();
        double GetYPos();

        double DistanceSquared(Entity entity)
        {
            return (entity.GetXPos() - GetXPos()) * (entity.GetXPos() - GetXPos()) + 
            (entity.GetYPos() - GetYPos()) * (entity.GetYPos() - GetYPos());
        }
    }
}
