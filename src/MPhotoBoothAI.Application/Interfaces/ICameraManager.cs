﻿using MPhotoBoothAI.Models.Camera;

namespace MPhotoBoothAI.Application.Interfaces
{
    public interface ICameraManager : IDisposable
    {
        IEnumerable<ICameraDevice> Availables { get; }
        ICameraDevice? Current { get; set; }

        CameraSetting? GetProgram();

        void SetProgram(string programValue);

        CameraSetting? GetIsoSettings();

        void SetIso(string isoValue);

        CameraSetting? GetShutterSpeed();

        void SetShutterSpeed(string shutterSpeedValue);

        CameraSetting? GetWhiteBalance();

        void SetWhiteBalance(string whiteBalanceValue);

        CameraSetting? GetAperture();

        void SetAperture(string apertureValue);
    }
}