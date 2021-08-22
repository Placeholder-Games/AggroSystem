namespace AggroSystem
{
    public interface SoundEmitter : Entity
    {
        void EmitSound() 
        {
            GetManager().EmitSound(this);
        }

        AggroManager GetManager();
        double GetSoundEntensity();
    }
}
