// Decompiled with JetBrains decompiler
// Type: MathLibX.SigProcX
// Assembly: MathLibX, Version=1.0.3214.18384, Culture=neutral, PublicKeyToken=null
// MVID: 4A2A266E-5537-4A42-8510-5B99ABFA4AEC
// Assembly location: D:\Projects\Other\Widget Designer 6.0.5\MathLibX.dll

using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Threading;

namespace MathLibX
{
    public class SigProcX
    {
        private IContainer components;
        private bool registerok;
        public long globalisign;
        public long M_RegKey;
        public double m_Beta_Gain;
        public double m_Alpha_Gain;
        public long m_Low_pass_kernal;
        public long m_High_pass_kernal;
        public bool is_cpp;
        [SpecialName]
        private double _STATIC_IIR_Filter_gamma;
        [SpecialName]
        private double _STATIC_alpha_beta_vel;
        [SpecialName]
        private double _STATIC_IIR_Filter_xminus;
        [SpecialName]
        private double _STATIC_Data_xminus;
        [SpecialName]
        private bool _STATIC_alpha_beta___init2;
        [SpecialName]
        private double _STATIC_IIR_Filter_206A2DDD10D10D_yminus;
        [SpecialName]
        private double _STATIC_Data_205A2D10D10D10D_yminus;
        [SpecialName]
        private double[] _STATIC_Spline_interpolate_205D2A101DD101DDD_y22;
        [SpecialName]
        private double _STATIC_alpha_beta___B;
        [SpecialName]
        private StaticLocalInitFlag _STATIC_FIR_Filter_2051C210DA101DD10D_Datadum_Init;
        [SpecialName]
        private double[] _STATIC_FIR_Filter_2051C210DA101DD10D_Datareal;
        [SpecialName]
        private StaticLocalInitFlag _STATIC_FIR_Filter_2051C210DA101DD10D_Datareal_Init;
        [SpecialName]
        private double _STATIC_FIR_Filter_2051C210DA101DD10D_w;
        [SpecialName]
        private StaticLocalInitFlag _STATIC_FIR_Filter_2051C210DA101DD10D_datastore_Init;
        [SpecialName]
        private double[] _STATIC_FIR_Filter_2051C210DA101DD10D_Datadum;
        [SpecialName]
        private StaticLocalInitFlag _STATIC_Spline_interpolate_205D2A101DD101DDD_y22_Init;
        [SpecialName]
        private double[] _STATIC_FIR_Filter_2051C210DA101DD10D_datastore;
        [SpecialName]
        private double _STATIC_FIR_Filter_2051C210DA101DD10D_runave;
        [SpecialName]
        private double _STATIC_FIR_Filter_2051C210DA101DD10D_userunave;
        [SpecialName]
        private long _STATIC_FIR_Filter_2051C210DA101DD10D_queindex;
        [SpecialName]
        private double _STATIC_IIR_Filter_206A2DDD10D10D_theta;
        [SpecialName]
        private bool _STATIC_FIR_Filter_2051C210DA101DD10D_start_filter;
        [SpecialName]
        private double _STATIC_Data_205A2D10D10D10D_low;
        [SpecialName]
        private double _STATIC_Data_205A2D10D10D10D_high;
        [SpecialName]
        private double _STATIC_alpha_beta___G;
        [SpecialName]
        private double _STATIC_IIR_Filter_206A2DDD10D10D_alpha;
        [SpecialName]
        private double _STATIC_alpha_beta___A;
        [SpecialName]
        private double _STATIC_alpha_beta___pos;

        public SigProcX()
        {
            this.Load += new EventHandler(this.SigProcX_Load);
            this._STATIC_FIR_Filter_2051C210DA101DD10D_Datadum_Init = new StaticLocalInitFlag();
            this._STATIC_FIR_Filter_2051C210DA101DD10D_Datareal_Init = new StaticLocalInitFlag();
            this._STATIC_FIR_Filter_2051C210DA101DD10D_datastore_Init = new StaticLocalInitFlag();
            this._STATIC_Spline_interpolate_205D2A101DD101DDD_y22_Init = new StaticLocalInitFlag();
            this.InitializeComponent();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && this.components != null)
                this.components.Dispose();
            base.Dispose(disposing);
        }

        [DebuggerStepThrough]
        private void InitializeComponent()
        {
            ResourceManager resourceManager = new ResourceManager(typeof(SigProcX));
            this.AccessibleRole = AccessibleRole.None;
            this.BackgroundImage = (Image)resourceManager.GetObject("$this.BackgroundImage");
            this.Name = nameof(SigProcX);
            this.Size = new Size(32, 32);
        }

