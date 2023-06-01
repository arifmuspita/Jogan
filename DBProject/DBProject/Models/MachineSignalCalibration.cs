using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;


namespace DBProject.Models
{
    public class MachineSignalCalibration : BaseSocket
    {
        [Required]
        public int MasterMachineID { get; set; }
        public double ScaleSignal { get; set; }
        [Required]
        public double ScaleOffset { get; set; }
        [Required]
        public double ScaleResistance { get; set; }
        [Required]
        public double MatchCorrFactor { get; set; } 
        [Required]
        public double Gain { get; set; }
        [Required]
        public double PT100CorrFactor { get; set; }
        public virtual M_MACHINE_TESTER MachineNoiseCalibration_Machine { get; set; }
    }
}