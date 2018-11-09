using System;

namespace AirscanDriver.Be
{
    class MySigProcX
    {
        private double _STATIC_alpha_beta___A;
        private double _STATIC_alpha_beta___B;
        private double _STATIC_alpha_beta___G;
        private double _STATIC_alpha_beta_vel;
        private double _STATIC_alpha_beta___pos;
        private bool _STATIC_alpha_beta___init2;

        private double m_Alpha_Gain;
        public double Alpha_Gain
        {
            get { return this.m_Alpha_Gain; }
            set { this.m_Alpha_Gain = value; }
        }

        private double m_Beta_Gain;
        public double Beta_Gain
        {
            get { return this.m_Beta_Gain; }
            set { this.m_Beta_Gain = value; }
        }

        internal void alpha_beta(ref bool init, double x, ref double alpha, ref double beta)
        {
            double num1 = 0.0;
            double num2;
            if (init)
            {
                this._STATIC_alpha_beta___A = x;
                this._STATIC_alpha_beta___B = 0.0;
                this._STATIC_alpha_beta___G = 0.0;
                num2 = 0.0;
                this._STATIC_alpha_beta_vel = 0.0;
                this._STATIC_alpha_beta___pos = x;
                this._STATIC_alpha_beta___init2 = true;
            }
            else if (this._STATIC_alpha_beta___init2)
            {
                num2 = 0.0;
                this._STATIC_alpha_beta_vel = x - this._STATIC_alpha_beta___pos;
                this._STATIC_alpha_beta___pos = x;
                this._STATIC_alpha_beta___init2 = false;
            }
            else
            {
                num2 = x - this._STATIC_alpha_beta___pos - this._STATIC_alpha_beta_vel;
                this._STATIC_alpha_beta_vel = x - this._STATIC_alpha_beta___pos;
                this._STATIC_alpha_beta___pos = x;
            }
            this._STATIC_alpha_beta___A = (this._STATIC_alpha_beta___A + this._STATIC_alpha_beta___B + 0.5 * this._STATIC_alpha_beta___G) * (1.0 - this.m_Alpha_Gain) + this.m_Alpha_Gain * this._STATIC_alpha_beta___pos;
            this._STATIC_alpha_beta___B = (this._STATIC_alpha_beta___B + this._STATIC_alpha_beta___G) * (1.0 - this.m_Beta_Gain) + this.m_Beta_Gain * this._STATIC_alpha_beta_vel;
            alpha = this._STATIC_alpha_beta___A;
            beta = this._STATIC_alpha_beta___B;
            num1 = this._STATIC_alpha_beta___G;
        }
    }
}