        private void SigProcX_Load(object sender, EventArgs e)
        {
            long delta;
            this.registerok = Module1.registercheck(this.DesignMode, ref delta);
        }

        public long RegKey
        {
            get
            {
                return this.M_RegKey;
            }
            set
            {
                this.M_RegKey = value;
                Interaction.SaveSetting("NCS3", "Ran2", "Number", Conversions.ToString(this.M_RegKey));
            }
        }

        public bool is_c_code
        {
            get
            {
                return this.is_cpp;
            }
            set
            {
                this.is_cpp = value;
            }
        }

        public long Low_pass_kernal
        {
            get
            {
                return this.m_Low_pass_kernal;
            }
            set
            {
                this.m_Low_pass_kernal = value;
            }
        }

        public long High_pass_kernal
        {
            get
            {
                return this.m_High_pass_kernal;
            }
            set
            {
                this.m_High_pass_kernal = value;
            }
        }

        public double Alpha_Gain
        {
            get
            {
                return this.m_Alpha_Gain;
            }
            set
            {
                this.m_Alpha_Gain = value;
            }
        }

        public double Beta_Gain
        {
            get
            {
                return this.m_Beta_Gain;
            }
            set
            {
                this.m_Beta_Gain = value;
            }
        }

        public long IIR_Filter(bool init, double x, double frequency_cutoff, double frequency_sample, ref double lowpass, ref double highpass)
        {
            int num1;
            long num2;
            int num3;
            try
            {
                ProjectData.ClearProjectError();
                num1 = 2;
                num2 = 0L;
                if (init)
                {
                    this._STATIC_IIR_Filter_206A2DDD10D10D_theta = 2.0 * Math.PI * frequency_cutoff / frequency_sample;
                    this._STATIC_IIR_Filter_gamma = Math.Cos(this._STATIC_IIR_Filter_206A2DDD10D10D_theta) / (1.0 + Math.Sin(this._STATIC_IIR_Filter_206A2DDD10D10D_theta));
                    this._STATIC_IIR_Filter_206A2DDD10D10D_alpha = (1.0 - this._STATIC_IIR_Filter_gamma) / 2.0;
                    lowpass = x;
                    highpass = x;
                }
                else
                {
                    lowpass = this._STATIC_IIR_Filter_206A2DDD10D10D_alpha * (x + this._STATIC_IIR_Filter_xminus) + this._STATIC_IIR_Filter_gamma * this._STATIC_IIR_Filter_206A2DDD10D10D_yminus;
                    highpass = x - lowpass;
                }
                this._STATIC_IIR_Filter_206A2DDD10D10D_yminus = lowpass;
                this._STATIC_IIR_Filter_xminus = x;
                goto label_10;
                label_5:
                num3 = -1;
                switch (num1)
                {
                    case 2:
                        num2 = (long)Information.Err().Number;
                        goto label_10;
                }
            }
            catch (Exception ex) when (ex is Exception & (uint)num1 > 0U & num3 == 0)
            {
                ProjectData.SetProjectError(ex);
                goto label_5;
            }
            throw ProjectData.CreateProjectError(-2146828237);
            label_10:
            long num4 = num2;
            if (num3 == 0)
                return num4;
            ProjectData.ClearProjectError();
            return num4;
        }

