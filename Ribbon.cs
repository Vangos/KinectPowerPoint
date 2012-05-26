//
// Developed by Vangos Pterneas
// http://vangos.eu
//
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Tools.Ribbon;
using Microsoft.Office.Interop.PowerPoint;
using Microsoft.Kinect;
using Microsoft.Samples.Kinect.SwipeGestureRecognizer;
using KinectPowerPoint.Properties;

namespace KinectPowerPoint
{
    public partial class Ribbon
    {
        KinectSensor _sensor;

        Skeleton[] _skeletons = new Skeleton[6];

        Recognizer _gestureRecognizer = new Recognizer();

        bool _isPlaying = false;
        bool _isLeftHanded = false;

        private void Ribbon_Load(object sender, RibbonUIEventArgs e)
        {
            InitializePowerPoint();
            InitializeKinect();
        }

        private void InitializePowerPoint()
        {
            
        }

        private void InitializeKinect()
        {
            _sensor = KinectSensor.KinectSensors.Where(sensor => sensor.Status == KinectStatus.Connected).FirstOrDefault();

            if (_sensor != null)
            {
                _sensor.SkeletonStream.Enable();
                _sensor.SkeletonFrameReady += new EventHandler<SkeletonFrameReadyEventArgs>(Sensor_SkeletonFrameReady);

                _gestureRecognizer.SwipeLeftDetected += new EventHandler<KinectGestureEventArgs>(GestureRecognizer_SwipeLeftDetected);
                _gestureRecognizer.SwipeRightDetected += new EventHandler<KinectGestureEventArgs>(GestureRecognizer_SwipeRightDetected);

                btnPlay.Enabled = true;
            }
            else
            {
                grpKinect.Label = "Kinect sensor not connected.";

                btnPlay.Enabled = false;
            }
        }

        void Sensor_SkeletonFrameReady(object sender, SkeletonFrameReadyEventArgs e)
        {
            if (!_sensor.IsRunning) return;

            using (var frame = e.OpenSkeletonFrame())
            {
                if (frame != null)
                {
                    frame.CopySkeletonDataTo(_skeletons);

                    _gestureRecognizer.Recognize(sender, frame, _skeletons);
                }
            }
        }

        void GestureRecognizer_SwipeLeftDetected(object sender, KinectGestureEventArgs e)
        {
            if (!_sensor.IsRunning) return;

            var slideshow = Globals.ThisAddIn.Application.ActivePresentation.SlideShowWindow.View;

            if (!_isLeftHanded)
            {
                slideshow.Previous();
            }
            else
            {
                slideshow.Next();
            }
        }

        void GestureRecognizer_SwipeRightDetected(object sender, KinectGestureEventArgs e)
        {
            if (!_sensor.IsRunning) return;

            var slideshow = Globals.ThisAddIn.Application.ActivePresentation.SlideShowWindow.View;

            if (!_isLeftHanded)
            {
                slideshow.Next();
            }
            else
            {
                slideshow.Previous();
            }
        }

        private void Play_Click(object sender, RibbonControlEventArgs e)
        {
            btnPlay.Image = _isPlaying ? Resources.Play : Resources.Stop;
            btnPlay.Label = _isPlaying ? "Start" : "Stop";

            if (_isPlaying) _sensor.Stop(); else _sensor.Start();

            _isPlaying = !_isPlaying;
        }

        private void LeftHanded_Click(object sender, RibbonControlEventArgs e)
        {
            _isLeftHanded = cbxLeftHanded.Checked;
        }
    }
}
