using System.Collections.Generic;

namespace AggroSystem
{
    public abstract class SoundAggroManager
    {
        private readonly double soundConstant;

        private List<SoundAggroable> soundAggroables;

        public SoundAggroManager(double soundConstant) 
        {
            this.soundConstant = soundConstant;

            soundAggroables = new List<SoundAggroable>();
        }

        public void AddAggroables(params SoundAggroable[] aggroables) 
        {
            soundAggroables.AddRange(aggroables);
        }

        public void AddAggroables(List<SoundAggroable> aggroables) 
        {
            soundAggroables.AddRange(aggroables);
        }

        public void RemoveAggroable(SoundAggroable aggroable) 
        {
            soundAggroables.Remove(aggroable);
        }

        public void EmitSound(SoundEmitter emitter)
        {
            for (int i = 0; i < soundAggroables.Count; i++)
            {
                HandleAggroable(soundAggroables[i], emitter);
            }
        }

        protected abstract double AbstractionMultiplier(SoundEmitter source, Entity target);

        private void HandleAggroable(SoundAggroable aggroable, SoundEmitter source)
        {
            double intensityAtAggroable = UnAbstractedSoundIntensityAt(source, aggroable) * AbstractionMultiplier(source, aggroable);

            if (intensityAtAggroable >= aggroable.GetMinimumSoundIntensity())
            {
                aggroable.Aggro(source);
            }
        }

        private double UnAbstractedSoundIntensityAt(SoundEmitter source, Entity target)
        {
            return soundConstant * source.GetSoundIntensity() / source.DistanceSquared(target); //Might cause small bug, if the iteration is too slow
        } 
    }
}