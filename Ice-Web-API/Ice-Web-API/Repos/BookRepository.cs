using AutoMapper;
using Ice_Web_API.Data;
using Ice_Web_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Ice_Web_API.Repos
{
    public class BookRepository : IBookRepository
    {
        private readonly WebDbContext _context;
        private readonly IMapper _mapper;

        public BookRepository(WebDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<BookModel>> GetAllBooksAsync()
        {
            var books = await _context.Books!.ToListAsync();
            return _mapper.Map<List<BookModel>>(books);
        }
        public async Task<BookModel> GetBookAsync(int id)
        {
            var book = await _context.Books!.SingleOrDefaultAsync(x => x.Id == id);
            return _mapper.Map<BookModel>(book);
        }
        public async Task<int> AddBookAsync(BookModel model)
        {
            var addBook = _mapper.Map<Book>(model);
            _context.Books!.Add(addBook);
            await _context.SaveChangesAsync();
            return addBook.Id;
        }
        public async Task UpdateBookAsync(int id, BookModel model)
        {
            if (id == model.Id)
            {
                var updBook = _mapper.Map<Book>(model);
                _context.Books!.Update(updBook);
                await _context.SaveChangesAsync();
            }
        }
        public async Task DeleteBookAsync(int id)
        {
            var delBook = _context.Books!.SingleOrDefault(x => x.Id == id);
            if (delBook != null)
            {
                _context.Books!.Remove(delBook);
                await _context.SaveChangesAsync();
            }
        }
    }
}
