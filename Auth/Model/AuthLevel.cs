using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auth.Model
{
    /// <summary>
    /// This is the authorization levels for an employee
    /// given the level determines the privileges
    /// </summary>
    public enum AuthLevel
    {
        AuthLevelPrime = 7,
        AuthLevelOmega = 11,
        AuthLevelGamma = 13,
        AuthLevelMu = 17,
        AuthLevelTheta = 23,
        AuthLevelPhi = 29,
        AuthLevelKappa = 41
        
    }
}
