using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auth.Model
{
    public static class EnumExtension
    {
        public static double Get(this Enum v, int cents)
        {
            return Convert.ToInt32(v) + cents + 0.00;
        }
        public static int Get(this Enum v)
        {
            return Convert.ToInt32(v);
        }
    }
    public class MarriedIndividualsJointSurvivingSpouses
    {
        public List<KeyValuePair<double,double>> Table12021IncomeThresholds = new List<KeyValuePair<double,double>>
        {
            new KeyValuePair<double,double>(19900,0.10),// Equal to or less than
            new KeyValuePair<double,double>(81050,0.12),
            new KeyValuePair<double,double>(172750,0.22),
            new KeyValuePair<double,double>(329850,0.24),
            new KeyValuePair<double,double>(418850,0.32),
            new KeyValuePair<double,double>(628300,0.35),
            new KeyValuePair<double,double>(628301,0.37)
        };

        public enum TaxBracket
        {
            Tax1,
            Tax2,
            Tax3,
            Tax4,
            Tax5,
            Tax6,
            Tax7
        }

        public enum TaxAdded
        {
            Tax2Added = 1990,
            Tax3Added = 9328,
            Tax4Added = 29502,
            Tax5Added = 67206,
            Tax6Added = 95686,
            Tax7Added = 168993


        }
    }

    public class HeadOfHouseholds
    {
        public List<KeyValuePair<double,double>> Table22021IncomeThresholds = new List<KeyValuePair<double,double>>
        {
            new KeyValuePair<double,double>(14200,0.10),// Equal to or less than
            new KeyValuePair<double,double>(54200,0.12),
            new KeyValuePair<double,double>(86350,0.22),
            new KeyValuePair<double,double>(164900,0.24),
            new KeyValuePair<double,double>(290400,0.32),
            new KeyValuePair<double,double>(628300,0.35),
            new KeyValuePair<double,double>(523600,0.37)
        };
        public enum TaxBracket
        {
            Tax1,
            Tax2,
            Tax3,
            Tax4,
            Tax5,
            Tax6,
            Tax7
        }

        public enum TaxAdded
        {
            Tax2Added = 1420,
            Tax3Added = 6220,
            Tax4Added = 13293,
            Tax5Added = 32145,
            Tax6Added = 46385,
            Tax7Added = 156355


        }
    }

    public class UnmarriedIndividuals
    {
        public List<KeyValuePair<double,double>> Table32021IncomeThresholds = new List<KeyValuePair<double,double>>
        {
            new KeyValuePair<double,double>(9950,0.10),// Equal to or less than
            new KeyValuePair<double,double>(40525,0.12),
            new KeyValuePair<double,double>(86375,0.22),
            new KeyValuePair<double,double>(164925,0.24),
            new KeyValuePair<double,double>(209425,0.32),
            new KeyValuePair<double,double>(523600,0.35)
        };
        public enum TaxBracket
        {
            Tax1,
            Tax2,
            Tax3,
            Tax4,
            Tax5,
            Tax6
        }

        public enum TaxAdded
        {
            Tax2Added = 995,
            Tax3Added = 4664,
            Tax4Added = 14751,
            Tax5Added = 33603,
            Tax6Added = 47843,
            Tax7Added = 157805 // add twentyfive cents


        }
    }

    public class MarriedSeparate
    {
        public List<KeyValuePair<double,double>> Table42021IncomeThresholds = new List<KeyValuePair<double,double>>
        {
            new KeyValuePair<double,double>(9950,0.12),// Equal to or less than
            new KeyValuePair<double,double>(40525,0.22),
            new KeyValuePair<double,double>(86375,0.24),
            new KeyValuePair<double,double>(164925,0.32),
            new KeyValuePair<double,double>(290425,0.35),
            new KeyValuePair<double,double>(314150,0.37)
        };
        public enum TaxBracket
        {
            Tax1,
            Tax2,
            Tax3,
            Tax4,
            Tax5,
            Tax6
        }

        public enum TaxAdded
        {
            Tax2Added = 995,
            Tax3Added = 4664,
            Tax4Added = 14751,
            Tax5Added = 33603,
            Tax6Added = 47843,
            Tax7Added = 84496 // 75 


        }
    }

    public class EstatesTrusts
    {
        public List<KeyValuePair<double,double>> Table42021IncomeThresholds = new List<KeyValuePair<double,double>>
        {
            new KeyValuePair<double,double>(9950,0.10),// Equal to or less than
            new KeyValuePair<double,double>(40525,0.24),
            new KeyValuePair<double,double>(86375,0.35),
            new KeyValuePair<double,double>(164925,0.37)
        };
        public enum TaxBracket
        {
            Tax1,
            Tax2,
            Tax3,
            Tax4
        }

        public enum TaxAdded
        {
            Tax2Added = 265,
            Tax3Added = 1921,
            Tax4Added = 31460
        }
    }
}
