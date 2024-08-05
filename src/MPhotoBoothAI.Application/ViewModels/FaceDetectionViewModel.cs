﻿using CommunityToolkit.Mvvm.ComponentModel;
using Emgu.CV;

namespace MPhotoBoothAI.Application.ViewModels;

public partial class FaceDetectionViewModel : ViewModelBase, IObserver
{
    private readonly IYoloFaceService _yoloFaceService;
    private readonly ICameraService _cameraService;

    [ObservableProperty]
    private Mat _frame;

    public FaceDetectionViewModel(ICameraService cameraService, IYoloFaceService yoloFaceService)
    {
        _cameraService = cameraService;
        _cameraService.Start();
        _cameraService.Attach(this);
        _yoloFaceService = yoloFaceService;
    }

    public void Notify(Mat mat)
    {
        _yoloFaceService.Run(mat, 0.45f, 0.5f);
        Frame = mat.Clone();
        mat.Dispose();
    }
}