        public object FIR_Filter(bool init, ref double x, long num_filter_weights, ref double[] filter_weights, ref double filter_data)
        {
            int num1;
            object obj1;
            int num2;
            try
            {
                Monitor.Enter((object)this._STATIC_FIR_Filter_2051C210DA101DD10D_Datadum_Init);
                try
                {
                    if (this._STATIC_FIR_Filter_2051C210DA101DD10D_Datadum_Init.State == (short)0)
                    {
                        this._STATIC_FIR_Filter_2051C210DA101DD10D_Datadum_Init.State = (short)2;
                        this._STATIC_FIR_Filter_2051C210DA101DD10D_Datadum = new double[513];
                    }
                    else if (this._STATIC_FIR_Filter_2051C210DA101DD10D_Datadum_Init.State == (short)2)
                        throw new IncompleteInitialization();
                }
                finally
                {
                    this._STATIC_FIR_Filter_2051C210DA101DD10D_Datadum_Init.State = (short)1;
                    Monitor.Exit((object)this._STATIC_FIR_Filter_2051C210DA101DD10D_Datadum_Init);
                }
                Monitor.Enter((object)this._STATIC_FIR_Filter_2051C210DA101DD10D_Datareal_Init);
                try
                {
                    if (this._STATIC_FIR_Filter_2051C210DA101DD10D_Datareal_Init.State == (short)0)
                    {
                        this._STATIC_FIR_Filter_2051C210DA101DD10D_Datareal_Init.State = (short)2;
                        this._STATIC_FIR_Filter_2051C210DA101DD10D_Datareal = new double[513];
                    }
                    else if (this._STATIC_FIR_Filter_2051C210DA101DD10D_Datareal_Init.State == (short)2)
                        throw new IncompleteInitialization();
                }
                finally
                {
                    this._STATIC_FIR_Filter_2051C210DA101DD10D_Datareal_Init.State = (short)1;
                    Monitor.Exit((object)this._STATIC_FIR_Filter_2051C210DA101DD10D_Datareal_Init);
                }
                Monitor.Enter((object)this._STATIC_FIR_Filter_2051C210DA101DD10D_datastore_Init);
                try
                {
                    if (this._STATIC_FIR_Filter_2051C210DA101DD10D_datastore_Init.State == (short)0)
                    {
                        this._STATIC_FIR_Filter_2051C210DA101DD10D_datastore_Init.State = (short)2;
                        this._STATIC_FIR_Filter_2051C210DA101DD10D_datastore = new double[513];
                    }
                    else if (this._STATIC_FIR_Filter_2051C210DA101DD10D_datastore_Init.State == (short)2)
                        throw new IncompleteInitialization();
                }
                finally
                {
                    this._STATIC_FIR_Filter_2051C210DA101DD10D_datastore_Init.State = (short)1;
                    Monitor.Exit((object)this._STATIC_FIR_Filter_2051C210DA101DD10D_datastore_Init);
                }
                ProjectData.ClearProjectError();
                num1 = 2;
                long num3 = checked(num_filter_weights * 2L);
                obj1 = (object)0;
                filter_data = 0.0;
                if (init)
                {
                    double a = Math.Log((double)num_filter_weights) / Math.Log(2.0);
                    if (a - (double)checked((int)Math.Round(a)) != 0.0)
                    {
                        int num4 = (int)Interaction.MsgBox((object)"num_filter_weights must be a power of 2, e.g., 2, 4, 8, 16, 32, 64...", MsgBoxStyle.OkOnly, (object)null);
                    }
                    else if (num_filter_weights > 512L)
                    {
                        int num5 = (int)Interaction.MsgBox((object)"num_filter_weights must be less than 512", MsgBoxStyle.OkOnly, (object)null);
                    }
                    else
                    {
                        long num6 = 0;
                        long num7 = checked(num_filter_weights - 1L);
                        long num8 = num6;
                        while (num8 <= num7)
                        {
                            this._STATIC_FIR_Filter_2051C210DA101DD10D_Datareal[checked((int)num8)] = filter_weights[checked((int)num8)];
                            this._STATIC_FIR_Filter_2051C210DA101DD10D_Datadum[checked((int)num8)] = 0.0;
                            checked { ++num8; }
                        }
                        this._STATIC_FIR_Filter_2051C210DA101DD10D_userunave = this._STATIC_FIR_Filter_2051C210DA101DD10D_Datareal[0];
                        this._STATIC_FIR_Filter_2051C210DA101DD10D_Datareal[0] = 1.0;
                        this.ICFFT(ref this._STATIC_FIR_Filter_2051C210DA101DD10D_Datareal, ref this._STATIC_FIR_Filter_2051C210DA101DD10D_Datadum, num_filter_weights);
                        this._STATIC_FIR_Filter_2051C210DA101DD10D_w = 0.0;
                        long num9 = 0;
                        long num10 = checked(num_filter_weights * 2L - 1L);
                        long num11 = num9;
                        while (num11 <= num10)
                        {
                            if (num11 < num_filter_weights)
                                this._STATIC_FIR_Filter_2051C210DA101DD10D_w += this._STATIC_FIR_Filter_2051C210DA101DD10D_Datareal[checked((int)num11)];
                            this._STATIC_FIR_Filter_2051C210DA101DD10D_Datadum[checked((int)num11)] = 0.0;
                            this._STATIC_FIR_Filter_2051C210DA101DD10D_datastore[checked((int)num11)] = 0.0;
                            checked { ++num11; }
                        }
                        this._STATIC_FIR_Filter_2051C210DA101DD10D_queindex = 0L;
                        this._STATIC_FIR_Filter_2051C210DA101DD10D_start_filter = false;
                        this._STATIC_FIR_Filter_2051C210DA101DD10D_runave = x;
                        goto label_50;
                    }
                }
                else
                {
                    this._STATIC_FIR_Filter_2051C210DA101DD10D_runave = (this._STATIC_FIR_Filter_2051C210DA101DD10D_runave * (double)num_filter_weights + x) / (double)checked(num_filter_weights + 1L);
                    x -= this._STATIC_FIR_Filter_2051C210DA101DD10D_runave * (1.0 - this._STATIC_FIR_Filter_2051C210DA101DD10D_userunave);
                    this._STATIC_FIR_Filter_2051C210DA101DD10D_datastore[checked((int)this._STATIC_FIR_Filter_2051C210DA101DD10D_queindex)] = x;
                    checked { ++this._STATIC_FIR_Filter_2051C210DA101DD10D_queindex; }
                    if (this._STATIC_FIR_Filter_2051C210DA101DD10D_queindex > checked(num_filter_weights * 2L - 1L))
                    {
                        this._STATIC_FIR_Filter_2051C210DA101DD10D_start_filter = true;
                        this._STATIC_FIR_Filter_2051C210DA101DD10D_queindex = 0L;
                    }
                    if (this._STATIC_FIR_Filter_2051C210DA101DD10D_start_filter)
                    {
                        long num4 = 0;
                        long num5 = checked(num_filter_weights - 1L);
                        long num6 = num4;
                        while (num6 <= num5)
                        {
                            long num7 = checked(this._STATIC_FIR_Filter_2051C210DA101DD10D_queindex + num6);
                            if (num7 > checked(num_filter_weights * 2L - 1L))
                                checked { num7 -= num_filter_weights * 2L; }
                            long num8 = checked(this._STATIC_FIR_Filter_2051C210DA101DD10D_queindex - num6);
                            if (num8 < 0L)
                                checked { num8 += num_filter_weights * 2L; }
                            filter_data += this._STATIC_FIR_Filter_2051C210DA101DD10D_datastore[checked((int)num7)] * this._STATIC_FIR_Filter_2051C210DA101DD10D_Datareal[checked((int)num6)] + this._STATIC_FIR_Filter_2051C210DA101DD10D_datastore[checked((int)num8)] * this._STATIC_FIR_Filter_2051C210DA101DD10D_Datareal[checked((int)num6)];
                            checked { ++num6; }
                        }
                        filter_data /= this._STATIC_FIR_Filter_2051C210DA101DD10D_w;
                        goto label_50;
                    }
                    else
                    {
                        filter_data = 0.0;
                        goto label_50;
                    }
                }
                label_44:
                filter_data = 0.0;
                goto label_50;
                label_45:
                num2 = -1;
                switch (num1)
                {
                    case 2:
                        goto label_44;
                }
            }
            catch (Exception ex) when (ex is Exception & (uint)num1 > 0U & num2 == 0)
            {
                ProjectData.SetProjectError(ex);
                goto label_45;
            }
            throw ProjectData.CreateProjectError(-2146828237);
            label_50:
            object obj2 = obj1;
            if (num2 == 0)
                return obj2;
            ProjectData.ClearProjectError();
            return obj2;
        }

