using System;
using System.Drawing;
using System.Windows.Forms;

namespace SangAdv.Updater.Client
{
    internal partial class eucSAUpdaterProgressBar : UserControl
    {
        #region Enum

        public enum SAProgressStyle
        {
            Continuous = 1,
            Marquee = 2
        }

        #endregion Enum

        #region Variables

        private bool mHasLoaded = false;
        private SAProgressStyle mProgressStyle = SAProgressStyle.Continuous;
        private Timer mTimer = new Timer();

        private int mMinimum = 0;
        private int mMaximum = 100;
        private int mValue = 50;
        private Color mBackColour = Color.DarkGray;
        private Color mFillColour = Color.FromArgb(0, 114, 198);

        private bool mTimerIsRunning = false;
        private bool mIsUpdatingProgress = false;

        private int mTimeInterval = 5000;
        private int mMarqueeValue = 0;
        private bool mDrawMarqueeTail = false;
        private int mMarqueeFillPercentage = 25;
        private int mMarqueeStepSize = 5;

        #endregion Variables

        #region Properties

        public SAProgressStyle ProgressStyle
        {
            get => mProgressStyle;
            set
            {
                mProgressStyle = value;
                ResetDefaults();
                DoProgress();
            }
        }

        public int Minimum
        {
            get => mMinimum;
            set
            {
                mMinimum = value;
                DoProgress();
            }
        }

        public int Maximum
        {
            get => mMaximum;
            set
            {
                mMaximum = value;
                DoProgress();
            }
        }

        public int Value
        {
            get => mValue;
            set
            {
                if (value < Minimum) value = Minimum;
                if (value > Maximum) value = Maximum;
                mValue = value;
                DoProgress();
            }
        }

        public Color BackColour
        {
            get => mBackColour;
            set
            {
                mBackColour = value;
                DoProgress();
            }
        }

        public Color FillColour
        {
            get => mFillColour;
            set
            {
                mFillColour = value;
                DoProgress();
            }
        }

        public int TimerInterVal
        {
            get => mTimeInterval;
            set
            {
                mTimeInterval = value;
                UpdateTimer();
            }
        }

        public int MarqueeFillPercentage
        {
            get => mMarqueeFillPercentage;
            set
            {
                mMarqueeFillPercentage = value;
                DoProgress();
            }
        }

        public int MarqueeStepSize
        {
            get => mMarqueeStepSize;
            set
            {
                mMarqueeStepSize = value;
                if (mMarqueeStepSize > 100) mMarqueeStepSize = 100;
                DoProgress();
            }
        }

        #endregion Properties

        #region Consructor

        public eucSAUpdaterProgressBar()
        {
            InitializeComponent();
            mTimer.Tick += TimerEventProcessor;
            pnlMarqueeTail.Visible = false;
            mHasLoaded = true;
        }

        #endregion Consructor

        #region Methods

        internal void StopMarqueeAnimation()
        {
            if (ProgressStyle != SAProgressStyle.Marquee) return;
            if (!mTimerIsRunning) return;

            StopTimer();
            mMarqueeValue = 0;
            ResetDefaults();
        }

        internal void StartMarqueeAnimation()
        {
            if (ProgressStyle != SAProgressStyle.Marquee) return;
            if (mTimerIsRunning) return;

            mMarqueeValue = 0;
            ResetDefaults();
            DoProgress();
        }

        #endregion Methods

        #region private Methods

        private void ResetDefaults()
        {
            pnlPBInner.Location = new Point(0, 0);
            pnlMarqueeTail.Visible = false;
        }

        private void DoProgress()
        {
            if (!mHasLoaded) return;

            pnlPBOuter.BackColor = BackColour;
            pnlPBInner.BackColor = FillColour;
            pnlMarqueeTail.BackColor = FillColour;

            switch (ProgressStyle)
            {
                case SAProgressStyle.Continuous:
                    DoContinuousUpdate();
                    break;

                case SAProgressStyle.Marquee:
                    DoMarqueeUpdate();
                    break;

                default:
                    break;
            }
        }

        private void DoContinuousUpdate()
        {
            if (mTimerIsRunning) StopTimer();

            if (mIsUpdatingProgress) return;
            mIsUpdatingProgress = true;

            if (Maximum < Minimum) return;

            var tTotal = Maximum - Minimum;
            var tDifference = Value - Minimum;
            var tFraction = (float)tDifference / (float)tTotal;

            if (Value == Maximum) tFraction = 1;

            SuspendLayout();
            pnlPBInner.Width = (int)(pnlPBOuter.Width * tFraction);
            ResumeLayout();

            mIsUpdatingProgress = false;
        }

        private void StopTimer()
        {
            mTimer.Stop();
            mTimer.Enabled = false;
            mTimerIsRunning = false;
        }

        private void StartTimer()
        {
            mTimer.Enabled = true;
            mTimer.Interval = mTimeInterval;
            mTimer.Start();
            mTimerIsRunning = true;
        }

        private void UpdateTimer()
        {
            StopTimer();
            StartTimer();
        }

        private void TimerEventProcessor(Object myObject, EventArgs myEventArgs)
        {
            DoMarqueeUpdate();
        }

        private void DoMarqueeUpdate()
        {
            if (!mTimerIsRunning) StartTimer();
            if (mIsUpdatingProgress) return;

            mMarqueeValue += MarqueeStepSize;
            if (mMarqueeValue > 100 + MarqueeFillPercentage) mMarqueeValue = mMarqueeValue - 100;

            mIsUpdatingProgress = true;
            SuspendLayout();

            DoMarqueeMainUpdate();
            DoMarqueeTailUpdate();

            ResumeLayout();
            mIsUpdatingProgress = false;
        }

        private void DoMarqueeMainUpdate()
        {
            float tFillFraction = 0;
            float tLocationFraction = 0;

            if (mMarqueeValue - MarqueeFillPercentage <= 0)
            {
                mDrawMarqueeTail = false;
                tFillFraction = (float)mMarqueeValue / (float)100;
                tLocationFraction = 0;
            }
            else if (mMarqueeValue - 100 > 0)
            {
                mDrawMarqueeTail = true;
                tLocationFraction = (float)(mMarqueeValue - MarqueeFillPercentage) / (float)100;
                tFillFraction = 1 - tLocationFraction;
            }
            else
            {
                mDrawMarqueeTail = false;
                tFillFraction = (float)MarqueeFillPercentage / (float)100;
                tLocationFraction = (float)(mMarqueeValue - MarqueeFillPercentage) / (float)100;
            }

            pnlPBInner.Location = new Point((int)(pnlPBOuter.Width * tLocationFraction), 0);
            pnlPBInner.Width = (int)(pnlPBOuter.Width * tFillFraction);
        }

        private void DoMarqueeTailUpdate()
        {
            pnlMarqueeTail.Visible = mDrawMarqueeTail;
            if (!mDrawMarqueeTail) return;

            var tTFillFraction = (float)(mMarqueeValue - 100) / (float)100;

            pnlMarqueeTail.Width = (int)(pnlPBOuter.Width * tTFillFraction);
        }

        #endregion private Methods

        #region Process UI

        private void eucSAUpdaterProgressBar_Paint(object sender, PaintEventArgs e)
        {
            pnlPBOuter.Width = Width;
            pnlPBOuter.Height = Height;
        }

        #endregion Process UI
    }
}