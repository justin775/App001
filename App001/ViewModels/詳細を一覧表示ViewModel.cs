using System.Collections.ObjectModel;

using App001.Contracts.ViewModels;
using App001.Core.Contracts.Services;
using App001.Core.Models;

using CommunityToolkit.Mvvm.ComponentModel;

namespace App001.ViewModels;

public partial class 詳細を一覧表示ViewModel : ObservableRecipient, INavigationAware
{
    private readonly ISampleDataService _sampleDataService;

    [ObservableProperty]
    private SampleOrder? selected;

    public ObservableCollection<SampleOrder> SampleItems { get; private set; } = new ObservableCollection<SampleOrder>();

    public 詳細を一覧表示ViewModel(ISampleDataService sampleDataService)
    {
        _sampleDataService = sampleDataService;
    }

    public async void OnNavigatedTo(object parameter)
    {
        SampleItems.Clear();

        // TODO: Replace with real data.
        var data = await _sampleDataService.GetListDetailsDataAsync();

        foreach (var item in data)
        {
            SampleItems.Add(item);
        }
    }

    public void OnNavigatedFrom()
    {
    }

    public void EnsureItemSelected()
    {
        Selected ??= SampleItems.First();
    }
}
