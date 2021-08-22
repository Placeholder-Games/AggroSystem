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
            
            SightAggroable farDeer = new Deer("Far Deer", 2, 2);
            SightAggroable closeDeer = new Deer("Close Deer", 1.2, 1.2);
            Mob enemyInRange = new Mob("Close Boi", 1, 1);
            Mob enemyOutsideRange = new Mob("Far Boi", 2, 2);
            
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

        protected override double AbstractionMultiplier(SoundEmitter source, Entity target)
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

        public double GetSoundIntensity()
        {
            return 20;
        }

        public double GetXPos()
        {
            return 0;
        }

        public double GetYPos()
        {
            return 0;
        }

        public override string ToString()
        {
            return string.Format("Gun x: {0}, y: {1}", GetXPos(), GetYPos());
        }
    }

    class Mob : SoundAggroable
    {
        private readonly String name;
        private readonly double x;
        private readonly double y;

        public Mob(string name, double x, double y)
        {
            this.name = name;
            this.x = x;
            this.y = y;
        }

        public void Aggro(Entity entity)
        {
            Console.WriteLine(String.Format("Mob {0} at {1} aggroing to {2}", name, this, entity));
        }

        public double GetMinimumSoundIntensity()
        {
            return 5;
        }

        public double GetXPos()
        {
            return x;
        }

        public double GetYPos()
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
        public Deer(string name, double x, double y) : base(name, x, y)
        {
        }

        public double SightRadius()
        {
            return 3;
        }
    }
}