        public long Data(bool init, double x, ref double lowpass, ref double midpass, ref double highpass)
        {
            if (init)
            {
                this._STATIC_Data_205A2D10D10D10D_low = 0.0;
                this._STATIC_Data_205A2D10D10D10D_high = x;
                init = false;
            }
            else
            {
                this._STATIC_Data_205A2D10D10D10D_low = (this._STATIC_Data_205A2D10D10D10D_low * (double)this.m_Low_pass_kernal + x) / ((double)this.m_Low_pass_kernal + 1.0);
                this._STATIC_Data_205A2D10D10D10D_high = (this._STATIC_Data_205A2D10D10D10D_high * (double)this.m_High_pass_kernal + x) / ((double)this.m_High_pass_kernal + 1.0);
            }
            lowpass = this._STATIC_Data_205A2D10D10D10D_low;
            highpass = x - this._STATIC_Data_205A2D10D10D10D_high;
            midpass = this._STATIC_Data_205A2D10D10D10D_high - this._STATIC_Data_205A2D10D10D10D_low;
            long num;
            return num;
        }

        public double interpolate(long numpoints, ref double[] x, ref double[] y, double xwant)
        {
            int num1;
            double aout;
            int num2;
            try
            {
                ProjectData.ClearProjectError();
                num1 = 2;
                if (numpoints < 1L)
                {
                    aout = 0.0;
                    goto label_22;
                }
                else if (numpoints == 1L)
                {
                    aout = y[0];
                    goto label_22;
                }
                else
                {
                    long num3;
                    long num4;
                    long num5;
                    if (xwant >= x[checked((int)(numpoints - 1L))])
                    {
                        num3 = checked(numpoints - 1L);
                        num4 = checked(num3 - 1L);
                        num5 = checked(num4 - 1L);
                    }
                    else
                    {
                        num5 = 0L;
                        num4 = 1L;
                        num3 = 2L;
                        long num6 = 1;
                        long num7 = checked(numpoints - 1L);
                        long num8 = num6;
                        while (num8 <= num7)
                        {
                            if (x[checked((int)num8)] >= xwant)
                            {
                                num5 = checked(num8 - 1L);
                                num4 = num8;
                                num3 = checked(num8 + 1L);
                                break;
                            }
                            checked { ++num8; }
                        }
                        if (num3 > checked(numpoints - 1L))
                        {
                            num3 = checked(numpoints - 1L);
                            num4 = checked(num3 - 1L);
                            num5 = checked(num4 - 1L);
                        }
                    }
                    if (numpoints == 2L)
                    {
                        double num6 = x[checked((int)num4)] - x[checked((int)num5)];
                        double num7 = y[checked((int)num4)] - y[checked((int)num5)];
                        aout = y[checked((int)num5)] + (xwant - x[checked((int)num5)]) * num7 / num6;
                        goto label_22;
                    }
                    else
                    {
                        this.interp(x[checked((int)num5)], x[checked((int)num4)], x[checked((int)num3)], y[checked((int)num5)], y[checked((int)num4)], y[checked((int)num3)], xwant, ref aout);
                        goto label_22;
                    }
                }
                label_17:
                num2 = -1;
                switch (num1)
                {
                    case 2:
                        aout = 0.0;
                        goto label_22;
                }
            }
            catch (Exception ex) when (ex is Exception & (uint)num1 > 0U & num2 == 0)
            {
                ProjectData.SetProjectError(ex);
                goto label_17;
            }
            throw ProjectData.CreateProjectError(-2146828237);
            label_22:
            double num9 = aout;
            if (num2 == 0)
                return num9;
            ProjectData.ClearProjectError();
            return num9;
        }

