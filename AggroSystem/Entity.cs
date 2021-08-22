namespace AggroSystem
{
    public interface Entity
    {
        double DistanceSquared(Entity entity)
        {
            return (entity.GetXPos() - GetXPos()) * (entity.GetXPos() - GetXPos()) + 
            (entity.GetYPos() - GetYPos()) * (entity.GetYPos() - GetYPos());
        }

        double GetXPos();
        double GetYPos();
    }
}
