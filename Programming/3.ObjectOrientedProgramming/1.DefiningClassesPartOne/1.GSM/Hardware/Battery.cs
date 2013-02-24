using System;
using System.Collections.Generic;

namespace GSM.Hardware
{
    public class Battery
    {
        public enum Type { LiIon, NiMH, NiCd }; // static by default

        // Private Constants
        private const uint MaxIdleHours = 1000;
        private const uint MaxTalkHours = 500;

        // Private Fields
        private uint? hoursIdle = null;
        private uint? hoursTalk = null;

        // Properties
        public Type Model { get; set; }

        public uint? HoursIdle
        {
            get { return this.hoursIdle; }

            set
            {
                if (value.GetValueOrDefault() > MaxIdleHours)
                    throw new ArgumentOutOfRangeException("Hours Idle too big!");

                this.hoursIdle = value;
            }
        }

        public uint? HoursTalk
        {
            get { return this.hoursTalk; }

            set
            {
                if (value.GetValueOrDefault() > MaxTalkHours)
                    throw new ArgumentOutOfRangeException("Hours Talk too big!");

                this.hoursTalk = value;
            }
        }

        // Constructors
        public Battery(Type model, uint? hoursIdle = null, uint? hoursTalk = null)
        {
            this.Model = model;
            this.HoursIdle = hoursIdle;
            this.HoursTalk = hoursTalk;
        }

        // Methods
        public override string ToString()
        {
            List<string> info = new List<string>();

            info.Add("Model: " + this.Model);

            if (this.HoursIdle.HasValue)
                info.Add("Hours Idle: " + this.HoursIdle);

            if (this.HoursTalk.HasValue)
                info.Add("Hours Talk: " + this.HoursTalk);

            return String.Join(", ", info);
        }
    }
}