        public double Spline_interpolate(bool initialize, long numpoints, ref double[] x, ref double[] y, double xwant)
        {
            int num1;
            double num2;
            int num3;
            try
            {
                Monitor.Enter((object)this._STATIC_Spline_interpolate_205D2A101DD101DDD_y22_Init);
                try
                {
                    if (this._STATIC_Spline_interpolate_205D2A101DD101DDD_y22_Init.State == (short)0)
                    {
                        this._STATIC_Spline_interpolate_205D2A101DD101DDD_y22_Init.State = (short)2;
                        this._STATIC_Spline_interpolate_205D2A101DD101DDD_y22 = new double[checked((int)numpoints + 1)];
                    }
                    else if (this._STATIC_Spline_interpolate_205D2A101DD101DDD_y22_Init.State == (short)2)
                        throw new IncompleteInitialization();
                }
                finally
                {
                    this._STATIC_Spline_interpolate_205D2A101DD101DDD_y22_Init.State = (short)1;
                    Monitor.Exit((object)this._STATIC_Spline_interpolate_205D2A101DD101DDD_y22_Init);
                }
                double[] numArray1 = new double[checked((int)numpoints + 1)];
                double[] numArray2 = new double[checked((int)numpoints + 1)];
                double[] x1 = new double[checked((int)numpoints + 1)];
                double[] y1 = new double[checked((int)numpoints + 1)];
                ProjectData.ClearProjectError();
                num1 = 2;
                if (initialize)
                {
                    long delta;
                    this.registerok = Module1.registercheck(this.DesignMode, ref delta);
                    if (!this.registerok & delta != 4L)
                        Module1.popupwarning(Module1.iseed);
                }
                if (initialize & numpoints > 2L)
                {
                    long num4 = 0;
                    long num5 = checked(numpoints - 1L);
                    long num6 = num4;
                    while (num6 <= num5)
                    {
                        x1[checked((int)num6)] = x[checked((int)num6)];
                        y1[checked((int)num6)] = y[checked((int)num6)];
                        checked { ++num6; }
                    }
                    this.spline(ref x1, ref y1, ref numpoints, ref this._STATIC_Spline_interpolate_205D2A101DD101DDD_y22);
                }
                if (numpoints < 1L)
                {
                    num2 = 0.0;
                    goto label_34;
                }
                else if (numpoints == 1L)
                {
                    num2 = y[0];
                    goto label_34;
                }
                else
                {
                    long num4 = 0;
                    long num5 = 1;
                    long num6 = 1;
                    long num7 = checked(numpoints - 1L);
                    long num8 = num6;
                    while (num8 <= num7)
                    {
                        if (x[checked((int)num8)] >= xwant)
                        {
                            num4 = checked(num8 - 1L);
                            num5 = num8;
                            break;
                        }
                        checked { ++num8; }
                    }
                    if (x[checked((int)(numpoints - 1L))] <= xwant)
                    {
                        num5 = checked(numpoints - 1L);
                        num4 = checked(num5 - 1L);
                    }
                    if (numpoints == 2L)
                    {
                        double num9 = x[checked((int)num5)] - x[checked((int)num4)];
                        double num10 = y[checked((int)num5)] - y[checked((int)num4)];
                        num2 = y[checked((int)num4)] + (xwant - x[checked((int)num4)]) * num10 / num9;
                        goto label_34;
                    }
                    else
                    {
                        double x2 = x[checked((int)num5)] - x[checked((int)num4)];
                        double x3 = (x[checked((int)num5)] - xwant) / x2;
                        double x4 = (xwant - x[checked((int)num4)]) / x2;
                        num2 = x3 * y[checked((int)num4)] + x4 * y[checked((int)num5)] + ((Math.Pow(x3, 3.0) - x3) * this._STATIC_Spline_interpolate_205D2A101DD101DDD_y22[checked((int)num4)] + (Math.Pow(x4, 3.0) - x4) * this._STATIC_Spline_interpolate_205D2A101DD101DDD_y22[checked((int)num5)]) * Math.Pow(x2, 2.0) / 6.0;
                        goto label_34;
                    }
                }
                label_29:
                num3 = -1;
                switch (num1)
                {
                    case 2:
                        num2 = 0.0;
                        goto label_34;
                }
            }
            catch (Exception ex) when (ex is Exception & (uint)num1 > 0U & num3 == 0)
            {
                ProjectData.SetProjectError(ex);
                goto label_29;
            }
            throw ProjectData.CreateProjectError(-2146828237);
            label_34:
            double num11 = num2;
            if (num3 == 0)
                return num11;
            ProjectData.ClearProjectError();
            return num11;
        }

