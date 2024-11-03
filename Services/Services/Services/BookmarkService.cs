using AutoMapper;
using Contracts.DTOs;
using Contracts.Request;
using Contracts.Services;
using Data;
using Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace Services.Services
{
    public class BookmarkService : IBookmarkService
    {
        private ReadLaterDataContext _ReadLaterDataContext;
        private readonly ILogger<BookmarkService> _Logger;
        //This Mapper will be used for mapping the values
        private readonly IMapper _Mapper;

        public BookmarkService(ReadLaterDataContext ReadLaterDataContext, IMapper Mapper, ILogger<BookmarkService> logger)
        {
            _ReadLaterDataContext = ReadLaterDataContext;
            _Mapper = Mapper;
            _Logger = logger;
        }
        public async Task<BookmarkDto> CreateBookmark(BookmarkRequest bookmarkRequest, string userUid)
        {
            var bookmark = _Mapper.Map<Bookmark>(bookmarkRequest);

            bookmark.UserId = userUid;
            await _ReadLaterDataContext.AddAsync(bookmark);
            await _ReadLaterDataContext.SaveChangesAsync();

            _Logger.LogInformation($"Bookmark {bookmark.ID} was created");

            var returnBookmark = _Mapper.Map<BookmarkDto>(bookmark);
            return returnBookmark;
        }

        public void DeleteBookmark(BookmarkRequest bookmarkRequest, string userUid)
        {
            var bookmark = _Mapper.Map<Bookmark>(bookmarkRequest);

            bookmark.UserId = userUid; 

            _ReadLaterDataContext.Remove(bookmark);
            _ReadLaterDataContext.SaveChanges();
            _Logger.LogInformation($"Bookmark {bookmark.ID} was deleted");
        }

        public async Task<BookmarkDto> GetBookmark(int bookmarkId, string userUid)
        {
            

            var bookmark = await _ReadLaterDataContext.Bookmark.Where(c => c.ID == bookmarkId && c.UserId == userUid).FirstOrDefaultAsync();
            return _Mapper.Map<BookmarkDto>(bookmark);
        }

        public async Task<IEnumerable<BookmarkDto>> GetBookmarks(string userUid)
        {
            var collection = await _ReadLaterDataContext.Bookmark.Where(c => c.UserId == userUid).ToListAsync();
            return _Mapper.Map<IEnumerable<BookmarkDto>>(collection);
        }

        public void UpdateBookmark(BookmarkRequest bookmarkRequest, string userUid)
        {
            var bookmark = _Mapper.Map<Bookmark>(bookmarkRequest);

            bookmark.UserId = userUid;

            _ReadLaterDataContext.Update(bookmark);
            _ReadLaterDataContext.SaveChanges();
            _Logger.LogInformation($"Bookmark {bookmark.ID} was updated");
        }
    }
}
