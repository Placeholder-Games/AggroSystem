namespace AggroSystem
{
    public interface SoundEmitter : Entity
    {
        void EmitSound() => GetManager().EmitSound(this);
        SoundAggroManager GetManager();
        float GetSoundIntensity();
    }
}
