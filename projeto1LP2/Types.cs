using System;

namespace projeto1LP2
{
    struct Types
    {
        // Teste
        public string Teste { get; set; }
        /*// Planet Name
        public string Pl_Name { get; set; }
        // Host Name
        public string HostName { get; set; }
        // Default Parameter set
        public int Default_Flag { get; set; } 
        // Number of Stars 
        public int Sy_Snum { get; set; }
        // Number of Planets
        public int Sy_Pnum { get; set; }
        // Discovery Method
        public string DiscoveryMethod { get; set; }
        // Discovery Year
        public int Disc_Year { get; set; }
        // Discovery Facility
        public string Disc_Facility { get; set; }
        // Controversial Flag
        public int Pl_Controv_Flag { get; set; }
        // Planetary Parameter Reference
        public string Pl_RefName { get; set; }
        // Orbital Period (days)
        public float Pl_Orbper { get; set; }
        // Orbital Period Upper Unc. (days)
        public float Pl_Orbpererr1 { get; set; }
        // Orbital Period  Lower Unc. (days)
        public float Pl_Orbpererr2 { get; set; }
        // Orbital Period Limit Flag
        public int Pl_Obperlim { get; set; }
        // Orbit Semi-Major Axis (au)
        public float Pl_OrbsMax { get; set; }
        // Orbit Semi-Major Axis Upper Unc. (au)
        public float Pl_OrbsMaxerr1 { get; set; }
        // Orbit Semi-Major Axis Lower Unc. (au)
        public float Pl_OrbsMaxerr2 { get; set; }
        // Orbit Semi-Major Axis Limit Flag
        public int Pl_orbsmaxlim { get; set; }
        // Planet Radius (Earth Radius)
        public int Pl_OrbsMaxLim { get; set; }
        // Planet Radius (earth radius)
        public float Pl_Rade { get; set; }
        // Planet Radius Upper Unc. (Earth Radius)
        public float Pl_Radeerr1 { get; set; }
        // Planet Radius Lower Unc. (Earth Radius)
        public float Pl_Radeerr2 { get; set; }
        // Planet Radius Limit Flag
        public int Pl_RadeLim { get; set; }
        // Planet Radius Upper (Jupiter Radius)
        public float Pl_RadJ { get; set; }
        // Planet Radius Upper Unc. (Jupiter Radius)
        public float Pl_RadJerr1 { get; set; }
        // Planet Radius Lower Unc. (Jupiter Radius)
        public float Pl_RadJerr2 { get; set; }
        // Planet Radius Limit Flag
        public int Pl_RadjLim { get; set; }
        // Planet Mass or Mass * sin(i) (Earth Mass)
        public float Pl_BMasse { get; set; }
        // Planet Mass or Mass * sin(i) (Earth Mass) Upper Unc.
        public float Pl_BMasserr1 { get; set; }
        // Planet Mass or Mass * sin(i) (Earth Mass) Lower Unc.
        public float Pl_BMasserr2 { get; set; }
        // Planet Mass or Mass * sin(i) (Earth Mass) Limit Flag
        public int Pl_BMasseLim { get; set; }
        // Planet Mass or Mass * sin(i) (Jupiter Mass)
        public float Pl_BMassj { get; set; }
        // Planet Mass or Mass * sin(i) (Jupiter Mass) Upper Unc.
        public float Pl_BMassJerr1 { get; set; }
        // Planet Mass or Mass * sin(i) (Jupiter Mass) Lower Unc.
        public float Pl_BMassJerr2 { get; set; }
        // Planet Mass or Mass * sin(i) (Jupiter Mass) Limit Flag
        public int Pl_BMassjLim { get; set; }
        // Planet Mass or Mass * sin(i) Provenance
        public string Pl_BMassProv { get; set; }
        // Eccentricity
        public float Pl_Orbeccen { get; set; }
        // Eccentricity Upper Unc.
        public float Pl_Orbeccenerr1 { get; set; }
        // Eccentricity Lower Unc.
        public float Pl_Orbeccenerr2 { get; set; }
        // Eccentricity Limit Flag
        public int Pl_OrbeccenLim { get; set; }
        // Insolation Flux (Earth Flux)
        public float Pl_Insol { get; set; }
        // Insolation Flux Upper Unc. (Earth Flux)
        public float Pl_Insolerr1 { get; set; }
        // Insolation Flux Lower Unc. (Earth Flux)
        public float Pl_Insolerr12 { get; set; }
        // Insolation Flux Limit Flag
        public int Pl_InsolLim { get; set; }
        // Equilibrium Temperature (K)
        public int Pl_Eqt { get; set; }
        // Equilibrium Temperature Upper Unc. (K)
        public int Pl_Eqterr1 { get; set; }
        // Equilibrium Temperature Lower Unc. (K)
        public int Pl_Eqterr2 { get; set; }
        // Equilibrium Temperature Limit Flag
        public int Pl_Eqtlim { get; set; }
        // Data Show Transit Timing Variations
        public int TTV_Flag { get; set; }
        // Stellar Parameter Reference
        public string St_RefName { get; set; }
        // Stellar Effective Temperature (K)
        public float St_Teff { get; set; }
        // Stellar Effective Temperature Upper Unc. (K)
        public float St_Teffer1 { get; set; }
        // Stellar Effective Temperature Lower Unc. (K)
        public float St_Teffer2 { get; set; }
        // Stellar Radius (Solar Radius)
        public float St_Rad { get; set; }
        // Stellar Radius Upper Unc. (Solar Radius)
        public float St_Raderr1 { get; set; }
        // Stellar Radius Lower Unc. (Solar Radius)
        public float St_Raderr2 { get; set; }
        // Stellar Radius Limit Flag
        public int St_RadLim { get; set; }
        // Stellar Mass (Solar Mass)
        public float St_Mass { get; set; }
        // Stellar Mass Upper Unc. (Solar Mass)
        public float St_Masserr1 { get; set; }
        // Stellar Mass Lower Unc. (Solar Mass)
        public float St_Masserr2 { get; set; }
        // Stellar Mass Limit Flag
        public int St_MassLim { get; set; }
        // Stellar Metallicity (dex)
        public float St_Met { get; set; }
        // Stellar Metallicity Upper Unc (dex)
        public float St_Meterr1 { get; set; }
        // Stellar Metallicity Lower Unc (dex)
        public float St_Meterr2 { get; set; }
        // Stellar Metallicity Limit Flag
        public int St_MetfLim { get; set; }
        // Stellar Metallicity Ratio
        public string St_Metratio { get; set; }
        // Stellar Surface Gravity [log10(cm/s**2)]
        public float St_Logg { get; set; }
        // Stellar Surface Gravity Upper Unc [log10(cm/s**2)]
        public float St_Loggerr1 { get; set; }
        // Stellar Surface Gravity Lower Unc [log10(cm/s**2)]
        public float St_Loggerr2 { get; set; }
        // Stellar Surface Gravity Limit Flag
        public int St_Logglim { get; set; }
        // System Parameter Reference
        public string Sy_RefName { get; set; }
        // RA (Sexagesinal)
        public string Rastr { get; set; }
        // RA (Decimal)
        public float Ra { get; set; }
        // Dec (Sexagesinal)
        public string Decstr { get; set; }
        // Dec (Decimal)
        public float Dec { get; set; }
        // Distance (Pc)
        public float Sy_Dist { get; set; }
        // Distance (Pc) Upper Unc
        public float Sy_Disterr1 { get; set; }
        // Distance (Pc) Lower Unc
        public float Sy_Disterr2 { get; set; }
        // V (Johnson) Magnitude
        public float Sy_VMag { get; set; }
        // V (Johnson) Magnitude Upper Unc
        public float Sy_VMagerr1 { get; set; }
        // V (Johnson) Magnitude Lower Unc
        public float Sy_VMagerr2 { get; set; }
        // Ks (2MASS) Magnitude
        public float Sy_KMag { get; set; }
        // Ks (2MASS) Magnitude Upper Unc
        public float Sy_KMagerr1 { get; set; }
        // Ks (2MASS) Magnitude Lower Unc
        public float Sy_KMagerr2 { get; set; }
        // Gaia Magnitude 
        public float Sy_GaiaMag { get; set; }
        // Gaia Magnitude Upper Unc
        public float Sy_GaiaMagerr1 { get; set; }
        // Gaia Magnitude Lower Unc
        public float Sy_GaiaMagerr2 { get; set; }
        // Date of Last Update
        public string RowUpdate { get; set; }
        // Planetary Parameter Reference Publication Date
        public string P1_PubDate { get; set; }
        // Release Date
        public string ReleaseDate { get; set; }*/

        public Types(string teste) {
            Teste = teste;
        }
    }
}
