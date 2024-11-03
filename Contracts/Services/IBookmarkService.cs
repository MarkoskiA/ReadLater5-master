using Contracts.DTOs;
using Contracts.Request;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    //Making the functions asynchronus on purpose so it will reflecrt real life example
    //In the contracts we defined how one service should look like
    public interface IBookmarkService
    {
            Task<BookmarkDto> CreateBookmark(BookmarkRequest bookmarkRequest, string userUid);
            Task<IEnumerable<BookmarkDto>> GetBookmarks(string userUid);
            Task<BookmarkDto> GetBookmark(int bookmarkId, string userUid);
            void UpdateBookmark(BookmarkRequest bookmarkRequest, string userUid);
            void DeleteBookmark(BookmarkRequest bookmarkRequest, string userUid);
    }
}
