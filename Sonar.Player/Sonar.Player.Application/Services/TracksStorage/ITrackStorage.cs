﻿using Sonar.Player.Domain.Entities;
using Sonar.Player.Domain.Enumerations;

namespace Sonar.Player.Application.Services.TracksStorage;

public interface ITrackStorage
{
    Task<Track> SaveTrack(Guid id, MediaFormat format, Stream content);

    Task DeleteTrack(Guid id);
}