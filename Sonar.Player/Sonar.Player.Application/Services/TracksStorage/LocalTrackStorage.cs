﻿using Sonar.Player.Application.Tools;
using Sonar.Player.Domain.Entities;
using Sonar.Player.Domain.Enumerations;

namespace Sonar.Player.Application.Services.TracksStorage;

public class LocalTrackStorage : ITrackStorage
{
    private readonly ITrackPathBuilder _pathBuilder;

    public LocalTrackStorage(ITrackPathBuilder pathBuilder)
    {
        _pathBuilder = pathBuilder;
    }

    public async Task<Track> SaveTrack(Guid id, AudioFormat format, Stream content)
    {
        var trackDirectory = _pathBuilder.GetTrackFolderPath(id);

        if (!Directory.Exists(trackDirectory))
            Directory.CreateDirectory(trackDirectory);

        var fileName = $"track.{format.Value}";
        var filePath = Path.Combine(trackDirectory, fileName);
        var fileStream = File.Create(filePath);
        await content.CopyToAsync(fileStream);

        return new Track(id, format, fileName);
    }
}