using System.Collections.Generic;

namespace AggroSystem
{
    public abstract class AggroManager
    {
        private List<BlindAggroable> blindEntities;
        private List<SeeingAggroable> seeingEntities;

        public AggroManager()
        {
            blindEntities = new List<BlindAggroable>();
            seeingEntities = new List<SeeingAggroable>();
        }

        public void EmitSound(SoundEmitter emitter)
        {
            
        }

        public void AddBlindEntities(List<BlindAggroable> entities) 
        {
            blindEntities.AddRange(entities);
        }

        public void AddSeeingEntities(List<SeeingAggroable> entities) 
        {
            seeingEntities.AddRange(entities);
        }

        public void RemoveBlindEntity(BlindAggroable entity)
        {
            blindEntities.Remove(entity);
        }

        public void RemoveSeeingEntity(SeeingAggroable entity)
        {
            seeingEntities.Remove(entity);
        }
    }
}