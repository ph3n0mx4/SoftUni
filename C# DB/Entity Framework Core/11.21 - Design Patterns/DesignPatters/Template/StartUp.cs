using System;

namespace Template
{
    class StartUp
    {
        static void Main()
        {
            var sourDough = new SourDough();
            sourDough.Make();

            var twelveGrain = new TwelveGrain();
            twelveGrain.Make();

            var wholeWheat = new WholeWheat();
            wholeWheat.Make();
        }
    }
}
