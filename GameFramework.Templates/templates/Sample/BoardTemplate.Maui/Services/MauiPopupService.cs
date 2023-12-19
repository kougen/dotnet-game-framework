using System.Diagnostics;
using BoardTemplate.Game.Visuals;
using GameFramework.GameFeedback;
using GameFramework.Manager;

namespace BoardTemplate.Maui.Services;

internal class MauiPopupService : IFeedbackPopup
{
    public void OnGamePaused()
    {
        Debug.WriteLine("Game paused");
    }

    public void OnGameResumed()
    {
        Debug.WriteLine("Game resumed");
    }

    public void OnGameStarted(IGameplayFeedback feedback)
    {
        Debug.WriteLine("Game started");
    }

    public async void OnGameFinished(IGameplayFeedback feedback, GameResolution resolution)
    {
        switch (resolution)
        {
            case GameResolution.Loss:
                await DisplayInfo("You lost!", "Game over");
                break;
            case GameResolution.Win:
                await DisplayInfo("You won!", "Game over");
                break;
            case GameResolution.Nothing:
                Debug.WriteLine("Game finished with no resolution");
                break;
        }
    }

    public void OnGameReset()
    {
        throw new NotImplementedException();
    }

    public void DisplayError(string message, string title)
    {
        throw new NotImplementedException();
    }

    public void DisplaySuccess(string message, string title)
    {
        throw new NotImplementedException();
    }

    public void DisplayWarning(string message, string title)
    {
        throw new NotImplementedException();
    }

    public async Task DisplayInfo(string message, string title)
    {
        await Application.Current?.MainPage?.DisplayAlert(title, message, "OK")!;
    }
}