        private void spline(ref double[] x, ref double[] y, ref long n, ref double[] y2)
        {
            double[] numArray1 = new double[checked((int)n + 1)];
            double[] numArray2 = new double[checked((int)n + 1)];
            y2[0] = 0.0;
            numArray2[0] = 0.0;
            long num1 = 1;
            long num2 = checked(n - 2L);
            long num3 = num1;
            while (num3 <= num2)
            {
                double num4 = (x[checked((int)num3)] - x[checked((int)(num3 - 1L))]) / (x[checked((int)(num3 + 1L))] - x[checked((int)(num3 - 1L))]);
                double num5 = num4 * y2[checked((int)(num3 - 1L))] + 2.0;
                y2[checked((int)num3)] = (num4 - 1.0) / num5;
                numArray2[checked((int)num3)] = (y[checked((int)(num3 + 1L))] - y[checked((int)num3)]) / (x[checked((int)(num3 + 1L))] - x[checked((int)num3)]) - (y[checked((int)num3)] - y[checked((int)(num3 - 1L))]) / (x[checked((int)num3)] - x[checked((int)(num3 - 1L))]);
                numArray2[checked((int)num3)] = (6.0 * numArray2[checked((int)num3)] / (x[checked((int)(num3 + 1L))] - x[checked((int)(num3 - 1L))]) - num4 * numArray2[checked((int)(num3 - 1L))]) / num5;
                checked { ++num3; }
            }
            double num6 = 0.0;
            double num7 = 0.0;
            y2[checked((int)(n - 1L))] = (num7 - num6 * numArray2[checked((int)(n - 2L))]) / (num6 * y2[checked((int)(n - 2L))] + 1.0);
            long num8 = checked(n - 2L);
            while (num8 >= 0L)
            {
                y2[checked((int)num8)] = y2[checked((int)num8)] * y2[checked((int)(num8 + 1L))] + numArray2[checked((int)num8)];
                checked { num8 += -1L; }
            }
        }

