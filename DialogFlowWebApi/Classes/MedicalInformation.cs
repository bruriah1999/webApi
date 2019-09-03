using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DialogFlowWebApi.Models;


namespace DialogFlowWebApi.Classes
{
    public class MedicalInformation
    {
        PersonDetails pd;
        smoking smoke;
        obesityAndExercise oae;
        generalFeeling gf;
        drugs d;

        public MedicalInformation(PersonDetails pd, smoking smoke, obesityAndExercise oae, generalFeeling gf, drugs d)
        {
            this.pd = pd;
            this.smoke = smoke;
            this.oae = oae;
            this.gf = gf;
            this.d = d;
        }
    }
}