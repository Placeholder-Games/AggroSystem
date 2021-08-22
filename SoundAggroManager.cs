using System.Collections.Generic;

namespace AggroSystem
{
    public abstract class SoundAggroManager
    {
        private readonly double soundConstant;

        private List<SoundAggroable> soundAggroables;

        public SoundAggroManager(double SOUND_CONSTANT) 
        {
            this.soundConstant = SOUND_CONSTANT;

            soundAggroables = new List<SoundAggroable>();
        }

        public void EmitSound(SoundEmitter emitter)
        {
            soundAggroables.ForEach(aggroable => HandleAggroable(aggroable, emitter)); // Can be sped up a bit with for, but we aren't expecting to have tooo many aggroables
        }

        public void AddBlindAggroables(List<SoundAggroable> aggroables) 
        {
            soundAggroables.AddRange(aggroables);
        }

        public void RemoveBlindAggroable(SoundAggroable aggroable) 
        {
            soundAggroables.Remove(aggroable);
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
            return soundConstant * source.GetSoundIntensity() / source.DistanceSquared(target); //Might cause small bug, if the iteration is too low
        } 
    }
}