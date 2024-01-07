using Avalonia.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SharpDX;
using System;
using System.Threading;
using System.Threading.Tasks;
using Varjo.NET;
using VarjoGazeMouse.WinAPI;

namespace VarjoGazeMouse.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    [ObservableProperty]
    private string _varjoGazeStatus;
    [ObservableProperty]
    private VarjoGaze _varjoGaze;
    [ObservableProperty]
    private double[] _varjoGazeOrigin = new double[3];
    [ObservableProperty]
    private double[] _varjoGazeForward = new double[3];
    [ObservableProperty]
    private bool _varjoGazeContinuousRefresh;

    private VarjoSession _varjoSession;

    public MainViewModel()
    {
        _varjoSession = new VarjoSession();
        _varjoGazeStatus = _varjoSession.GetGazeStatus();
    }

    [RelayCommand]
    void RefreshVarjoGazeStatus()
    {
        VarjoGazeStatus = _varjoSession.GetGazeStatus();
    }

    [RelayCommand]
    void RefreshVarjoGaze()
    {
        VarjoGaze = _varjoSession.GetGaze();
        VarjoGazeOrigin = VarjoGaze.gaze.Origin;
        VarjoGazeForward = VarjoGaze.gaze.Forward;
    }

    [RelayCommand]
    void RequestGazeCalibration()
    {
        var parameters = new VarjoGazeCalibrationParameters[2];
        parameters[0].key = VarjoGazeCalibrationParametersKey.CalibrationType;
        parameters[0].value = VarjoGazeCalibrationParametersValue.CalibrationOneDot;
        parameters[1].key = VarjoGazeCalibrationParametersKey.HeadsetAlignmentGuidanceMode;
        parameters[1].value = VarjoGazeCalibrationParametersValue.AutoContinueOnAcceptableHeadsetPosition;
        _varjoSession.RequestGazeCalibrationWithParameters(parameters);
    }

    [RelayCommand]
    void ToggleVarjoGazeContinuousRefresh()
    {
        if (!VarjoGazeContinuousRefresh) 
            return;

        Task.Run(() =>
        {
            while (VarjoGazeContinuousRefresh)
            {
                RefreshVarjoGaze();
                WinAPIInterop.MoveMouse((VarjoGaze.gaze.Forward[0] * 0.8 + 1) * 0.5, (VarjoGaze.gaze.Forward[1] * 0.8 - 1) * -0.5);
                Thread.Sleep(5);
            }
        });
    }
}