        private void interp(double t1, double t2, double t3, double a1, double a2, double a3, double twant, ref double aout)
        {
            int num1;
            int num2;
            try
            {
                ProjectData.ClearProjectError();
                num1 = 2;
                double num3 = t1 - t2;
                double num4 = t3 - t2;
                double num5 = num3 * num3 * num4 - num3 * num4 * num4;
                if (num5 != 0.0)
                {
                    double num6 = a2;
                    double num7 = (-(num4 * num4) * a1 - a2 * (num3 * num3) + a2 * (num4 * num4) + num3 * num3 * a3) / num5;
                    double num8 = (num4 * a1 - a2 * num4 + a2 * num3 - num3 * a3) / num5;
                    double num9 = twant - t2;
                    aout = num6 + num7 * num9 + num8 * num9 * num9;
                    goto label_8;
                }
                else
                {
                    aout = a2;
                    goto label_8;
                }
                label_3:
                num2 = -1;
                switch (num1)
                {
                    case 2:
                        goto label_8;
                }
            }
            catch (Exception ex) when (
            {
                // ISSUE: unable to correctly present filter
                int num3;
                if (ex is Exception & (uint)num1 > 0U & num3 == 0)
                {
                    SuccessfulFiltering;
                }
                else
                    throw;
            }
      )
      {
                ProjectData.SetProjectError(ex);
                goto label_3;
            }
            throw ProjectData.CreateProjectError(-2146828237);
            label_8:
            if (num2 == 0)
                return;
            ProjectData.ClearProjectError();
        }

