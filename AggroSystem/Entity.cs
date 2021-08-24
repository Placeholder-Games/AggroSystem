namespace AggroSystem
{
    public interface Entity
    {
        float DistanceSquared(Entity entity)
        {
            return (entity.GetXPos() - GetXPos()) * (entity.GetXPos() - GetXPos()) + 
            (entity.GetYPos() - GetYPos()) * (entity.GetYPos() - GetYPos());
        }

        float GetXPos();
        float GetYPos();
    }
}
