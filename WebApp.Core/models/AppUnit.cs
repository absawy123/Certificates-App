namespace WebApp.Core.models
{
    public static class AppUnit
    {

        private static readonly List<string> _loadUnits = new() { "Ton","Lb","Kg","Person" };
        private static readonly List<string> _lengthUnits = new() { "Meter", "Inch", "Foot", "Cm" };

        public static IReadOnlyList<string> LoadUnits => _loadUnits.AsReadOnly();
        public static IReadOnlyList<string> LengthUnits => _lengthUnits.AsReadOnly();


        public static bool AddLoad(string unit)
        {
            if (!_loadUnits.Contains(unit))
            {
                _loadUnits.Add(unit);
                return true;
            }
               return false;
        }

        public static bool AddLength(string unit)
        {
            if (!_lengthUnits.Contains(unit))
            {
                _lengthUnits.Add(unit);
                return true ;
            }
            return false;
                
        }



        //public static void AddLoad(string unit, string unitType)
        //{
        //    if (unitType.Equals("Load", StringComparison.OrdinalIgnoreCase))
        //    {
        //        if (!_loadUnits.Contains(unit))
        //            _loadUnits.Add(unit);
        //    }
        //    else if (unitType.Equals("Length", StringComparison.OrdinalIgnoreCase))
        //    {
        //        if (!_lengthUnits.Contains(unit))
        //            _lengthUnits.Add(unit);
        //    }
        //}


    }
}
