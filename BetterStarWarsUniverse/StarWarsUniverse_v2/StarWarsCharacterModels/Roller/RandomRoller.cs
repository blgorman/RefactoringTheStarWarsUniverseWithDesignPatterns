namespace StarWarsCharacterModels.Roller
{
    public sealed class RandomRoller
    {
        private static RandomRoller _roller = null;
        private static readonly object instanceLock = new object();
        private static Random _random;

        //do not expose a public constructor
        private RandomRoller()
        {
            _random = new Random();
        }

        //instead, expose a static instance
        public static RandomRoller Instance
        {
            get
            {
                lock (instanceLock)
                {
                    //if the roller is null, create it new
                    if (_roller == null)
                    {
                        _roller = new RandomRoller();
                    }
                    //return the roller 
                    return _roller;
                }
            }
        }

        //utilize this method to get access to the internal
        //random object that is now singleton
        public static Random Roller
        {
            get
            {
                if (_roller == null) { var x = Instance; }
                
                return _random;
            }
        }
    }
}
