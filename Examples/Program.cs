using System;
using AggroSystem;

namespace examples
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting... ");

            SoundAggroManager soundAggro = new SoundAggro();
            SoundEmitter gun = new Gun(soundAggro);
            SightAggroManager sightAggro = new SightAggro(gun);
            
            SightAggroable farDeer = new Deer("Far Deer", 2f, 2f);
            SightAggroable closeDeer = new Deer("Close Deer", 1.2f, 1.2f);
            Mob enemyInRange = new Mob("Close Boi", 1f, 1f);
            Mob enemyOutsideRange = new Mob("Far Boi", 2f, 2f);
            
            soundAggro.AddAggroables(enemyInRange, enemyOutsideRange, farDeer, closeDeer);

            Console.WriteLine("Shooting...");
            gun.EmitSound();

            sightAggro.AddAggroables(closeDeer, farDeer);
            
            Console.WriteLine("Seeing...");
            sightAggro.AggroBySight();
        }
    }

    class SoundAggro : SoundAggroManager
    {
        public SoundAggro() : base(1)
        {
        }

        protected override float AbstractionMultiplier(SoundEmitter source, Entity target)
        {
            return 1;
        }
    }

    class Gun : SoundEmitter
    {
        private readonly SoundAggroManager aggroManager;

        public Gun(SoundAggroManager aggroManager)
        {
            this.aggroManager = aggroManager;
        }

        public SoundAggroManager GetManager()
        {
            return aggroManager;
        }

        public float GetSoundIntensity()
        {
            return 20f;
        }

        public float GetXPos()
        {
            return 0f;
        }

        public float GetYPos()
        {
            return 0f;
        }

        public override string ToString()
        {
            return string.Format("Gun x: {0}, y: {1}", GetXPos(), GetYPos());
        }
    }

    class Mob : SoundAggroable
    {
        private readonly String name;
        private readonly float x;
        private readonly float y;

        public Mob(string name, float x, float y)
        {
            this.name = name;
            this.x = x;
            this.y = y;
        }

        public void Aggro(Entity entity)
        {
            Console.WriteLine(String.Format("Mob {0} at {1} aggroing to {2}", name, this, entity));
        }

        public float GetMinimumSoundIntensity()
        {
            return 5f;
        }

        public float GetXPos()
        {
            return x;
        }

        public float GetYPos()
        {
            return y;
        }

        public override string ToString()
        {
            return string.Format("x: {0}, y: {1}", x, y);
        }
    }

    class SightAggro : SightAggroManager
    {
        public SightAggro(Entity aggroTarget) : base(aggroTarget)
        {
        }

        protected override bool IsAbstracted(SightAggroable aggroable, Entity target)
        {
            return false;
        }
    }

    class Deer : Mob, SightAggroable
    {
        public Deer(string name, float x, float y) : base(name, x, y)
        {
        }

        public float SightRadius()
        {
            return 3f;
        }
    }
}
