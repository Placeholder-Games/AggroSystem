using System.Collections.Generic;

namespace AggroSystem
{
    public abstract class SightAggroManager
    {
        private readonly Entity aggroTarget;
        private List<SightAggroable> sightAggroables;

        public SightAggroManager(Entity aggroTarget)
        {
            this.aggroTarget = aggroTarget;

            sightAggroables = new List<SightAggroable>();
        }

        public void AddAggroables(params SightAggroable[] aggroables) 
        {
            sightAggroables.AddRange(aggroables);
        }

        public void AddAggroables(List<SightAggroable> aggroables) 
        {
            sightAggroables.AddRange(aggroables);
        }

        public void RemoveAggroable(SightAggroable aggroable)
        {
            sightAggroables.Remove(aggroable);
        }

        public void AggroBySight() 
        {
            for (int i = 0; i < sightAggroables.Count; i++)
            {
                HandleAggroable(sightAggroables[i]);
            }
        }

        private void HandleAggroable(SightAggroable aggroable)
        {
            if (aggroable.DistanceSquared(aggroTarget) <= aggroable.SightRadius() * aggroable.SightRadius())
            {
                if (!IsAbstracted(aggroable, aggroTarget))
                {
                    aggroable.Aggro(aggroTarget);
                }
            }
        }

        protected abstract bool IsAbstracted(SightAggroable aggroable, Entity target);
    }
}
