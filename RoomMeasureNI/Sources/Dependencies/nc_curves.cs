namespace RoomMeasureNI.Sources.Dependencies
{
    public enum NC_Curves
    {
        NC15,
        NC20,
        NC25,
        NC30,
        NC35,
        NC40,
        NC45,
        NC50,
        NC55,
        NC60,
        NC65,
        NC70,
        NC00
    }

    public enum Speaker
    {
        mezczyzna,
        kobieta
    }

    public static class nc_curves
    {
        private static readonly int[][] NC_data =
        {
            new[] {47, 36, 29, 22, 17, 14, 12, 11},
            new[] {51, 40, 33, 26, 22, 19, 17, 16},
            new[] {54, 44, 37, 31, 27, 24, 22, 21},
            new[] {57, 48, 41, 35, 31, 29, 28, 27},
            new[] {60, 52, 45, 40, 36, 34, 33, 32},
            new[] {64, 56, 50, 45, 41, 39, 38, 37},
            new[] {67, 60, 54, 49, 46, 44, 43, 42},
            new[] {71, 64, 58, 54, 51, 49, 48, 47},
            new[] {74, 67, 62, 58, 56, 54, 53, 52},
            new[] {77, 67, 62, 58, 56, 54, 53, 52},
            new[] {80, 75, 71, 68, 66, 64, 63, 62},
            new[] {83, 79, 75, 72, 71, 70, 69, 68},
            new[] {0, 0, 0, 0, 0, 0, 0, 0}
        };

        public static int[] get_nc(NC_Curves idx)
        {
            switch (idx)
            {
                case NC_Curves.NC15:
                    return NC_data[0];

                case NC_Curves.NC20:
                    return NC_data[1];

                case NC_Curves.NC25:
                    return NC_data[2];

                case NC_Curves.NC30:
                    return NC_data[3];

                case NC_Curves.NC35:
                    return NC_data[4];

                case NC_Curves.NC40:
                    return NC_data[5];

                case NC_Curves.NC45:
                    return NC_data[6];

                case NC_Curves.NC50:
                    return NC_data[7];

                case NC_Curves.NC55:
                    return NC_data[8];

                case NC_Curves.NC60:
                    return NC_data[9];

                case NC_Curves.NC65:
                    return NC_data[10];

                case NC_Curves.NC70:
                    return NC_data[11];

                default:
                    return NC_data[12];
            }
        }
    }
}