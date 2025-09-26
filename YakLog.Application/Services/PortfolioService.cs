using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YakLog.Application.Services.Interfaces;
using YakLog.DataTransferring.Dtos;
using YakLog.DataTransferring.Dtos.Enums;
using YakLog.Domain.Entities.MediaItems;
using YakLog.Persistence.Repositories.Interfaces;

namespace YakLog.Application.Services;

public class PortfolioService : IPortfolioService
{
    private readonly IPortfolioRepository _portfolioRepository;

    public PortfolioService(IPortfolioRepository portfolioRepository)
    {
        _portfolioRepository = portfolioRepository;
    }

    public async Task AddMediaItemAsync(MediaItemInputDto mediaItemInputDto)
    {
        var fakeId = 2;
        var portfolio = await _portfolioRepository.GetPortfolioByUserIdAsync(fakeId);
        if (portfolio == null) {
            throw new Exception("Portfolio does not exist for User!");
        }

        var mediaItems = CreateMediaItems(mediaItemInputDto);
        foreach(var mediaItem in mediaItems)
        {
            await _portfolioRepository.AddMediaItemToPortfolioAsync(mediaItem, portfolio!);
        }
    }

    private List<MediaItem> CreateMediaItems(MediaItemInputDto mediaItemInputDto)
    {
        var mediaItems = new List<MediaItem>();
        switch (mediaItemInputDto.MediaType)
        {
            case MediaTypeDto.Game:
                CreateGame(mediaItemInputDto,mediaItems);
                break;
            case MediaTypeDto.Series:
                CreateSeries(mediaItemInputDto, mediaItems);
                break;
            case MediaTypeDto.Book:
                CreateBook(mediaItemInputDto, mediaItems);
                break;
            case MediaTypeDto.Project:
                CreateProject(mediaItemInputDto, mediaItems);
                break;
            case MediaTypeDto.Movie:
                CreateMovie(mediaItemInputDto, mediaItems);
                break;
            default:
                break;
        }
        return mediaItems;
    }

    private void CreateGame(MediaItemInputDto mediaItemInputDto, List<MediaItem> mediaItems)
    {
        var game = new Game
        {
            Title = mediaItemInputDto.Title,
            Console = mediaItemInputDto.Console!
        };
        AddMediaItemProperties(game, mediaItemInputDto);
        mediaItems.Add(game);
    }

    private void AddMediaItemProperties(MediaItem mediaItem, MediaItemInputDto mediaItemInputDto)
    {
        mediaItem.ImageFilePath = mediaItemInputDto.ImageFilePath;
        mediaItem.Finished = mediaItemInputDto.Finished;
        if (mediaItemInputDto.Finished)
        {
            mediaItem.FinishedDate = (DateTime)mediaItemInputDto.FinishedDate!;
        }
    }

    private void CreateSeries(MediaItemInputDto mediaItemInputDto, List<MediaItem> mediaItems)
    {
        var seriesSeasons = new List<SeriesSeason>();
        for (int i = 0; i < mediaItemInputDto.NumberOfSeasons; i++)
        {
            var seriesSeason = new SeriesSeason
            {
                Title = mediaItemInputDto.Title,
                SeasonNumber = i
            };
            AddMediaItemProperties(seriesSeason, mediaItemInputDto);
            mediaItems.Add(seriesSeason);
        }
    }

    private void CreateBook(MediaItemInputDto mediaItemInputDto, List<MediaItem> mediaItems)
    {
        var book = new Book
        {
            Title = mediaItemInputDto.Title,
            Author = mediaItemInputDto.Author!
        };
        AddMediaItemProperties(book, mediaItemInputDto);
        mediaItems.Add(book);
    }

    private void CreateProject(MediaItemInputDto mediaItemInputDto, List<MediaItem> mediaItems)
    {
        var project = new Project
        {
            Title = mediaItemInputDto.Title
        };
        AddMediaItemProperties(project, mediaItemInputDto);
        mediaItems.Add(project);
    }

    private void CreateMovie(MediaItemInputDto mediaItemInputDto, List<MediaItem> mediaItems)
    {
        var movie = new Movie
        {
            Title = mediaItemInputDto.Title,
            ReleaseDate = mediaItemInputDto.ReleaseDate,
            Director = mediaItemInputDto.Director
        };
        AddMediaItemProperties(movie, mediaItemInputDto);
        mediaItems.Add(movie);
    }
}
