namespace KinectPowerPoint
{
    partial class Ribbon : Microsoft.Office.Tools.Ribbon.RibbonBase
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public Ribbon()
            : base(Globals.Factory.GetRibbonFactory())
        {
            InitializeComponent();
        }

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Ribbon));
            this.tab1 = this.Factory.CreateRibbonTab();
            this.grpKinect = this.Factory.CreateRibbonGroup();
            this.btnPlay = this.Factory.CreateRibbonToggleButton();
            this.cbxLeftHanded = this.Factory.CreateRibbonCheckBox();
            this.tab1.SuspendLayout();
            this.grpKinect.SuspendLayout();
            // 
            // tab1
            // 
            this.tab1.ControlId.ControlIdType = Microsoft.Office.Tools.Ribbon.RibbonControlIdType.Office;
            this.tab1.Groups.Add(this.grpKinect);
            this.tab1.Label = "Kinect";
            this.tab1.Name = "tab1";
            // 
            // grpKinect
            // 
            this.grpKinect.Items.Add(this.btnPlay);
            this.grpKinect.Items.Add(this.cbxLeftHanded);
            this.grpKinect.Label = "Kinect";
            this.grpKinect.Name = "grpKinect";
            // 
            // btnPlay
            // 
            this.btnPlay.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.btnPlay.Image = ((System.Drawing.Image)(resources.GetObject("btnPlay.Image")));
            this.btnPlay.Label = "Start";
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.ShowImage = true;
            this.btnPlay.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.Play_Click);
            // 
            // cbxLeftHanded
            // 
            this.cbxLeftHanded.Label = "Left handed";
            this.cbxLeftHanded.Name = "cbxLeftHanded";
            this.cbxLeftHanded.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.LeftHanded_Click);
            // 
            // Ribbon
            // 
            this.Name = "Ribbon";
            this.RibbonType = "Microsoft.PowerPoint.Presentation";
            this.Tabs.Add(this.tab1);
            this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.Ribbon_Load);
            this.tab1.ResumeLayout(false);
            this.tab1.PerformLayout();
            this.grpKinect.ResumeLayout(false);
            this.grpKinect.PerformLayout();

        }

        #endregion

        internal Microsoft.Office.Tools.Ribbon.RibbonTab tab1;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup grpKinect;
        internal Microsoft.Office.Tools.Ribbon.RibbonToggleButton btnPlay;
        internal Microsoft.Office.Tools.Ribbon.RibbonCheckBox cbxLeftHanded;
    }

    partial class ThisRibbonCollection
    {
        internal Ribbon Ribbon
        {
            get { return this.GetRibbon<Ribbon>(); }
        }
    }
}
