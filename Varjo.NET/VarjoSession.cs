namespace Varjo.NET
{
    public class VarjoSession : IDisposable
    {
        private readonly IntPtr _session = IntPtr.Zero;

        public VarjoSession()
        {
            _session = VarjoInterop.SessionInit();

            var gazeParameters = new VarjoGazeParameters[2];
            gazeParameters[0].key = VarjoGazeParametersKey.OutputFrequency;
            gazeParameters[0].value = VarjoGazeParametersValue.OutputFrequency200Hz;
            gazeParameters[1].key = VarjoGazeParametersKey.OutputFilterType;
            gazeParameters[1].value = VarjoGazeParametersValue.OutputFilterStandard;
            VarjoInterop.GazeInitWithParameters(_session, gazeParameters, gazeParameters.Length);
        }

        public void RequestGazeCalibration()
        {
            VarjoInterop.RequestGazeCalibration(_session);
        }
        public void RequestGazeCalibrationWithParameters(VarjoGazeCalibrationParameters parameters)
        {
            VarjoInterop.RequestGazeCalibrationWithParameters(_session, ref parameters, 1);
        }
        public void RequestGazeCalibrationWithParameters(VarjoGazeCalibrationParameters[] parameters)
        {
            VarjoInterop.RequestGazeCalibrationWithParameters(_session, parameters, parameters.Length);
        }

        public VarjoError GetError()
        {
            return VarjoInterop.GetError(_session);
        }
        public VarjoGaze GetGaze()
        {
            return VarjoInterop.GetGaze(_session);
        }
        public VarjoViewDescription GetViewDescription(int viewIndex)
        {
            return VarjoInterop.GetViewDescription(_session, viewIndex);
        }

        public string GetGazeStatus()
        {
            SyncProperties();

            if (!GetGazeAllowed())
            {
                return "NOT_AVAILABLE";
            }
            if (!GetHMDConnected())
            {
                return "NOT_CONNECTED";
            }
            if (!GetGazeCalibrated())
            {
                return "CALIBRATING";
            }
            if (!GetGazeCalibrating())
            {
                return "CALIBRATED";
            }

            return "NOT_CALIBRATED";
        }
        public bool GetGazeAllowed()
        {
            return GetPropertyBool(VarjoPropertyKey.GazeAllowed);
        }
        public bool GetHMDConnected()
        {
            return GetPropertyBool(VarjoPropertyKey.HMDConnected);
        }
        public bool GetGazeCalibrating()
        {
            return GetPropertyBool(VarjoPropertyKey.GazeCalibrating);
        }
        public bool GetGazeCalibrated()
        {
            return GetPropertyBool(VarjoPropertyKey.GazeCalibrated);
        }

        private bool GetPropertyBool(VarjoPropertyKey propertyKey)
        {
            VarjoInterop.SyncProperties(_session);
            return VarjoInterop.GetPropertyBool(_session, propertyKey);
        }
        private void SyncProperties()
        {
            VarjoInterop.SyncProperties(_session);
        }

        void IDisposable.Dispose()
        {
            if (_session != IntPtr.Zero)
            {
                VarjoInterop.SessionShutDown(_session);
            }
        }
    }
}