        public long alpha_beta(ref bool init, double x, ref double alpha, ref double beta)
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
            long num3;
            return num3;
        }

        private long ICFFT(ref double[] Datareal, ref double[] Dataimaginary, long number_of_data)
        {
            double[] numArray = new double[checked((int)(2L * number_of_data) + 1)];
            double[] data = new double[checked((int)(2L * number_of_data) + 1)];
            long num1 = 0;
            long num2 = checked(number_of_data - 1L);
            long num3 = num1;
            while (num3 <= num2)
            {
                long num4 = num3;
                data[checked((int)(num3 * 2L))] = Datareal[checked((int)num4)];
                data[checked((int)(num3 * 2L + 1L))] = Dataimaginary[checked((int)num4)];
                checked { ++num3; }
            }
            this.setisign2(-2L);
            long isign = -2;
            long num5 = this.rfft(ref data, checked(number_of_data * 2L), isign);
            long num6 = 0;
            long num7 = checked(number_of_data - 1L);
            long num8 = num6;
            while (num8 <= num7)
            {
                long num4 = num8;
                Datareal[checked((int)num4)] = data[checked((int)(num8 * 2L))] / (double)number_of_data;
                Dataimaginary[checked((int)num4)] = data[checked((int)(num8 * 2L + 1L))] / (double)number_of_data;
                checked { ++num8; }
            }
            return num5;
        }

        private long rfft(ref double[] data, long ntemp, long isign)
        {
            double num1 = 0.5;
            if (isign != 0L)
                this.globalisign = isign;
            if (this.globalisign == 2L)
            {
                this.f1c(ref data, checked((long)Math.Round(unchecked((double)ntemp / 2.0))), 1L);
                return 0;
            }
            if (this.globalisign == -2L)
            {
                this.f1c(ref data, checked((long)Math.Round(unchecked((double)ntemp / 2.0))), -1L);
                return 0;
            }
            int num2 = (int)Interaction.MsgBox((object)"here", MsgBoxStyle.OkOnly, (object)null);
            long num3 = ntemp;
            double a = Math.PI / ((double)num3 / 2.0);
            int num4 = (int)Interaction.MsgBox((object)a, MsgBoxStyle.OkOnly, (object)null);
            double num5;
            if (this.globalisign == 1L)
            {
                num5 = -0.5;
                this.f1c(ref data, checked((long)Math.Round(unchecked((double)num3 / 2.0))), 1L);
            }
            else
            {
                num5 = 0.5;
                a = -a;
            }
            double num6 = Math.Sin(0.5 * a);
            double num7 = -2.0 * num6 * num6;
            double num8 = Math.Sin(a);
            double num9 = 1.0 + num7;
            double num10 = num8;
            long num11 = checked(num3 + 3L);
            long num12 = 2;
            long num13 = checked((long)Math.Round(unchecked((double)num3 / 4.0)));
            long num14 = num12;
            double num15;
            while (num14 <= num13)
            {
                long num16;
                long num17;
                long num18;
                long num19 = (long)checked(1 + -(unchecked(num16 == checked(num11 - (long)-(unchecked(num17 == (long)checked(1 + -(unchecked(num18 == checked(num14 + num14 - 1L)) ? 1 : 0))) ? 1 : 0))) ? 1 : 0));
                num15 = num1 * (data[checked((int)num18)] + data[checked((int)num16)]);
                double num20 = num1 * (data[checked((int)num17)] - data[checked((int)num19)]);
                double num21 = -num5 * (data[checked((int)num17)] + data[checked((int)num19)]);
                double num22 = num5 * (data[checked((int)num18)] - data[checked((int)num16)]);
                data[checked((int)num18)] = num15 + num9 * num21 - num10 * num22;
                data[checked((int)num17)] = num20 + num9 * num22 + num10 * num21;
                data[checked((int)num16)] = num15 - num9 * num21 + num10 * num22;
                data[checked((int)num19)] = -num20 + num9 * num22 + num10 * num21;
                num9 = (double)-(num6 == num9 ? 1 : 0) * num7 - num10 * num8 + num9;
                num10 = num10 * num7 + num6 * num8 + num10;
                checked { ++num14; }
            }
            if (this.globalisign == 1L)
            {
                data[1] = (double)-(num15 == data[1] ? 1 : 0) + data[2];
                data[2] = num15 - data[2];
            }
            else
            {
                data[1] = num1 * ((double)-(num15 == data[1] ? 1 : 0) + data[2]);
                data[2] = num1 * (num15 - data[2]);
                this.f1c(ref data, checked((long)Math.Round(unchecked((double)num3 / 2.0))), -1L);
            }
            return 0;
        }

        private object f1c(ref double[] data1, long nn, long isign)
        {
            double[] numArray1 = new double[2];
            double[] numArray2 = new double[checked((int)(nn * 2L) + 1)];
            long num1 = checked(nn * 2L);
            long num2 = 1;
            long num3 = num1;
            long num4 = num2;
            while (num4 <= num3)
            {
                numArray2[checked((int)num4)] = data1[checked((int)(num4 - 1L))];
                checked { ++num4; }
            }
            long num5 = 1;
            long num6 = 1;
            long num7 = num1;
            long num8 = num6;
            while (num8 <= num7)
            {
                if (num5 > num8)
                {
                    double num9 = numArray2[checked((int)num5)];
                    double num10 = numArray2[checked((int)(num5 + 1L))];
                    numArray2[checked((int)num5)] = numArray2[checked((int)num8)];
                    numArray2[checked((int)(num5 + 1L))] = numArray2[checked((int)(num8 + 1L))];
                    numArray2[checked((int)num8)] = num9;
                    numArray2[checked((int)(num8 + 1L))] = num10;
                }
                long num11;
                for (num11 = nn; num11 >= 2L & num5 > num11; num11 = checked((long)Math.Round(unchecked((double)num11 / 2.0))))
                    checked { num5 -= num11; }
                checked { num5 += num11; }
                checked { num8 += 2L; }
            }
            long num12;
            for (long index = 2; num1 > index; index = num12)
            {
                num12 = checked(index * 2L);
                double a = 2.0 * Math.PI / (double)checked(isign * index);
                double num9 = Math.Sin(0.5 * a);
                double num10 = -2.0 * num9 * num9;
                double num11 = Math.Sin(a);
                double num13 = 1.0;
                double num14 = 0.0;
                long num15 = 1;
                long num16 = index;
                long num17 = num15;
                while (num17 <= num16)
                {
                    long num18 = num17;
                    long num19 = num1;
                    long num20 = num12;
                    long num21 = num19;
                    long num22 = num18;
                    while ((num20 >> 63 ^ num22) <= (num20 >> 63 ^ num21))
                    {
                        long num23 = checked(num22 + index);
                        double num24 = num13 * numArray2[checked((int)num23)] - num14 * numArray2[checked((int)(num23 + 1L))];
                        double num25 = num13 * numArray2[checked((int)(num23 + 1L))] + num14 * numArray2[checked((int)num23)];
                        numArray2[checked((int)num23)] = numArray2[checked((int)num22)] - num24;
                        numArray2[checked((int)(num23 + 1L))] = numArray2[checked((int)(num22 + 1L))] - num25;
                        numArray2[checked((int)num22)] = numArray2[checked((int)num22)] + num24;
                        numArray2[checked((int)(num22 + 1L))] = numArray2[checked((int)(num22 + 1L))] + num25;
                        checked { num22 += num20; }
                    }
                    double num26 = num13;
                    num13 = num13 * num10 - num14 * num11 + num13;
                    num14 = num14 * num10 + num26 * num11 + num14;
                    checked { num17 += 2L; }
                }
            }
            long num27 = 1;
            long num28 = num1;
            long num29 = num27;
            while (num29 <= num28)
            {
                data1[checked((int)(num29 - 1L))] = numArray2[checked((int)num29)];
                checked { ++num29; }
            }
            object obj;
            return obj;
        }

        private long setisign2(long isign)
        {
            this.globalisign = isign;
            return 0;
        }
    }
}
